namespace XAML.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            DeleteCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });
        }

        private string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                OnPropertyChanged(theNote);
            }
        }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
        public ObservableCollection<string> AllNotes { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
