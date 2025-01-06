namespace MasterNet.Domain;

public abstract record BaseEntity
{
    public Guid Id { get; set; }
}