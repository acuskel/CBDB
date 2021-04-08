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
        private string sqlAddIssue = "INSERT INTO issues(issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES(@issueTitle, @seriesTitle, @releaseDate, @isbn, @upc, @summary, @coverLink, @publisher) INSERT INTO collections_issues (collection_id, issue_id) VALUES (@collectionId, (SELECT MAX(id) FROM issues))";
        private string sqlGetIssue = "SELECT * FROM issues i WHERE i.id = @issueID;";
        public IssueSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool AddIssue(Issue issue, int collectionId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddIssue, conn);
                    cmd.Parameters.AddWithValue("@issueTitle", issue.Title);
                    cmd.Parameters.AddWithValue("@seriesTitle", issue.SeriesTitle);
                    cmd.Parameters.AddWithValue("@releaseDate", issue.UPC);
                    cmd.Parameters.AddWithValue("@isbn", issue.ISBN);
                    cmd.Parameters.AddWithValue("@upc", issue.Summary);
                    cmd.Parameters.AddWithValue("@summary", issue.Publisher);
                    cmd.Parameters.AddWithValue("@coverLink", issue.CoverLink);
                    cmd.Parameters.AddWithValue("@publisher", issue.ReleaseDate);
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
                result = false;
            }
            return result;
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
            issue.ISBN = Convert.ToInt32(reader["ISBN"]);
            issue.UPC = Convert.ToInt32(reader["UPC"]);
            issue.Summary = Convert.ToString(reader["summary"]);
            issue.CoverLink = Convert.ToString(reader["cover_link"]);
            issue.Publisher = Convert.ToString(reader["publisher"]);
            issue.ReleaseDate = Convert.ToDateTime(reader["release_date"]);
            return issue;
        }



    }
}
