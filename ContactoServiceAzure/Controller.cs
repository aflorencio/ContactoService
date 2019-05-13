using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ContactoServiceAzure
{
    public static class Controller
    {
        #region GET
        [FunctionName("ReadAllContacto")]
        public static async Task<HttpResponseMessage> ReadAllContacto([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            //// parse query parameter
            //string name = req.GetQueryNameValuePairs()
            //    .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
            //    .Value;

            //if (name == null)
            //{
            //    // Get request body
            //    dynamic data = await req.Content.ReadAsAsync<object>();
            //    name = data?.name;
            //}

            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var data = _.ReadAll();

            return req.CreateResponse(HttpStatusCode.OK, data);


            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }

        [FunctionName("ReadOneContacto")]
        public static async Task<HttpResponseMessage> ReadOneContacto([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string id = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "id", true) == 0)
                .Value;

            if (id == null)
            {
                // Get request body
                dynamic dataId = await req.Content.ReadAsAsync<object>();
                id = dataId?.name;
            }

            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var data = _.ReadId(id);

            return req.CreateResponse(HttpStatusCode.OK, data);

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
        #endregion

        #region POST

        [FunctionName("CreateContacto")]
        public static async Task<HttpResponseMessage> CreateContacto([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            #region request
            //log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string id = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "id", true) == 0)
                .Value;


            // Get request body
            dynamic dataId = await req.Content.ReadAsAsync<object>();

            #endregion

            Core.MainCoreContacto _ = new Core.MainCoreContacto();
            Core.DB.Models.ContactoDBModel data = new Core.DB.Models.ContactoDBModel();

            data.nombre = dataId?.nombre;
            data.apellidos = dataId?.apellidos;
            data.telefono1 = dataId?.telefono1;
            data.telefono2 = dataId?.telefono2;
            data.email1 = dataId?.email1;
            data.email2 = dataId?.email2;
            data.dni = dataId?.dni;
            data.cif = dataId?.cif;
            data.municipio = dataId?.municipio;
            data.direccion = dataId?.direccion;
            data.codPostal = dataId?.codPostal;
            data.provincia = dataId?.provincia;
            data.pais = dataId?.pais;
            data.lang = dataId?.lang;
            data.langNative = dataId?.langNative;
            data.comercialAsignado = dataId?.comercialAsignado;
            data.particularEmpresa = dataId?.particularEmpresa;
            data.descripcionCaso = dataId?.descripcionCaso;
            data.recibidoPorSecretaria = dataId?.recibidoPorSecretaria == "true" ? true : false;
            data.fuentePosibleCliente = dataId?.fuentePosibleCliente;
            data.rol = dataId?.rol;


            _.CreateContacto(data);

            return req.CreateResponse(HttpStatusCode.OK, "OK!");

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }

        #endregion
    }
}
