using System.Collections.Generic; 
using System.Windows; 
using System.Windows.Input; 
using HcsBudget.Views; 
using HcsBudget.Commands; 
using HcsBudget.Models; 
using HcsBudget.Models.DbConnections; 

namespace HcsBudget.ViewModels
{
    public class MainVM
    {
        private MainWindow MainWindow { get; set; }

        public ICommand InputCommand { get; private set; }
        public ICommand OutputCommand { get; private set; }
        public ICommand NavigateCommand { get; private set; }

        private IHcsDbConnection HcsDbConnection { get; set; }
        private IStateDbConnection StateDbConnection { get; set; }

        private List<Month> MonthsCollection { get; set; }

        public MainVM(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow; 

            this.InputCommand = new InputCommand(this); 
            this.OutputCommand = new OutputCommand(this); 
            this.NavigateCommand = new NavigateCommand(this); 

            this.HcsDbConnection = new DbConnection(); 
            this.StateDbConnection = new DbConnection(); 
        }

        #region Data output
        public void ReloadData()
        {
            try
            {
                System.DateTime today = System.DateTime.UtcNow.Date; 
                MonthsCollection = this.HcsDbConnection.GetMonths(today.Month, today.Year); 
                
                List<Month> months = MonthsCollection; 
                this.HcsDbConnection.GetHcs(ref months); 
                MonthsCollection = months; 
                
                List<string> monthNames = new List<string>(); 
                foreach (Month month in MonthsCollection)
                {
                    monthNames.Add(month.Label); 
                }
                this.MainWindow.Months.tvTalbes.ItemsSource = monthNames;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception"); 
            }
        }

        public void CalculateReport()
        {
            System.Windows.MessageBox.Show("CalculateReport"); 
        }

        public void ExportReport()
        {
            System.Windows.MessageBox.Show("ExportReport"); 
        }

        public void ClearReport()
        {
            System.Windows.MessageBox.Show("ClearReport"); 
        }
        #endregion  // Data output

        #region Data input
        public void AddData()
        {
            System.Windows.MessageBox.Show("AddData"); 
        }

        public void EditData()
        {
            System.Windows.MessageBox.Show("EditData"); 
        }

        public void DeleteData()
        {
            System.Windows.MessageBox.Show("DeleteData"); 
        }
        #endregion  // Data input

        #region Navigation
        public void OpenSettingsWindow()
        {
            var win = new SettingsWindow();
            win.DataContext = this;
            win.Show();
        }

        public void OpenFindWindow()
        {
            var win = new FindWindow();
            win.DataContext = this;
            win.Show();
        }

        public void OpenServiceWindow()
        {
            var win = new ServiceWindow();
            win.DataContext = this;
            win.Show();
        }

        public void OpenUserDocs(string filename)
        {
            string msg = "Do you want to open documentation in your browser?"; 
            if (System.Windows.MessageBox.Show(msg, "User Docs", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                try 
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = $"docs\\{filename}.html";
                    process.Start();
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Exception"); 
                }
            }
        }

        public void OpenGitHubAcount()
        {
            try 
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/alexeysp11/HcsBudget",
                    UseShellExecute = true
                });
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception"); 
            }
        }
        #endregion  // Navigation
    }
}