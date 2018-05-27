using System.Diagnostics;
using System.Threading.Tasks;
using unAventonApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Services.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Services.Interfaces;
using System;

namespace unAventonApi.Controllers.Base
{
    public class GenericController<IGenericRepo, GenericClass> : Controller
        where GenericClass : class, IEntity
        where IGenericRepo : IGenericRepository<GenericClass>
    {
        public readonly IGenericRepo genericRepo;

        public GenericController(IGenericRepo genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody]GenericClass genericClass)
        {
            try
            {
                await this.genericRepo.Create(genericClass);

                // return BuildApiResponse.BuildOk();
                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk( "Hubo un error al registrar");
                return BadRequest("Hubo un error al registrar");
            }


        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            var response = new List<GenericClass>();

            try
            {
                response = this.genericRepo.GetAll().ToListAsync().Result;

                // return BuildApiResponse.BuildOk<List<GenericClass>>(response);
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk<List<GenericClass>>(response, "Hubo un error al realizar el listar");
                return BadRequest("Hubo un error al listar");
            }



        }

        [HttpPost("Modificar")]
        public IActionResult Modificar([FromBody]GenericClass genericClass)
        {

            try
            {
                this.genericRepo.Update(genericClass.Id, genericClass);

                // return BuildApiResponse.BuildOk();
                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al modificar");
            }



        }

        // GET
        [HttpPost("ListarPorId")]
        public IActionResult Get([FromBody]int id)
        {
            try
            {
                var response = this.genericRepo.GetById(id).Result;

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }

        // DELETE
        [HttpPost("Borrar")]
        public IActionResult Delete([FromBody]int id)
        {

            try
            {
                this.genericRepo.Delete(id);

                // return BuildApiResponse.BuildOk();
                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al borrar con id: " + id);
            }
        }
    }
}
