using MvvmDialogDI.View;
using MvvmDialogDI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmDialogDI
{
    public class SummonInputWindowService
    {
        private MainWindowViewModel _mainWindowViewModel;
        private InputWindow _inputWindow;
       

        public SummonInputWindowService(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _inputWindow = new InputWindow(_mainWindowViewModel);
            _inputWindow.Closed += _inputWindow_Closed;      
        }

        private void _inputWindow_Closed(object sender, EventArgs e)
        {
            _mainWindowViewModel.InputWindowOpen = false;
        }

        public void Open()
        {
            _inputWindow.Show();
            _mainWindowViewModel.InputWindowOpen = true;     
        }      
    }
}
