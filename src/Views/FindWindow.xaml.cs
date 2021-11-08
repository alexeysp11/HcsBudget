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
        private MainVM MainVM { get; set; }

        public FindWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = (MainVM)(this.DataContext); 
                LoadYears(); 
                LoadParticipants(); 
                LoadServices(); 
            }; 
        }

        private void LoadYears()
        {
            List<int> years = this.MainVM.SelectDistinctYears(); 
            foreach (int year in years)
            {
                cbYearFrom.Items.Add(year.ToString());
                cbYearTo.Items.Add(year.ToString());

                cbYearFrom.SelectedIndex = 0; 
                cbYearTo.SelectedIndex = 0; 
            }
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants(); 
            this.tvParticipantsFrom.ItemsSource = participants; 
        }

        private void LoadServices()
        {
            List<string> hcs = this.MainVM.LoadHcs(); 
            this.tvServicesFrom.ItemsSource = hcs; 
        }
    }
}
