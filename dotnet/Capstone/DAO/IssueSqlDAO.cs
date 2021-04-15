using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class IssueSqlDAO : IIssueDAO
    {
        private string connectionString;
        //private string sqlCreateIssue = "INSERT INTO issues(issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES(@issueTitle, @seriesTitle, @releaseDate, @isbn, @upc, @summary, @coverLink, @publisher) INSERT INTO collections_issues (collection_id, issue_id) VALUES (@collectionId, (SELECT MAX(id) FROM issues))";
        private string sqlAddIssue = "INSERT INTO collections_issues(collection_id, issue_id) VALUES (@collectionId, @issueId)";
        private string sqlGetIssue = "SELECT * FROM issues i WHERE i.id = @issueID;";
        private string sqlGetAllIssues = "SELECT * FROM issues ORDER BY series_title;";
        public IssueSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool AddIssue(int issueId, int collectionId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddIssue, conn);
                    cmd.Parameters.AddWithValue("@issueId", issueId);
                    cmd.Parameters.AddWithValue("@collectionId", collectionId);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public List<Issue> GetAllIssues()
        {
            List<Issue> allIssues = new List<Issue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetAllIssues, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Issue issue = ReaderToIssues(reader);
                        allIssues.Add(issue);
                    }
                }
            }
            catch (Exception ex)
            {
                allIssues = new List<Issue>();
            }

            return allIssues;
        }

        public Issue GetIssue(int issueId)
        {
            Issue issue = new Issue();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetIssue, conn);
                    cmd.Parameters.AddWithValue("@issueId", issueId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        issue = ReaderToIssues(reader);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                issue = new Issue();
                throw (ex);
            }
            return issue;
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

        //public bool CreateIssue(Issue issue, int collectionId)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(sqlAddIssue, conn);
        //            cmd.Parameters.AddWithValue("@issueTitle", issue.Title);
        //            cmd.Parameters.AddWithValue("@seriesTitle", issue.SeriesTitle);
        //            cmd.Parameters.AddWithValue("@creator", issue.Creator);
        //            cmd.Parameters.AddWithValue("@releaseDate", issue.ReleaseDate);
        //            cmd.Parameters.AddWithValue("@isbn", issue.ISBN);
        //            cmd.Parameters.AddWithValue("@upc", issue.UPC);
        //            cmd.Parameters.AddWithValue("@summary", issue.Summary);
        //            cmd.Parameters.AddWithValue("@coverLink", issue.CoverLink);
        //            cmd.Parameters.AddWithValue("@publisher", issue.Publisher);
        //            cmd.Parameters.AddWithValue("@issueNumber", issue.IssueNumber);
        //            cmd.Parameters.AddWithValue("@storyTitle", issue.StoryTitle);
        //            cmd.Parameters.AddWithValue("@storyArcName", issue.StoryArcName);
        //            cmd.Parameters.AddWithValue("@characters", issue.Characters);
        //            cmd.Parameters.AddWithValue("@bioLink", issue.BioLink);
        //            cmd.Parameters.AddWithValue("@genre", issue.Genre);
        //            cmd.Parameters.AddWithValue("@pageCount", issue.PageCount);
        //            cmd.Parameters.AddWithValue("@country", issue.Country);
        //            cmd.Parameters.AddWithValue("@language", issue.Language);
        //            cmd.Parameters.AddWithValue("@creatorBio", issue.CreatorBio);
        //            cmd.Parameters.AddWithValue("@publicationType", issue.PublicationType);
        //            cmd.Parameters.AddWithValue("@collectionId", collectionId);

        //            int count = cmd.ExecuteNonQuery();

        //            if (count > 0)
        //            {
        //                result = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        result = false;
        //    }
        //    return result;
        //}



    }
}
