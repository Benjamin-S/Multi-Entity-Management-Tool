﻿using Multi_Entity_Management_Tool.Model;
using Multi_Entity_Management_Tool.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Multi_Entity_Management_Tool.ViewModel
{
    public class Presenter : ObservableObject, IPageViewModel
    {
        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent(nameof(SomeText));
            }
        }

        public IEnumerable<string> History => _history;

        public ICommand ConvertTextCommand => new DelegateCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(SomeText)) return;
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        });

        public string Name
        {
            get
            {
                return "Test";
            }
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
