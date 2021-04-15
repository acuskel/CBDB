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
        //Get Issues By CollectionID
        private string sqlGetIssues = "SELECT * FROM issues i JOIN collections_issues ci ON ci.issue_id = i.id JOIN collections c ON c.id = ci.collection_id WHERE ci.collection_id = @collectionId;";
        private string sqlDeleteCollection = "DELETE FROM collections where id = @collection_id; DELETE FROM collections_issues where collection_id = @collection_id;";

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
                        collection.Issues = GetIssues(collection.Id);
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

        public bool DeleteCollection(int collectionId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteCollection, conn);
                    cmd.Parameters.AddWithValue("@collection_id", collectionId);

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

        public List<Issue> GetIssues(int collectionId)
        {
            List<Issue> issues = new List<Issue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetIssues, conn);
                    cmd.Parameters.AddWithValue("@collectionId", collectionId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Issue issue = ReaderToIssues(reader);
                        issues.Add(issue);
                    }
                }
            }
            catch (Exception ex)
            {
                issues = new List<Issue>();
                throw ex;
            }

            return issues;
        }


        private Collection ReaderToCollections(SqlDataReader reader)
        {
            Collection collection = new Collection();
            collection.Id = Convert.ToInt32(reader["id"]);
            collection.Name = Convert.ToString(reader["collection_name"]);
            collection.UserId = Convert.ToInt32(reader["user_id"]);
            collection.IsPublic = Convert.ToBoolean(reader["is_public"]);
            collection.CoverLink = Convert.ToString(reader["cover_link"]);
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
        private Issue ReaderToIssues(SqlDataReader reader)
        {
            Issue issue = new Issue();
            issue.IssueId = Convert.ToInt32(reader["id"]);
            issue.Title = Convert.ToString(reader["issue_title"]);
            issue.SeriesTitle = Convert.ToString(reader["series_title"]);
            issue.ReleaseDate = Convert.ToString(reader["release_date"]);
            issue.ISBN = Convert.ToString(reader["ISBN"]);
            issue.UPC = Convert.ToString(reader["UPC"]);
            issue.Summary = Convert.ToString(reader["summary"]);
            issue.CoverLink = Convert.ToString(reader["cover_link"]);
            issue.Publisher = Convert.ToString(reader["publisher"]);
            issue.IssueNumber = Convert.ToString(reader["issue_number"]);
            issue.Characters = Convert.ToString(reader["characters"]);
            issue.Creator = Convert.ToString(reader["author_name"]);
            issue.PageCount = Convert.ToInt32(reader["page_count"]);
            issue.SeriesId = Convert.ToInt32(reader["series_id"]);
            return issue;
        }
    }
}
