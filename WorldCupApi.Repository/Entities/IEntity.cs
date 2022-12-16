namespace WorldCupApi.Repository.Entities;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}