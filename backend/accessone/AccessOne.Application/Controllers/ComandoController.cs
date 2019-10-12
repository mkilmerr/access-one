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
    public class ComandoController : ControllerBase
    {
        private ComandoService service = new ComandoService();

        [HttpGet]
        [AllowAnonymous]
        [Route("comando")]
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
        [Route("comando/{id}")]
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
        [Route("comando")]
        public IActionResult Post([FromBody] Comando item)
        {
            try
            {
                service.Post<ComandoValidator>(item);

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
        [Route("comando")]
        public IActionResult Put([FromBody] Comando item)
        {
            try
            {
                service.Put<ComandoValidator>(item);

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
        [Route("comando")]
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
