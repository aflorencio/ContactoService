using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace sysContacto.Controllers
{
    public class ContactoController : ApiController
    {
        private sysContacto.Core.MainCoreContacto _ = new sysContacto.Core.MainCoreContacto();

        #region GET
        // GET: api/Contacto
        [HttpGet]
        [Route("api/contacto")]
        public List<sysContacto.Core.DB.Models.ContactoDBModel> Get()
        {
            var data = _.ReadAll();

            return data;
        }

        // GET: api/Contacto/5
        [HttpGet]
        [Route("api/contacto/{id}")]
        public sysContacto.Core.DB.Models.ContactoDBModel Get(string id)
        {
            var data = _.ReadId(id);
            return data;
        }

        //GET: api/contacto/nombre/valor
        [HttpGet]
        [Route("api/contacto/{fieldName}/{fieldValue}")]
        public List<sysContacto.Core.DB.Models.ContactoDBModel> Get(string fieldName, string fieldValue) {
           return _.ReadValue(fieldName, fieldValue);
        }
        #endregion

        #region POST

        // POST: api/Contacto
        [HttpPost]
        [Route("api/contacto")]
        public string Post(FormDataCollection value)
        {

            sysContacto.Core.DB.Models.ContactoDBModel data = new sysContacto.Core.DB.Models.ContactoDBModel();

            data.nombre = value.Get("nombre");
            data.apellidos = value.Get("apellidos");
            data.telefono1 = value.Get("telefono1");
            data.telefono2 = value.Get("telefono2");
            data.email1 = value.Get("email1");
            data.email2 = value.Get("email2");
            data.dni = value.Get("dni");
            data.cif = value.Get("cif");
            data.municipio = value.Get("municipio");
            data.direccion = value.Get("direccion");
            data.codPostal = value.Get("codPostal");
            data.provincia = value.Get("provincia");
            data.pais = value.Get("pais");
            data.lang = value.Get("lang");
            data.langNative = value.Get("langNative");
            data.comercialAsignado = value.Get("comercialAsignado");
            data.particularEmpresa = value.Get("particularEmpresa");
            data.descripcionCaso = value.Get("descripcionCaso");
            data.recibidoPorSecretaria = value.Get("recibidoPorSecretaria") == "true" ? true : false;
            data.fuentePosibleCliente = value.Get("fuentePosibleCliente");
            data.rol = value.Get("rol");


            //var gola = value.Get("name");
            _.CreateContacto(data);

            return "OK! ";

        }

        #endregion

        #region PUT

        // PUT: api/Contacto/5
        [HttpPut]
        [Route("api/contacto/{id}")]
        public string Put(string id, FormDataCollection value)
        {
            var name = value.FirstOrDefault().Key.ToString();
            var valor = value.FirstOrDefault().Value.ToString();

            sysContacto.Core.DB.Models.ContactoDBModel obj = new sysContacto.Core.DB.Models.ContactoDBModel();
            var existeMetodo = obj.GetType().GetProperty(name) == null ? false : true;
            if (existeMetodo == true)
            {
                _.Update(id, name, valor);
                return "OK!";
            }

            return "Error";
        }

        #endregion

        #region DELETE

        // DELETE: api/Contacto/5
        [HttpDelete]
        [Route("api/contacto/{id}")]
        public void Delete(string id)
        {
            _.Delete(id);
        }

        #endregion
    }
}
