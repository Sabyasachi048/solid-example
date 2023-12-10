using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidExample.Models.BOs;
using SolidExample.Models.DTOs;
using SolidExample.Services;
using System.ComponentModel.DataAnnotations;

namespace SolidExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService service, IMapper mapper)
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
                return Ok(_mapper.Map<IEnumerable<AuthorDto>>(await _service.GetAsync()));
            }
            catch (Exception ex)
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
                return Ok(_mapper.Map<AuthorDto>(await _service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDto entity)
        {
            try
            {
                await _service.AddOrUpdate(_mapper.Map<AuthorBO>(entity));
                return Ok();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
