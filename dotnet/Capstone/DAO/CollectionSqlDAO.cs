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
        private string sqlGetCollections = "SELECT * FROM collections WHERE user_id = @id;";

        public CollectionSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Collection> GetCollections()
        {
            List<Collection> collections = new List<Collection>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCollections, conn);

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

        private Collection ReaderToCollections(SqlDataReader reader)
        {
            Collection collection = new Collection();
            collection.Id = Convert.ToInt32(reader["id"]);
            collection.Name = Convert.ToString(reader["collection_name"]);
            collection.UserId = Convert.ToInt32(reader["user_id"]);
            return collection;
        }

    }
}
