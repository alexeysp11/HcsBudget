using System.Collections.Generic;
using System.Windows;
using HcsBudget.ViewModels;

namespace HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainVM MainVM { get; set; }

        public SettingsWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = ((MainVM)(this.DataContext));
                Participants.DataContext = this.MainVM; 
                LoadParticipants(); 
            };
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants(); 
            this.Participants.tvParticipants.ItemsSource = participants; 
        }
    }
}
