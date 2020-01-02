using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.ControleDeVinhos.Banco;
using WebApi.ControleDeVinhos.Models;
using WebApi.ControleDeVinhos.Repository;

namespace WebApi.ControleDeVinhos.Controllers
{
    public class VinhosController : ApiController
    {

        IRepositoryVinhos repository;

        // injeção de dependência com o Unity - install pakage unity
        public VinhosController(IRepositoryVinhos repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Vinhos> GetVinhos()
        {
            return this.repository.GetVinhos();
        }


        // GET: api/Vinhos/5
        [ResponseType(typeof(Vinhos))]
        public async Task<IHttpActionResult> GetVinhos(int id)
        {
            Vinhos vinho = this.repository.GetVinhosById(id);
            if (vinho == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vinho);
            }
        }

        // PUT: api/Vinhos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVinhos(int id, Vinhos vinho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vinho.Cod_vinho)
            {
                return BadRequest();
            }

            try
            {
                this.repository.UpdateVinho(vinho);
            }
            catch
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vinhos
        [ResponseType(typeof(Vinhos))]
        public async Task<IHttpActionResult> PostVinhos(Vinhos vinho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this.repository.InsertVinho(vinho);
            }
            catch
            {
                throw;
            }
            return CreatedAtRoute("DefaultApi", new { id = vinho.Cod_vinho }, vinho);
        }

        // DELETE: api/Vinhos/5
        [ResponseType(typeof(Vinhos))]
        public async Task<IHttpActionResult> DeleteVinhos(int id)
        {
            Vinhos vinho = this.repository.GetVinhosById(id);
            if (vinho == null)
            {
                return NotFound();
            }

            try
            {
                this.repository.DeleteVinho(vinho);
            }
            catch
            {
                throw;
            }

            return Ok(vinho);
        }

        
    }
}