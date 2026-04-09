namespace DevLab.Domain.Abstractions;

// 领域实体基类（国际标准）
public abstract class BaseEntity
{
    // <summary>
    /// 唯一标识
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 创建时间（通用审计字段，默认UTC时间，所有实体必填）
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// 更新时间（通用审计字段，可选）
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}