using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolidExample.Models.BOs;
using SolidExample.Models.DTOs;
using SolidExample.Services;
using System.ComponentModel.DataAnnotations;

namespace SolidExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: user
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserDto>>(await _service.GetAsync()));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: user/send/5
        [HttpGet("send/{id}")]
        public async Task<IActionResult> SendEmail([Required] Guid id)
        {
            try
            {
                var user  = await _service.GetByIdAsync(id);
                return Ok(_service.SendEmail(user.Email));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(await _service.GetByIdAsync(id)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto entity)
        {
            try
            {
                await _service.AddOrUpdateAsync(_mapper.Map<UserBO>(entity));
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
