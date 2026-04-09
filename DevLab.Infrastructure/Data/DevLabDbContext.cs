using DevLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevLab.Infrastructure.Data;

// 数据库上下文（核心：映射实体与数据库表）
public class DevLabDbContext : DbContext
{
    // 构造函数：接收配置（读取连接字符串）
    public DevLabDbContext(DbContextOptions<DevLabDbContext> options) : base(options)
    {
    }

    // 映射User实体到数据库的User表
    public DbSet<User> User => Set<User>();

    // 可选：配置实体（如主键、字段约束）
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}