using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevLab.Web.Models;

namespace DevLab.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // 通用错误页面（接收状态码参数）
    public IActionResult Error(int? statusCode = null)
    {
        // 设置响应状态码（保证浏览器识别真实错误类型）
        Response.StatusCode = statusCode ?? StatusCodes.Status500InternalServerError;

        // 向视图传递错误信息
        ViewBag.StatusCode = statusCode;
        ViewBag.Message = statusCode switch
        {
            404 => "抱歉，你访问的页面不存在（网址输入错误/资源已删除）",
            500 => "服务器内部错误，请稍后重试",
            _ => "请求处理失败，请检查网址或联系管理员"
        };

        return View();
    }
}
