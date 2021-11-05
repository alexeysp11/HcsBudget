using System.Windows;
using System.Windows.Controls;

namespace HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Months.xaml
    /// </summary>
    public partial class Months : UserControl
    {
        public Months()
        {
            InitializeComponent();
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                string month = (e.NewValue).ToString(); 
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }
    }
}
