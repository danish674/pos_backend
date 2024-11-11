using System;
using System.Collections.Generic;

namespace AuthAppBackend.ModelTemp;

public partial class TblUser
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public string? Role { get; set; }
}
