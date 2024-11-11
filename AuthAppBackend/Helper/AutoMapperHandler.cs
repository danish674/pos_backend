using AuthAppBackend.ModelTemp;
using AuthAppBackend.ViewModels;
using AutoMapper;

namespace AuthAppBackend.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<TblCustomer, CustomerVM>()
            .ForMember(
                item => item.StatusName,
                opt => opt.MapFrom(item => item.IsActive.HasValue && item.IsActive.Value ? "Active" : "Inactive")
            ).ReverseMap();
        }
    }
}
