using DevLab.Domain.Entities;
using DevLab.Domain.Interfaces;

namespace DevLab.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// 根据 Id 获取用户（若不存在返回 null）。支持请求取消。
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0) return null;
        //// 检查：要不要取消？
        cancellationToken.ThrowIfCancellationRequested();

        // 如果仓储将来支持 CancellationToken，可在此传入；当前仓储方法不接受 token
        return await _userRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // 要求仓储提供 GetAllAsync() 或 IUserRepository 继承自 IRepositoryBase<User>
        var users = await _userRepository.GetAllAsync(cancellationToken);

        // 保证不返回 null
        return users ?? Enumerable.Empty<User>();
    }
}