using DevLab.Domain.Entities;

namespace DevLab.Application.Services;

public interface IUserService
{
    /// <summary>
    /// 根据 Id 获取用户（若不存在返回 null）。
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken">带 CancellationToken 的版本 = 支持 “请求取消”,如果用户关闭页面 / 取消请求 → 数据库查询自动停止，= default 表示可传可不传，不影响旧代码</param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取所有用户（只读）。
    /// </summary>
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
}