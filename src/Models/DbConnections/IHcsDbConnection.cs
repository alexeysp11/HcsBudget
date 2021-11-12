using System.Collections.Generic; 
using System.Data; 

namespace HcsBudget.Models.DbConnections
{
    public interface IHcsDbConnection 
    {
        void InsertCurrentDate(int month, int year); 
        void GetDistinctYears(ref List<int> years); 
        List<Month> GetMonths();

        List<Hcs> GetHcs(int periodId); 
        List<string> SelectAllHcs(); 

        List<string> SelectAllParticipants(); 
        void InsertParticipant(string name);
        void UpdateParticipant(string oldName, string newName); 
        void DeleteParticipant(string name); 

        List<User> SelectUserSettings(); 
        void UpdateUserSettings(int userId, string language, 
            string currency, string database); 
    }
}