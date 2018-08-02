using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class HelloViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        public HelloViewModel()
        {
            Items = new ObservableCollection<string>();
            Title = "Tytuł pierwszy";
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            Items.Add("jeden");
            await Task.Delay(2000);
            Items.Add("dwa");
            Items.Add("trzy");
            Title = "Drugi tytuł";
            await Task.Delay(3000);
            Items.Add("dwa");
            Items.Add("trzy");
            Title = "Trzeci tytuł, który się tam zmienia w tle";
            await Task.Delay(2000);
            Items.RemoveAt(2);
            Title = "Drugi tytuł";
            await Task.Delay(3000);
            Items.Add("dwa");
            Items.Add("trzy");
            Title = "Trzeci tytuł, który się tam zmienia w tle";
        }
    }
}