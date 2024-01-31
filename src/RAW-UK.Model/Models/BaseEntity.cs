using System.Reflection.Metadata;

namespace RAW_UK.Model;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsArchived { get; set; } = false;
    public DateTime? ArchivedDate { get; set; } = null;
}
