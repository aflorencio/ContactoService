using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sysContacto.Core
{
    public class MainCoreContacto
    {
        #region CREATE

        public string CreateContacto(sysContacto.Core.DB.Models.ContactoDBModel data) {

            sysContacto.Core.DB.Query.ContactoQuery qCreate = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            //qCreate.Create(data); //El metodo antiguo que funciona
            qCreate.InsertUser(data);//Nuevo metodo
            return "OK!";
        }

        #endregion

        #region READ
        public List<sysContacto.Core.DB.Models.ContactoDBModel> ReadAll()
        {
            sysContacto.Core.DB.Query.ContactoQuery qReadAll = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            //qCreate.Create(data); //El metodo antiguo que funciona
            return qReadAll.GetAllUsers();//Nuevo metodo
            //var id = new MongoDB.Bson.ObjectId("5ca1c4092db24f0bf08ce0f7");
            //var hola = qCreate.DeleteUserById(id);
        }
        // FALTA ES BUSCAR POR CAMPO? ESTA EN QUERY       

        public sysContacto.Core.DB.Models.ContactoDBModel ReadId(string id) {

            sysContacto.Core.DB.Query.ContactoQuery qReadId = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersById(id);
            return data;
        }

        public List<sysContacto.Core.DB.Models.ContactoDBModel> ReadValue(string fieldName, string fieldValue) {
            sysContacto.Core.DB.Query.ContactoQuery qReadId = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersByField(fieldName, fieldValue);
            return data;

        }
        #endregion

        #region UPDATE
        public void Update(string id, string updateFieldName, string updateFieldValue) {

            sysContacto.Core.DB.Query.ContactoQuery qUpdate = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");
            qUpdate.UpdateUser(id, updateFieldName, updateFieldValue);

        }

        #endregion

        #region DELETE

        public void Delete(string id) {
            sysContacto.Core.DB.Query.ContactoQuery qDelete = new sysContacto.Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");
            qDelete.DeleteUserById(id);
        }

        #endregion
    }

    public class MainCoreRastreo {

        #region CREATE

        public void CrearRastreo(sysContacto.Core.DB.Models.RastreoDBModel data) {

            sysContacto.Core.DB.Query.RastreoQuery qCreate = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");
            qCreate.CrearRastreo(data);

        }

        public void AddLink(sysContacto.Core.DB.Models.Link link, string rastreoID) {

            sysContacto.Core.DB.Query.RastreoQuery qAddLink = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");
            qAddLink.AddLink(link, rastreoID);

        }

        #endregion

        #region READ

        public List<sysContacto.Core.DB.Models.RastreoDBModel> ReadAll()
        {
            sysContacto.Core.DB.Query.RastreoQuery qReadAll = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");

            return qReadAll.GetAllUsers();
        }

        public sysContacto.Core.DB.Models.RastreoDBModel ReadId(string id)
        {

            sysContacto.Core.DB.Query.RastreoQuery qReadId = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersById(id);
            return data;
        }

        public List<sysContacto.Core.DB.Models.RastreoDBModel> ReadValue(string fieldName, string fieldValue)
        {
            sysContacto.Core.DB.Query.RastreoQuery qReadId = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersByField(fieldName, fieldValue);
            return data;

        }

        #endregion

        #region UPDATE

        public void Update(string id, string updateFieldName, string updateFieldValue) {

            sysContacto.Core.DB.Query.RastreoQuery qUpdate = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");
            qUpdate.UpdateRasteo(id, updateFieldName, updateFieldValue);

        }

        #endregion

        #region DELETE

        public void Delete(string id)
        {
            sysContacto.Core.DB.Query.RastreoQuery qDelete = new sysContacto.Core.DB.Query.RastreoQuery("mongodb://51.83.73.69:27017");
            qDelete.DeleteUserById(id);
        }

        #endregion

    }

    public class MainCorePresupuesto
    {

    }

    public class MainCoreDocumentos {

    }
}