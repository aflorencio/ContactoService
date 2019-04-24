using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace sysContacto.Core.DB.Query
{
    public class RastreoQuery
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<sysContacto.Core.DB.Models.RastreoDBModel> _rastreoCollection;

        public RastreoQuery(string connectionString) //COSNTRUC
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("foo");
            _rastreoCollection = _database.GetCollection<sysContacto.Core.DB.Models.RastreoDBModel>("rastreos");
        }

        #region CREATE

        public async Task CrearRastreo(sysContacto.Core.DB.Models.RastreoDBModel user) //CREATE
        {
            await _rastreoCollection.InsertOneAsync(user);
        }

        public async Task AddLink(sysContacto.Core.DB.Models.Link dataLink, string id) {

            //var filter = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            //var update = Builders<sysContacto.Core.DB.Models.ContactoDBModel>.Update.Set(udateFieldName, updateFieldValue);

            //var result = _usersCollection.UpdateOne(filter, update);

            //return result.ModifiedCount != 0;


            var filter = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Filter.Eq(e => e._id, ObjectId.Parse(id));

            var update = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Update.Push<sysContacto.Core.DB.Models.Link>(e => e.links, dataLink);

            await _rastreoCollection.FindOneAndUpdateAsync(filter, update);

        }

        #endregion

        #region READ

        public List<sysContacto.Core.DB.Models.RastreoDBModel> GetAllUsers()
        {
            return _rastreoCollection.Find(new BsonDocument()).ToList();
        }

        public sysContacto.Core.DB.Models.RastreoDBModel GetUsersById(string id)
        {
            try
            {
                var filter = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var data = _rastreoCollection.Find(filter).FirstOrDefault();
                return data;
            }
            catch
            {
                return null;
            }
        }

        public List<sysContacto.Core.DB.Models.RastreoDBModel> GetUsersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Filter.Eq(fieldName, fieldValue);
            var result = _rastreoCollection.Find(filter).ToList();

            return result;
        }

        #endregion

        #region UPDATE

        public bool UpdateRasteo(string id, string udateFieldName, string updateFieldValue)
        {
            var filter = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Update.Set(udateFieldName, updateFieldValue);

            var result = _rastreoCollection.UpdateOne(filter, update);

            return result.ModifiedCount != 0;
        }

        #endregion

        #region DELETE

        public bool DeleteUserById(string id)
        {
            var filter = Builders<sysContacto.Core.DB.Models.RastreoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _rastreoCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }


        #endregion
    }
}