using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace sysContacto.Core.DB.Query
{
    public class ContactoQuery
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<sysContacto.Core.DB.Models.ContactoDBModel> _usersCollection;

        //public void Create(sysContacto.Core.DB.Models.ContactoDBModel data)
        //{
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("foo");
        //    var collection = database.GetCollection<sysContacto.Core.DB.Models.ContactoDBModel>("bar"); //Puedo usar un modelo propio o un BSON para poder manejar los datos en caso de usar bson usar las lineas comentadas abajo.
        //    //var document = new BsonDocument
        //    //{
        //    //    { "name", "MongoDB" },
        //    //    { "type", "Database" },
        //    //    { "count", 1 },
        //    //    { "info", new BsonDocument
        //    //        {
        //    //            { "x", 203 },
        //    //            { "y", 102 }
        //    //        }}
        //    //};


        //    //collection.InsertOne(new sysContacto.Core.Models.Contacto { nombre = name });
        //    collection.InsertOne(data);
        //} //ESTE ES EL ANTIGUO QUE FUNCIONABA

        public ContactoQuery(string connectionString) //COSNTRUCTOR 
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("ContactoService");
            _usersCollection = _database.GetCollection<sysContacto.Core.DB.Models.ContactoDBModel>("contacto");
        }

        #region CREATE

        public async Task InsertUser(sysContacto.Core.DB.Models.ContactoDBModel user) //CREATE
        {
            user._id = ObjectId.GenerateNewId();
            await _usersCollection.InsertOneAsync(user);
        }

        #endregion

        #region READ

        public List<sysContacto.Core.DB.Models.ContactoDBModel> GetAllUsers()
        {
            return _usersCollection.Find(new BsonDocument()).ToList();
        }

        public List<sysContacto.Core.DB.Models.ContactoDBModel> GetUsersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq(fieldName, fieldValue);
            var result =  _usersCollection.Find(filter).ToList();

            return result;
        }

        public sysContacto.Core.DB.Models.ContactoDBModel GetUsersById(string id)
        {
            //var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            //var data = _usersCollection.Find(filter).FirstOrDefault();
            //return data;          
            try
            {
                var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var data = _usersCollection.Find(filter).FirstOrDefault();
                return data;
            }
            catch {
                return null;
            }
        }

        public List<sysContacto.Core.DB.Models.ContactoDBModel> GetUsers(int startingFrom, int count)
        {
            var result =  _usersCollection.Find(new BsonDocument())
            .Skip(startingFrom)
            .Limit(count)
            .ToList();

            return result;
        }

        #endregion

        #region UPDATE

        public bool UpdateUser(string id, string udateFieldName, string updateFieldValue)
        {
            var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Update.Set(udateFieldName, updateFieldValue);

            var result = _usersCollection.UpdateOne(filter, update);

            return result.ModifiedCount != 0;
        }

        #endregion

        #region DELETE

        public bool DeleteUserById(string id)
        {
            var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _usersCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }

        #endregion
    }
}