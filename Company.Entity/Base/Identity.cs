namespace Company.Entity.Base
{
    public abstract class Identity : IGuidId
    {
        public Guid Id { get; set; } = default!;
    }
}
