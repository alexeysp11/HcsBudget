using HcsBudget.ViewModels; 

namespace HcsBudget.Commands
{
    public class InputCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM; 

        public InputCommand(MainVM mainVm)
        {
            this.MainVM = mainVm; 
        }

        public event System.EventHandler CanExecuteChanged; 

        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            string parameterString = parameter as string; 
            if (parameterString == "Add")
            {
                this.MainVM.AddData(); 
            }
            else if (parameterString == "Edit")
            {
                this.MainVM.EditData(); 
            }
            else if (parameterString == "Delete")
            {
                this.MainVM.DeleteData(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString}", "Exception"); 
            }
        }
    }
}