using System.Data; 
using System.Globalization; 
using Microsoft.Data.Sqlite;

namespace HcsBudget.Models.DbConnections
{
    public abstract class BaseDbConnection
    {
        private string PathToDb { get; set; } 

        protected void SetPathToDb()
        {
            try
            {
                PathToDb = "data/app.db"; 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        protected DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = PathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = sql; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        return dt;
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
        }

        protected string ToTitleCase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower()); 
        }
    }
}