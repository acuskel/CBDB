using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class StatisticsDAO : IStatisticsDAO
    {
        private string connectionString;
        private string sqlGetStatitistics = "SELECT avg(issues) as 'avgNumIssues', max(issues) as 'largestUserCollection', max(users) as 'numberOfUsers', max(collections) as 'mostCollectionsByUser' FROM (SELECT  count(c.id) 'Collections', COUNT(i.id) 'Issues', max(u.user_id) 'Users' from  collections c JOIN users u ON u.user_id = c.user_id JOIN collections_issues ci ON ci.collection_id = c.id JOIN issues i ON i.id = ci.issue_id GROUP BY c.id) AS averages;";
        public StatisticsDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Statistics GetStatistics()
        {
            Statistics stats = new Statistics();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetStatitistics, conn);
                 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        stats = ReaderToStatistics(reader);

                    }
                }
            }
            catch (Exception ex)
            {
                stats = new Statistics();
                throw (ex);
            }
            return stats;
        }

        private Statistics ReaderToStatistics(SqlDataReader reader)
        {
            Statistics stats = new Statistics();
            stats.AverageNumberOfIssues = Convert.ToInt32(reader["avgNumIssues"]);
            stats.LargestUserCollection = Convert.ToInt32(reader["largestUserCollection"]);
            stats.NumberOfUsers = Convert.ToInt32(reader["numberOfUsers"]);
            stats.MostCollectionsByUser = Convert.ToInt32(reader["mostCollectionsByUser"]);
            return stats;
        }
    }
}
