using Multi_Entity_Management_Tool.Interfaces;
using System;

namespace Multi_Entity_Management_Tool.ViewModel
{
    class EditorViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Editor";
            }
        }

        public string Tooltip => throw new NotImplementedException();
    }
}
