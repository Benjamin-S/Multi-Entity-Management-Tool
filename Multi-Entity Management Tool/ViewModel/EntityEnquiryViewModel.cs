using Multi_Entity_Management_Tool.Helper;
using Multi_Entity_Management_Tool.Interfaces;
using Multi_Entity_Management_Tool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Multi_Entity_Management_Tool.ViewModel
{
    public class EntityEnquiryViewModel : ObservableObject, IPageViewModel
    {
        #region Enums
        public enum Environment
        {
            None,
            PROD,
            TEST,
            DEV
        }

        public enum Module
        {
            None,
            SALES,
            PURCHASING
        }

        #endregion

        #region Fields
        private string _identifier;
        private string _displayName;
        private ObservableCollection<Entity> _entities = new ObservableCollection<Entity>();
        private Environment _environment = new Environment();
        private Module _module = new Module();

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

        public Environment EnvironmentProperty
        {
            get { return _environment; }
            set
            {
                _environment = value;
                RaisePropertyChangedEvent(nameof(EnvironmentProperty));
            }
        }

        public Module ModuleProperty
        {
            get { return _module; }
            set
            {
                _module = value;
                RaisePropertyChangedEvent(nameof(ModuleProperty));
            }
        }

        #endregion

        #region Commands

        public ICommand ClearScreen => new DelegateCommand(() =>
        {
            Entities.Clear();
            DisplayName = string.Empty;
            Identifier = string.Empty;
        });

        public ICommand FindEntitiesCommand => new DelegateCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(Identifier)) return;

            var rand = new Random();

            Trace.WriteLine("Identifier: " + Identifier);
            Trace.WriteLine("Module: " + ModuleProperty);
            Trace.WriteLine("Environment: " + EnvironmentProperty);

            Entity entity = new Entity
            {
                EntityNo = rand.Next(500)
            };

            Entities.Add(entity);

            DisplayName = Identifier.ToString();
            Identifier = string.Empty;
        });

        #endregion

        #region Methods

        public Dictionary<Environment, string> EnvironmentEnumWithCaptions { get; } = new Dictionary<Environment, string>()
        {
            {Environment.None, string.Empty },
            {Environment.PROD, "Production" },
            {Environment.TEST, "Test" },
            {Environment.DEV, "Development"},
        };

        public Dictionary<Module, string> ModuleEnumWithCaptions { get; } = new Dictionary<Module, string>()
        {
            {Module.None, string.Empty },
            {Module.SALES, "Sales" },
            {Module.PURCHASING, "Purchasing" }
        };


        #endregion

    }
}
