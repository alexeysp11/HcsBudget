using System.Collections.Generic; 

namespace HcsBudget.Models.DbConnections
{
    public interface IHcsDbConnection 
    {
        void InsertCurrentDate(int month, int year); 
        List<Month> GetMonths();
        void GetHcs(ref List<Month> months); 
        void GetDistinctYears(ref List<int> years); 
    }
}