namespace AuthAppBackend.ViewModels
{
    public class CustomerVM
    {
        public int CustId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public decimal? CreditLimit { get; set; }

        public bool? IsActive { get; set; }
    
        public string? StatusName { get; set; }
    }
}
