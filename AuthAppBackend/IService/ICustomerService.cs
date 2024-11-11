using AuthAppBackend.Helper;
using AuthAppBackend.ModelTemp;
using AuthAppBackend.ViewModels;

namespace AuthAppBackend.IService
{
    public interface ICustomerService
    {
        Task<List<CustomerVM>> GetAll();
        Task<CustomerVM> GetById(int id);
        Task<APIResponse> Remove(int id);
        Task<APIResponse> Create(CustomerVM data);
        Task<APIResponse> Update(CustomerVM data, int id);
    }
}
