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
    public class GenericController<IGenericRepo,GenericClass> : Controller
        where GenericClass : class, IEntity
        where IGenericRepo : IGenericRepository<GenericClass>
    {
        private readonly IGenericRepo genericRepo;

        public GenericController(IGenericRepo genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        [HttpPost("Registrar")]
        public async Task<ApiResponse> Registrar(GenericClass genericClass)
        {
            try
            {
                await this.genericRepo.Create(genericClass);

                return BuildApiResponse.BuildOk();
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk( "Hubo un error al registrar");
            }
            

        }

        [HttpGet("Listar")]
        public ApiResponse<List<GenericClass>> Get()
        {
            var response = new List<GenericClass>();

            try
            {
                response = this.genericRepo.GetAll().ToListAsync().Result;

                return BuildApiResponse.BuildOk<List<GenericClass>>(response);
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk<List<GenericClass>>(response, "Hubo un error al realizar el listar");
            }
            
            

        }

        [HttpPost("Modificar")]
        public ApiResponse Modificar(GenericClass genericClass)
        {

            try
            {
                this.genericRepo.Update(genericClass.Id, genericClass);

                return BuildApiResponse.BuildOk();
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
            }
            
            

        }

        // GET
        [HttpGet("ListarPorId")]
        public ApiResponse<GenericClass> Get(int id)
        {
            
            try
            {
                var response = this.genericRepo.GetById(id).Result;
                return BuildApiResponse.BuildOk<GenericClass>(response);
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk<GenericClass>(null,"Hubo un error al listar por id");
            }
        }

        // DELETE
        [HttpPost("Borrar")]
        public ApiResponse Delete(int id)
        {
            try
            {
                this.genericRepo.Delete(id);


                return BuildApiResponse.BuildOk();
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk("Hubo un error al borrar");
            }
        }
    }
}
