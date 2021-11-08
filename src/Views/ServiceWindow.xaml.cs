using System.Collections.Generic;
using System.Windows;
using HcsBudget.ViewModels;

namespace HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private MainVM MainVM { get; set; }

        public ServiceWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = ((MainVM)(this.DataContext));
                LoadParticipants(); 
            };
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants(); 
            this.tvParticipantsFrom.ItemsSource = participants; 
        }
    }
}
