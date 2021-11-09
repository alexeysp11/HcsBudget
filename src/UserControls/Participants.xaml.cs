using System.Windows;
using System.Windows.Controls;
using HcsBudget.ViewModels; 

namespace HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Participants.xaml
    /// </summary>
    public partial class Participants : UserControl
    {
        private MainVM MainVM { get; set; }

        private string CurrentParticipant { get; set; }
        
        public Participants()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        private void LoadParticipants()
        {
            tvParticipants.ItemsSource = this.MainVM.LoadParticipants(); 
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                CurrentParticipant = (e.NewValue).ToString(); 
                tbParticipants.Text = CurrentParticipant; 
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }

        private void AddBtn_Clicked(object sender, System.EventArgs e)
        {
            this.MainVM.AddParticipant(tbParticipants.Text); 
            LoadParticipants(); 
        }

        private void EditBtn_Clicked(object sender, System.EventArgs e)
        {
            this.MainVM.EditParticipant(CurrentParticipant, tbParticipants.Text); 
            LoadParticipants(); 
        }

        private void DeleteBtn_Clicked(object sender, System.EventArgs e)
        {
            if (CurrentParticipant == tbParticipants.Text)
            {
                this.MainVM.DeleteParticipant(CurrentParticipant); 
                LoadParticipants(); 
            }
            else
            {
                string msg = "Unable to delete participant\nYou should not edit participant's name in TextBox"; 
                System.Windows.MessageBox.Show(msg, "Error"); 
            }
        }
    }
}
