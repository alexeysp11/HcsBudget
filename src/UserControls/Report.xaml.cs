using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HcsBudget.ViewModels; 

namespace HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();

            Loaded += (o, e) => GetYears(); 
        }

        public void GetYears()
        {
            MainVM mainVM = (MainVM)(this.DataContext); 
            mainVM.InsertCurrentDateIntoDb(); 
            List<int> years = mainVM.SelectDistinctYears(); 
            foreach (int year in years)
            {
                cbYearFrom.Items.Add(year.ToString());
                cbYearTo.Items.Add(year.ToString());

                cbYearFrom.SelectedIndex = 0; 
                cbYearTo.SelectedIndex = 0; 
            }
        }
    }
}
