using DevLab.Application.Services;
using DevLab.Domain.Interfaces;
using DevLab.Infrastructure.Data;// 新增：引入DbContext
using DevLab.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;// 新增：EF Core命名空间

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 新增：注册DbContext（读取连接字符串）
builder.Services.AddDbContext<DevLabDbContext>(options =>
{
    // 使用SQL Server（若用MySQL则换UseMySql）
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevLabDbContext"));
});

// -------------- 干净架构注入（核心）// 注册仓储和服务--------------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// -------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.// 配置HTTP请求管道
if (!app.Environment.IsDevelopment())
{
    // 非开发环境：启用自定义错误页面
    app.UseExceptionHandler("/Home/Error");// 500等服务器错误
    // 新增：捕获404/403等状态码，跳转到错误页面并传递状态码
    app.UseStatusCodePagesWithReExecute("/Home/Error/{0}"); // 捕获404/403等状态码
    app.UseHsts();
}
else
{
    // 开发环境：仅显示详细错误（便于调试）
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();// 可选：启用HTTPS重定向（生产环境建议保留）

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 默认路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 兜底路由：匹配所有未命中的URL（修复Redirect的await错误）
app.MapFallback(context =>
{
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    // 移除await，直接调用Redirect（同步方法）
    context.Response.Redirect("/Home/Error/404");
    // 必须返回Task.CompletedTask，满足委托返回值要求
    return Task.CompletedTask;
});

app.Run();
