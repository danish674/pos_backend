using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthAppBackend.ModelTemp;

public partial class TblUser
{
    [StringLength(50)]
    [Required]
    public string Code { get; set; } = null!;
    [StringLength(250)]

    public string? Name { get; set; }
    [StringLength(100)]

    public string? Email { get; set; }
    [StringLength(20)]

    public string? Phone { get; set; }
    [StringLength(50)]

    public string? Password { get; set; }

    public bool? IsActive { get; set; }
    [StringLength(50)]
    public string? Role { get; set; }
}
