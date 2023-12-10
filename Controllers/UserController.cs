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

        // GET: api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(await _service.GetById(id)));
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
                await _service.AddOrUpdate(_mapper.Map<UserBO>(entity));
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            try
            {
                await _service.Remove(id);
                return Ok();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
