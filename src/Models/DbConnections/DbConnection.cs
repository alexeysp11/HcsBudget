using System.Collections.Generic; 
using System.Data; 
using HcsBudget.Models; 
using HcsBudget.ViewModels; 

namespace HcsBudget.Models.DbConnections
{
    public class DbConnection : BaseDbConnection, IHcsDbConnection, IStateDbConnection
    {
        public void InsertCurrentDate(int month, int year)
        {
            string sqlRequest = @$"
                INSERT INTO period (month, year) 
                SELECT {month}, {year}
                WHERE
                (
                    SELECT COUNT(*)
                    FROM period
                    WHERE month = {month} AND year = {year}
                ) = 0; 
            "; 
            try 
            {
                SetPathToDb(); 
                GetDataTable(sqlRequest); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<Month> GetMonths()
        {
            List<Month> result = new List<Month>(); 
            try 
            {
                SetPathToDb(); 
                string sqlRequest = System.IO.File.ReadAllText("src/SQL/GetMonths.sql"); 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new Month(
                        System.Convert.ToInt32(row["period_id"]), 
                        System.Convert.ToInt32(row["month_no"]), 
                        System.Convert.ToInt32(row["year"]), 
                        ToTitleCase(row["english"].ToString().ToLower()), 
                        ToTitleCase(row["german"].ToString().ToLower()), 
                        ToTitleCase(row["russian"].ToString().ToLower()), 
                        ToTitleCase(row["spanish"].ToString().ToLower()), 
                        ToTitleCase(row["portugues"].ToString().ToLower()), 
                        ToTitleCase(row["french"].ToString().ToLower()), 
                        ToTitleCase(row["italian"].ToString().ToLower())
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public List<Hcs> GetHcs(int periodId)
        {
            List<Hcs> result = new List<Hcs>(); 
            try 
            {
                SetPathToDb(); 
                string sqlRequest = @$"
                    SELECT 
                        hcs.name AS hcs_name, 
                        hcs.qty, 
                        hcs.price_usd, 
                        GROUP_CONCAT(pt.name) AS participant_name, 
                        hcs.qty * hcs.price_usd AS total_price, 
                        p.month, 
                        p.year
                    FROM hcs
                    INNER JOIN period p ON p.period_id = hcs.period_id
                    INNER JOIN hcs_participant hcsp ON hcsp.hcs_id = hcs.hcs_id
                    INNER JOIN participant pt ON pt.participant_id = hcsp.participant_id
                    WHERE p.period_id = {periodId}
                    GROUP BY hcs_name, qty, price_usd, total_price, month, year
                    ORDER BY hcs_name
                ";
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new Hcs(
                        ToTitleCase(row["hcs_name"].ToString().ToLower()),
                        System.Convert.ToSingle(row["qty"]), 
                        System.Convert.ToSingle(row["price_usd"]), 
                        ToTitleCase(row["participant_name"].ToString().ToLower()),
                        System.Convert.ToSingle(row["total_price"]), 
                        System.Convert.ToInt32(row["month"]), 
                        System.Convert.ToInt32(row["year"])
                    )); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public void GetDistinctYears(ref List<int> years)
        {
            try 
            {
                SetPathToDb(); 
                string sqlRequest = $"SELECT DISTINCT year FROM period"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    years.Add(System.Convert.ToInt32(row["year"])); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }

        public List<string> SelectAllParticipants()
        {
            List<string> result = new List<string>();
            try 
            {
                SetPathToDb(); 
                string sqlRequest = $"SELECT name FROM participant"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(ToTitleCase(row["name"].ToString().ToLower())); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }

        public List<string> SelectAllHcs()
        {
            List<string> result = new List<string>();
            try 
            {
                SetPathToDb(); 
                string sqlRequest = $"SELECT name FROM hcs"; 
                DataTable dt = GetDataTable(sqlRequest); 
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(ToTitleCase(row["name"].ToString().ToLower())); 
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
            return result; 
        }
    }
}