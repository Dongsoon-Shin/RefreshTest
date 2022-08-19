using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowVIewModel : INotifyPropertyChanged, ICommand
    {
        private ObservableCollection<Person> _person { get; set; }
        public ObservableCollection<Person> Items 
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged("Items");
            }
        }

        public ICommand ClickCommand { get; set; }

        public MainWindowVIewModel()
        {
            _person = new ObservableCollection<Person>();
            var p = new Person() { Id = 1, Name = "aaaa" };
            _person.Add(p);

            ClickCommand = new commands(increaseId, CanExecute);
        }

        private void increaseId(object obj)
        {
            _person[0] = new Person() { Id =1, Name = "bbbb" };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? CanExecuteChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
        }
    }
}
