using System.Collections.Generic; 
using System.Data; 

namespace HcsBudget.Models.DbConnections
{
    public interface IHcsDbConnection 
    {
        void InsertCurrentDate(int month, int year); 
        List<Month> GetMonths();
        List<Hcs> GetHcs(int periodId); 
        void GetDistinctYears(ref List<int> years); 
    }
}