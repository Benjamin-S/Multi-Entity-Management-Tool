using Multi_Entity_Management_Tool.Interfaces;
using Multi_Entity_Management_Tool.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Multi_Entity_Management_Tool.ViewModel
{
    public class EntityEnquiryViewModel : ObservableObject, IPageViewModel
    {
        private string _identifier;
        private string _displayName;
        private ObservableCollection<Entity> _entities = new ObservableCollection<Entity>();

        public string Name
        {
            get
            {
                return "Entity Check";
            }
        }

        public string Tooltip
        {
            get
            {
                return "Check the entities assigned against specific\ndebtors/vendors in multiple environments";
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

        public ObservableCollection<Entity> Entities
        {
            get { return _entities; }
            set
            {
                _entities = value;
                RaisePropertyChangedEvent(nameof(Entities));
            }
        }

        public ICommand ClearScreen => new DelegateCommand(() =>
        {
            Entities.Clear();
            DisplayName = string.Empty;
            Identifier = string.Empty;
        });

        public ICommand FindEntitiesCommand => new DelegateCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(Identifier)) return;
            Trace.WriteLine("Identifier: " + Identifier);

            Entity entity = new Entity
            {
                EntityNo = int.Parse(Identifier)
            };

            Entities.Add(entity);

            DisplayName = Identifier.ToString();
            Identifier = string.Empty;
        });

    }
}
