namespace MRB.Domain;

public class BaseEntity<T>
{
    protected BaseEntity() { }

    public BaseEntity(string identifier, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
    {
        Identifier = identifier;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public T Id { get; private set; }
    public string Identifier {get; private set;}
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public void Delete() => DeletedAt = DateTime.UtcNow;
    public void UpdateUpdatedAt() => UpdatedAt = DateTime.UtcNow;
}