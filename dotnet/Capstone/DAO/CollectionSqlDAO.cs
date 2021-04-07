using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CollectionSqlDAO : ICollectionDAO
    {
        private string connectionString;
        private string sqlGetCollections = "SELECT * FROM collections WHERE user_id = @userId;";
        private string sqlAddCollection = "INSERT INTO collections(collection_name, user_id, is_public) VALUES(@collectionName, @userId, @isPublic)";
        private string sqlGetPublicCollection = "SELECT * FROM collections WHERE is_public = 1;";

        public CollectionSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Collection> GetCollections(int userId)
        {
            List<Collection> collections = new List<Collection>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCollections, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Collection collection = ReaderToCollections(reader);
                        collections.Add(collection);
                    }
                }
            }
            catch (Exception ex)
            {
                collections = new List<Collection>();
            }

            return collections;
        }
        public List<Collection> GetPublicCollections()
        {
            List<Collection> collections = new List<Collection>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetPublicCollection, conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Collection collection = ReaderToPublicCollections(reader);
                        collections.Add(collection);
                    }
                }
            }
            catch (Exception ex)
            {
                collections = new List<Collection>();
            }

            return collections;
        }
        public bool AddCollection(Collection collection)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddCollection, conn);
                    cmd.Parameters.AddWithValue("@collectionName", collection.Name);
                    cmd.Parameters.AddWithValue("@userId", collection.UserId);
                    cmd.Parameters.AddWithValue("@isPublic", collection.IsPublic);


                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }




        private Collection ReaderToCollections(SqlDataReader reader)
        {
            Collection collection = new Collection();
            collection.Id = Convert.ToInt32(reader["id"]);
            collection.Name = Convert.ToString(reader["collection_name"]);
            collection.UserId = Convert.ToInt32(reader["user_id"]);
            collection.IsPublic = Convert.ToBoolean(reader["is_public"]);
            return collection;
        }

        private Collection ReaderToPublicCollections(SqlDataReader reader)
        {
            Collection collection = new Collection();
            collection.Id = Convert.ToInt32(reader["id"]);
            collection.Name = Convert.ToString(reader["collection_name"]);
            collection.UserId = Convert.ToInt32(reader["user_id"]);
            collection.IsPublic = Convert.ToBoolean(reader["is_public"]);
            return collection;
        }
    }
}
