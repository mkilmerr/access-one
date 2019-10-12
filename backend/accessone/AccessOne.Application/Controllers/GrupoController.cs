using System;
using System.Collections.Generic;
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
    public class GrupoController : ControllerBase
    {
        private GrupoService service = new GrupoService();

        [HttpGet]
        [AllowAnonymous]
        [Route("grupo")]
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
        [Route("grupo/{id}")]
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
        [Route("grupo")]
        public IActionResult Post([FromBody] Grupo item)
        {
            try
            {
                service.Post<GrupoValidator>(item);

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
        [Route("grupo")]
        public IActionResult Put([FromBody] Grupo item)
        {
            try
            {
                service.Put<GrupoValidator>(item);

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
        [Route("grupo")]
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
