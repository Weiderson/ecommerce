using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http; 
using System.Web.Http;
using Ecommerce.Domain;
using Ecommerce.Infra.DataContext;
using System.Web.Http.Cors;

namespace Ecommerce.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
         
        private EcommerceDataContext db = new EcommerceDataContext();

        [Route("clientes")]
        public HttpResponseMessage GetClientes()
        {
            var result = db.Clientes.Include("Telefones");
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("clientes/{Cpf}")]
        public HttpResponseMessage GetClienteByCpf(long cpf)
        {
            var result = db.Clientes.Include("Telefones").Where(c => c.Cpf == cpf);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("clientes")]
        public HttpResponseMessage PostCliente(Cliente cliente)
        {
            if ( cliente == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
               
                var result = cliente;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error ao inserir novo cliente."); ;
            }            
        }


        [Route("telefones")]
        public HttpResponseMessage GetTelefones()
        {
            var result = db.Telefones.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("telefones")]
        public HttpResponseMessage PostCliente(Telefone telefone)
        {
            if (telefone == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Telefones.Add(telefone);
                db.SaveChanges();

                var result = telefone;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error ao inserir novo telefone."); ;
            }
        }


    }       
}