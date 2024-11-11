using AuthAppBackend.Helper;
using AuthAppBackend.IService;
using AuthAppBackend.ModelTemp;
using AuthAppBackend.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuthAppBackend.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly TestDbContext _context;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(TestDbContext context, IMapper mapper, ILogger<CustomerService> logger)
        {
            _context = context;
            this.mapper = mapper;
            _logger = logger;
        }

        public async Task<APIResponse> Create(CustomerVM data)
        {
            APIResponse response = new APIResponse();
            try
            {
                this._logger.LogInformation("Create Begins");
                TblCustomer _customer = this.mapper.Map<CustomerVM, TblCustomer>(data);
                await _context.TblCustomers.AddAsync(_customer);
                await _context.SaveChangesAsync();
                response.ResponseCode = 201;
            }
            catch(Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
                this._logger.LogError(response.ErrorMessage);
            }
            return response;
        }

        public async Task<List<CustomerVM>> GetAll()
        {
            List<CustomerVM> _response = new List<CustomerVM>();
            var data = await _context.TblCustomers.ToListAsync();
            if (data != null )
            {
                _response = this.mapper.Map<List<TblCustomer>, List<CustomerVM>>( data );
            }
            return _response;
        }

        public async Task<CustomerVM> GetById(int id)
        {
            CustomerVM _response = new CustomerVM();
            var data = await _context.TblCustomers.FindAsync(id);
            if (data != null)
            {
                _response = this.mapper.Map<TblCustomer, CustomerVM>(data);
            }
            return _response;
        }

        public async Task<APIResponse> Remove(int id)
        {
            APIResponse response = new APIResponse();
            try
            {
                var data = await _context.TblCustomers.FindAsync(id);
                if (data != null )
                {
                    _context.TblCustomers.Remove(data);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.ResponseCode = 400;
                    response.ErrorMessage = "Data not found.";
                }
                response.ResponseCode = 201;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(CustomerVM data, int id)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await _context.TblCustomers.FindAsync(id);
                if (_customer != null)
                {
                    _customer.Name = data.Name;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.CreditLimit = data.CreditLimit;
                    _customer.Name = data.Name;
                    await _context.SaveChangesAsync();
                    response.ResponseCode = 201;
                }
                else
                {
                    response.ResponseCode = 400;
                    response.ErrorMessage = "Data not found.";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
