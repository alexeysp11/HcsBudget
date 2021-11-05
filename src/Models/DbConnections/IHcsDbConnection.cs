using System.Collections.Generic; 

namespace HcsBudget.Models.DbConnections
{
    public interface IHcsDbConnection 
    {
        List<Month> GetMonths(int month, int year);
        void GetHcs(ref List<Month> months); 
    }
}