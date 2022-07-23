namespace Company.Entity.Base;

public abstract class ForeignKeyUser : Auditable
{
    public Guid UserId { get; set; }
}
