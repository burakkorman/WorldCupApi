using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCupApi.Repository.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public Guid GroupId { get; set; }
    
    [ForeignKey("GroupId")] public Group Group { get; set; }
}