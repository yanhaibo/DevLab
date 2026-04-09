using DevLab.Domain.Entities;
using DevLab.Domain.Interfaces;
using DevLab.Infrastructure.Data;// 新增：引入DbContext
using Microsoft.EntityFrameworkCore;// 新增：EF Core查询扩展

namespace DevLab.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevLabDbContext _dbContext; // 注入DbContext

    // 构造函数注入DbContext
    public UserRepository(DevLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// 根据 Id 获取用户（只读查询，使用 AsNoTracking 提升性能）
    /// </summary>
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0) return null;
        return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
    /// <summary>
    /// 获取所有用户（只读）
    /// </summary>
    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.User.AsNoTracking().ToListAsync(cancellationToken);
    }
}