using System;
using System.Collections.Generic;

namespace AuthAppBackend.ModelTemp;

public partial class TblRefreshToken
{
    public string UserId { get; set; } = null!;

    public string? TokenId { get; set; }

    public string? RefreshToken { get; set; }
}
