using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MvvmDialogDI.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _inputWindowOpen;
        private string _text = string.Empty;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }


        public ICommand SummonWindow { get; set; }

        public bool InputWindowOpen
        {
            get
            {
                return _inputWindowOpen;
            }

            set
            {
                _inputWindowOpen = value;
                OnPropertyChanged("InputWindowOpen");
            }
        }

        public MainWindowViewModel()
        {
            SummonWindow = new RelayCommand<string>(_summonWindow, _canSummonwindow);
        }

        private bool _canSummonwindow(string arg)
        {
            return !InputWindowOpen;
        }

        private void _summonWindow(string obj)
        {          
            SummonInputWindowService summonInputWindowService = new SummonInputWindowService(this);
            summonInputWindowService.Open();          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
