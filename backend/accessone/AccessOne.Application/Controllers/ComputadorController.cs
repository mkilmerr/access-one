using System;
using AccessOne.Domain.Entities;
using AccessOne.Service.Services;
using AccessOne.Service.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessOne.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    public class ComputadorController : ControllerBase
    {

        private ComputadorService service = new ComputadorService();

        [HttpGet]
        [AllowAnonymous]
        [Route("computador")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("computador/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("computador")]
        public IActionResult Post([FromBody] Computador item)
        {
            try
            {
                service.Post<ComputadorValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("computador")]
        public IActionResult Put([FromBody] Computador item)
        {
            try
            {
                service.Put<ComputadorValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("computador")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
