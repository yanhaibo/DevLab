using DevLab.Domain.Abstractions;

namespace DevLab.Domain.Entities;

// User 实体 继承 基类（完全标准）
public class User : BaseEntity
{
    /// <summary>
    /// 登录账号(唯一) 不能为空
    /// </summary>
    public string UserName { get; set; }=string.Empty;

    /// <summary>
    /// 用户昵称 不能为空（注：非唯一，若需唯一请在数据库上下文添加唯一索引）
    /// </summary>
    public string NickName { get; set; }=string.Empty;

    /// <summary>
    /// 密码哈希值 不能为空
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// 电子邮箱(唯一) 不能为空
    /// </summary>
    public string Email { get; set; }= string.Empty;

    /// <summary>
    /// 手机号码(唯一) 不能为空
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// 头像地址 允许为空
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// 出生日期 允许为空
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// 角色编号(默认1=普通用户) 不能为空
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// 是否启用(1=启用,0=禁用) 不能为空
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// 邮箱是否验证(1=是,0=否) 不能为空
    /// </summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>
    /// 手机是否验证(1=是,0=否) 不能为空
    /// </summary>
    public bool IsPhoneVerified { get; set; }

    /// <summary>
    /// 登录令牌(唯一登录) 允许为空
    /// </summary>
    public string? LoginToken { get; set; }

    /// <summary>
    /// 密码重置令牌 允许为空
    /// </summary>
    public string? PasswordResetToken { get; set; }

    /// <summary>
    /// 重置令牌过期时间 允许为空
    /// </summary>
    public DateTime? PasswordResetTokenExpiresAt { get; set; }
}