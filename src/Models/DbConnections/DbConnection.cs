using System.Collections.Generic; 
using System.Data; 
using HcsBudget.Models; 
using HcsBudget.ViewModels; 

namespace HcsBudget.Models.DbConnections
{
    public class DbConnection : BaseDbConnection, IHcsDbConnection, IStateDbConnection
    {
        public List<Month> GetMonths(int month, int year)
        {
            List<Month> result = new List<Month>(); 

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
                sqlRequest += System.IO.File.ReadAllText("src/SQL/Months.sql"); 
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

        public void GetHcs(ref List<Month> months)
        {
            try 
            {
                SetPathToDb(); 
                foreach (Month month in months)
                {
                    string sqlRequest = $"SELECT * FROM hcs WHERE period_id = {month.PeriodId}"; 
                    DataTable dt = GetDataTable(sqlRequest); 
                    foreach(DataRow row in dt.Rows)
                    {
                        month.HcsList.Add(new Hcs(
                            System.Convert.ToInt32(row["hcsId"]), 
                            System.Convert.ToSingle(row["qty"]), 
                            System.Convert.ToSingle(row["priceUsd"]), 
                            System.Convert.ToInt32(row["periodId"])
                        )); 
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }
    }
}