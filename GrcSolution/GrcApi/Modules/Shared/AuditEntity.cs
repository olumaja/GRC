namespace Arm.GrcApi.Modules.Shared;
public class AuditEntity
{
    public DateTime CreatedOnUtc { get; private set; } = DateTime.Now;

    public Guid CreatedBy { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    public Guid? ModifiedBy { get; private set; }

    public bool IsDeleted { get; private set; } = false;

    public Guid? DeletedBy { get; private set; }
    public DateTime? DateDeleted { get; private set; }

    public void SetModifiedOnUtc(DateTime modifiedOnUtc)
    {
        ModifiedOnUtc = modifiedOnUtc;
    }

    public void SetModifiedBy(Guid modifiedBy)
    {
        ModifiedBy = modifiedBy;
    }

    public void AddCreatedBy(Guid createdBy = default)
    {
        CreatedBy = createdBy;
    }

    public void SetDelete()
    {
        DateDeleted = DateTime.Now;
        IsDeleted = true;
    }
}

public class AuditEntity2 : AuditEntity
{
    public new string? CreatedBy { get; private set; }
    public new string? ModifiedBy { get; private set; }

    public void SetModifiedBy(string? modifiedBy)
    {
        ModifiedBy = modifiedBy;
    }

    public void SetCreatedBy(string? createdBy)
    {
        AddCreatedBy();
        CreatedBy = createdBy;
    }
}
