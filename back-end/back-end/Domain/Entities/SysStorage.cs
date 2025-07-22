using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class SysStorage
{
    public string StorageCode { get; set; } = null!;

    public string? StorageName { get; set; }

    public string? StorageName2 { get; set; }

    public string? StorageGroupCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SysStorageGroup? StorageGroupCodeNavigation { get; set; }
}
