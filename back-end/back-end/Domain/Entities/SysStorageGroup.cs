using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class SysStorageGroup
{
    public string StorageGroupCode { get; set; } = null!;

    public string? StorageGroupName { get; set; }

    public string? StorageGroupName2 { get; set; }

    public string? CategoryCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category? CategoryCodeNavigation { get; set; }

    public virtual ICollection<SysStorage> SysStorages { get; set; } = new List<SysStorage>();
}
