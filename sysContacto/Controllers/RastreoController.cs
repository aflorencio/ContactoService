using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace sysContacto.Controllers
{
    public class RastreoController : ApiController
    {
        private sysContacto.Core.MainCoreRastreo _ = new sysContacto.Core.MainCoreRastreo();

        // GET: api/Rastreo
        [HttpGet]
        [Route("api/Rastreo")]
        public List<sysContacto.Core.DB.Models.RastreoDBModel> Get()
        {
            var data = _.ReadAll();

            return data;
        }

        // GET: api/Rastreo/5
        [HttpGet]
        [Route("api/Rastreo/{id}")]
        public sysContacto.Core.DB.Models.RastreoDBModel Get(string id)
        {
            var data = _.ReadId(id);
            return data;
        }

        //GET: api/contacto/nombre/valor
        [HttpGet]
        [Route("api/Rastreo/{fieldName}/{fieldValue}")]
        public List<sysContacto.Core.DB.Models.RastreoDBModel> Get(string fieldName, string fieldValue)
        {
            return _.ReadValue(fieldName, fieldValue);
        }

        // POST: api/Rastreo
        [HttpPost]
        [Route("api/Rastreo")]
        public string Post(FormDataCollection value)
        {
            sysContacto.Core.DB.Models.RastreoDBModel data = new sysContacto.Core.DB.Models.RastreoDBModel();
            data.contactoID = ObjectId.Parse(value.Get("contactoID"));
            data.keyWord = value.Get("keyWord");
            data.comentario = value.Get("comentario");
            data.finalizado = value.Get("finalizado") == "true" ? true : false;
            data.solicitarRastreo = value.Get("solicitarRastreo") == "true" ? true : false;

            #region LINKS code
            //sysContacto.Core.DB.Models.Link linkes = new sysContacto.Core.DB.Models.Link(); // Creamos un modelo de datos para la lista.

            //linkes.url = "http://www.gooogle.es";
            //linkes.comentario = "En el link algo va mal";
            //linkes.categoria = "B";
            //linkes.status = "NON";
            //linkes.originalPDF = "DIR/";
            //linkes.finalPDF = "DIRDIR/";
            //linkes._id = ObjectId.GenerateNewId();
      
            //data.links = new List<sysContacto.Core.DB.Models.Link>(); // Declaro una nueva lista ya que esta ésta no esta declarada.

            //data.links.Add(linkes);
            #endregion

            _.CrearRastreo(data);
            return "OK";
        }
        // POST: api/RastreoAddLink/ID
        [HttpPost]
        [Route("api/Rastreo/{id}")]
        public string Post(string id, FormDataCollection value)
        { 
    
            sysContacto.Core.DB.Models.Link linkes = new sysContacto.Core.DB.Models.Link(); // Creamos un modelo de datos para la lista.

            linkes.url = value.Get("keyWord");
            linkes.comentario = value.Get("comentario");
            linkes.categoria = value.Get("categoria");
            linkes.status = value.Get("status");
            linkes.originalPDF = value.Get("originalPDF");
            linkes.finalPDF = value.Get("finalPDF");
            linkes._id = ObjectId.GenerateNewId();

            _.AddLink(linkes, id);
            return "OK";
        }

        // PUT: api/Rastreo/5
        [HttpPut]
        [Route("api/Rastreo/{id}")]
        public string Put(string id, FormDataCollection value)
        {
            var name = value.FirstOrDefault().Key.ToString();
            var valor = value.FirstOrDefault().Value.ToString();
            sysContacto.Core.DB.Models.RastreoDBModel obj = new sysContacto.Core.DB.Models.RastreoDBModel();
            var existeMetodo = obj.GetType().GetProperty(name) == null ? false : true;
            if (existeMetodo == true)
            {
                _.Update(id, name, valor);
                return "OK!";
            }

            return "Error";
        }

        // DELETE: api/Rastreo/5
        [HttpDelete]
        [Route("api/Rastreo/{id}")]
        public void Delete(string id)
        {
            _.Delete(id);
        }
    }
}
