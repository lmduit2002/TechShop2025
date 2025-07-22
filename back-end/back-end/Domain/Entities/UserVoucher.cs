using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class UserVoucher
{
    public int UserVoucherId { get; set; }

    public int? UserId { get; set; }

    public int? VoucherId { get; set; }

    public DateTime? UsedAt { get; set; }

    public virtual User? User { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
