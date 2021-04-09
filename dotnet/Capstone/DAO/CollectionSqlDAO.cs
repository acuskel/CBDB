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
        private string sqlGetIssues = "SELECT * FROM ISSUES i JOIN collections_issues ci ON ci.issue_id = i.id JOIN collections c ON c.id = ci.collection_id WHERE ci.collection_id = @collectionId;";
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
            issue.ReleaseDate = Convert.ToDateTime(reader["release_date"]);
            issue.ISBN = Convert.ToInt32(reader["ISBN"]);
            issue.UPC = Convert.ToInt32(reader["UPC"]);
            issue.Summary = Convert.ToString(reader["summary"]);
            issue.CoverLink = Convert.ToString(reader["cover_link"]);
            issue.Publisher = Convert.ToString(reader["publisher"]);
            issue.IssueNumber = Convert.ToInt32(reader["issue_number"]);
            issue.StoryTitle = Convert.ToString(reader["story_title"]);
            issue.StoryArcName = Convert.ToString(reader["story_arc_name"]);
            issue.Characters = Convert.ToString(reader["characters"]);
            issue.BioLink = Convert.ToString(reader["bio_link"]);
            issue.Genre = Convert.ToString(reader["genre"]);
            issue.PageCount = Convert.ToDecimal(reader["page_count"]);
            issue.Country = Convert.ToString(reader["country"]);
            issue.Language = Convert.ToString(reader["language"]);
            issue.CreatorBio = Convert.ToString(reader["creator_bio"]);
            issue.PublicationType = Convert.ToString(reader["publication_type"]);
            return issue;
        }
    }
}
