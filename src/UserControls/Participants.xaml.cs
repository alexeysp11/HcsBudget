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
        
        public Participants()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                tbParticipants.Text = (e.NewValue).ToString(); 
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }
    }
}
