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

        private void tvParticipantsFrom_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string menuItem = tvParticipantsFrom.SelectedItem as string;
                if (menuItem != null)
                {
                    foreach (string item in this.tvParticipantsTo.Items)
                    {
                        if (item == menuItem) 
                        {
                            return; 
                        }
                    }
                    this.tvParticipantsTo.Items.Add(menuItem);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }

        private void tvParticipantsTo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            tvParticipantsTo.Items.Remove(tvParticipantsTo.SelectedItem);
        }

        private void SaveBtn_Clicked(object sender, System.EventArgs e)
        {
            System.Windows.MessageBox.Show("SaveBtn_Clicked");
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants(); 
            this.tvParticipantsFrom.ItemsSource = participants; 
        }
    }
}
