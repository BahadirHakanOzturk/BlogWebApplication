namespace Blog.Entities.Abstract;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool Status { get; set; } = true;
}
