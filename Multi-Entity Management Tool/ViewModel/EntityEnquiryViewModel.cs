using Multi_Entity_Management_Tool.Interfaces;
using System.Diagnostics;
using System.Windows.Input;

namespace Multi_Entity_Management_Tool.ViewModel
{
    public class EntityEnquiryViewModel : ObservableObject, IPageViewModel
    {
        private string _identifier;
        private string _displayName;

        public string Name
        {
            get
            {
                return "Enquiry";
            }
        }

        public string Identifier
        {
            get { return _identifier; }
            set
            {
                _identifier = value;
                RaisePropertyChangedEvent(nameof(Identifier));
            }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                RaisePropertyChangedEvent(nameof(DisplayName));
            }
        }

        public ICommand FindEntitiesCommand => new DelegateCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(Identifier)) return;
            Trace.WriteLine("Identifier: " + Identifier);
            DisplayName = Identifier.ToString();
            Identifier = string.Empty;
        });


    }
}
