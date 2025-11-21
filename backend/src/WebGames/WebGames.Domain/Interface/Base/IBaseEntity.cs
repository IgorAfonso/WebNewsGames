namespace WebGames.Domain.Interface.Base;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreateDate { get; set; }
    DateTime UpdateDate { get; set; }
}
