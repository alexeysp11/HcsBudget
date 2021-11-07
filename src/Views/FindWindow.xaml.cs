using System.Collections.Generic;
using System.Windows;
using HcsBudget.ViewModels; 

namespace HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        public FindWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                List<int> years = ((MainVM)(this.DataContext)).SelectDistinctYears(); 
                foreach (int year in years)
                {
                    cbYearFrom.Items.Add(year.ToString());
                    cbYearTo.Items.Add(year.ToString());

                    cbYearFrom.SelectedIndex = 0; 
                    cbYearTo.SelectedIndex = 0; 
                }
            }; 
        }
    }
}
