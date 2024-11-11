using System;
using System.Collections.Generic;

namespace AuthAppBackend.ModelTemp;

public partial class TblCustomer
{
    public int CustId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? CreditLimit { get; set; }

    public bool? IsActive { get; set; }

    public string? TaxCode { get; set; }
}
