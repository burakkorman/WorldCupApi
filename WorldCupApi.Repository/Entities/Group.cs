namespace WorldCupApi.Repository.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<Team> Teams { get; set; }
}