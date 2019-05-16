using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactoServiceConsole.Core.DB.Models
{
    [BsonIgnoreExtraElements]
    public class ContactoDBModel
    {
        public ObjectId _id { get; set; }
        [BsonIgnoreIfNull]
        public string nombre { get; set; }
        [BsonIgnoreIfNull]
        public string apellidos { get; set; }
        [BsonIgnoreIfNull]
        public string telefono1 { get; set; }
        [BsonIgnoreIfNull]
        public string telefono2 { get; set; }
        [BsonIgnoreIfNull]
        public string email1 { get; set; }
        [BsonIgnoreIfNull]
        public string email2 { get; set; }
        [BsonIgnoreIfNull]
        public string dni { get; set; }
        [BsonIgnoreIfNull]
        public string cif { get; set; }
        [BsonIgnoreIfNull]
        public string municipio { get; set; }
        [BsonIgnoreIfNull]
        public string direccion { get; set; }
        [BsonIgnoreIfNull]
        public string codPostal { get; set; }
        [BsonIgnoreIfNull]
        public string provincia { get; set; }
        [BsonIgnoreIfNull]
        public string pais { get; set; }
        [BsonIgnoreIfNull]
        public string lang { get; set; }
        [BsonIgnoreIfNull]
        public string langNative { get; set; }
        [BsonIgnoreIfNull]
        public string comercialAsignado { get; set; }
        [BsonIgnoreIfNull]
        public string particularEmpresa { get; set; }
        [BsonIgnoreIfNull]
        public string descripcionCaso { get; set; }
        [BsonIgnoreIfNull]
        public bool recibidoPorSecretaria { get; set; }
        [BsonIgnoreIfNull]
        public string fuentePosibleCliente { get; set; }
        [BsonIgnoreIfNull]
        public string rol { get; set; } = "contacto";
        [BsonIgnoreIfNull]
        public bool tomaContacto { get; set; } = false;

    }
}