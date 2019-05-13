using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactoServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("     C O N T A C T O   S E R V I C E   v0.1.0.1 ");
            Console.ReadLine();

            using (var server = new RestServer())
            {
                server.Port = "5001";
                server.LogToConsole().Start();
                Console.ReadLine();
                server.Stop();
            }

        }
    }

    [RestResource]
    public class TestResource
    {
        #region GET
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/api/contacto")]
        public IHttpContext ReadAllContacto(IHttpContext context)
        {
            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var data = _.ReadAll();

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/api/readone")]
        public IHttpContext ReadOneContacto(IHttpContext context)
        {
            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var id = context.Request.QueryString["id"] ?? "what?"; //Si no id dara error
            var data = _.ReadId(id);

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }
        #endregion

        #region POST

        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/api/addContacto")]
        public IHttpContext AddContacto(IHttpContext context)
        {
            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            string jsonRAW = context.Request.Payload;
            dynamic dataId = JsonConvert.DeserializeObject<object>(jsonRAW);

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

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }

        #endregion

        #region PUT

        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/api/updatecontacto")]
        public IHttpContext UpdateContacto(IHttpContext context)
        {
            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var id = context.Request.QueryString["id"] ?? "what?"; //Si no id dara error
            var data = _.ReadId(id);

            var name = context.Request.QueryString["name"] ?? "what?";
            var valor = context.Request.QueryString["value"] ?? "what?";

            Core.DB.Models.ContactoDBModel obj = new Core.DB.Models.ContactoDBModel();
            var existeMetodo = obj.GetType().GetProperty(name) == null ? false : true;
            if (existeMetodo == true)
            {
                _.Update(id, name, valor);
                context.Response.SendResponse("Updated!");
                return context;
            }

            context.Response.SendResponse("Error!");
            return context;
        }


        #endregion

        #region DELETE

        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/api/contacto/delete")]
        public IHttpContext DeleteContacto(IHttpContext context)
        {
            Core.MainCoreContacto _ = new Core.MainCoreContacto();

            var id = context.Request.QueryString["id"] ?? "what?"; //Si no id dara error

            _.Delete(id);

            context.Response.SendResponse("Deleted!");
            return context;
        }


        #endregion

        [RestRoute]
        public IHttpContext HelloWorld(IHttpContext context)
        {
            context.Response.SendResponse("ContactoService.");
            return context;
        }
    }
}
