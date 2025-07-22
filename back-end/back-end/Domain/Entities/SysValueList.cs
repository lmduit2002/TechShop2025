using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class SysValueList
{
    public string ListName { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
