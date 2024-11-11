using AuthAppBackend.IService;
using AuthAppBackend.ModelTemp;
using AuthAppBackend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace AuthAppBackend.Controllers
{
    [EnableRateLimiting("fixedwindows")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var data = await this.service.GetAll();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await this.service.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var data = await this.service.Remove(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerVM model)
        {
            var data = await this.service.Create(model);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerVM model, int id)
        {
            var data = await this.service.Update(model, id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
