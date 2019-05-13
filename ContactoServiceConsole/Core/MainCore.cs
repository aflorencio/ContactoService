using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactoServiceConsole.Core
{

    public class MainCoreContacto
    {
        #region CREATE

        public string CreateContacto(Core.DB.Models.ContactoDBModel data)
        {

            Core.DB.Query.ContactoQuery qCreate = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            //qCreate.Create(data); //El metodo antiguo que funciona
            qCreate.InsertUser(data);//Nuevo metodo
            return "OK!";
        }

        #endregion

        #region READ
        public List<Core.DB.Models.ContactoDBModel> ReadAll()
        {
            Core.DB.Query.ContactoQuery qReadAll = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            //qCreate.Create(data); //El metodo antiguo que funciona
            return qReadAll.GetAllUsers();//Nuevo metodo
                                          //var id = new MongoDB.Bson.ObjectId("5ca1c4092db24f0bf08ce0f7");
                                          //var hola = qCreate.DeleteUserById(id);
        }
        // FALTA ES BUSCAR POR CAMPO? ESTA EN QUERY       

        public Core.DB.Models.ContactoDBModel ReadId(string id)
        {

            Core.DB.Query.ContactoQuery qReadId = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersById(id);
            return data;
        }

        public List<Core.DB.Models.ContactoDBModel> ReadValue(string fieldName, string fieldValue)
        {
            Core.DB.Query.ContactoQuery qReadId = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");

            var data = qReadId.GetUsersByField(fieldName, fieldValue);
            return data;

        }
        #endregion

        #region UPDATE
        public void Update(string id, string updateFieldName, string updateFieldValue)
        {

            Core.DB.Query.ContactoQuery qUpdate = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");
            qUpdate.UpdateUser(id, updateFieldName, updateFieldValue);

        }

        #endregion

        #region DELETE

        public void Delete(string id)
        {
            Core.DB.Query.ContactoQuery qDelete = new Core.DB.Query.ContactoQuery("mongodb://51.83.73.69:27017");
            qDelete.DeleteUserById(id);
        }

        #endregion
    }

}
