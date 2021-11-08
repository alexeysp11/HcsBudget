using System.Data;
using System.Windows;
using System.Windows.Controls;
using HcsBudget.ViewModels;
using HcsBudget.Models;

namespace HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for DataOut.xaml
    /// </summary>
    public partial class DataOut : UserControl
    {
        private MainVM MainVM { get; set; }

        public DataOut()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DataRowView selectedRow = dg.SelectedItem as DataRowView;
                DataIn dataIn = this.MainVM.MainWindow.DataIn; 
                dataIn.ServiceInput.tbService.Text = ((Hcs)(dg.SelectedItem)).Name.ToString(); 
                dataIn.ServiceInput.tbQuantity.Text = ((Hcs)(dg.SelectedItem)).Qty.ToString(); 
                dataIn.ServiceInput.tbPrice.Text = ((Hcs)(dg.SelectedItem)).PriceUsd.ToString(); 
                dataIn.tbParticipants.Text = ((Hcs)(dg.SelectedItem)).ParticipantName.ToString(); 
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }
    }
}
