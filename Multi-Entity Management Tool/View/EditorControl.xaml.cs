using ScintillaNET;
using System.Windows;
using System.Windows.Controls;

namespace Multi_Entity_Management_Tool.View
{
    /// <summary>
    /// Interaction logic for EditorControl.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        public EditorControl()
        {
            InitializeComponent();
            ScintillaEditor.Margins[0].Width = 32;
            ScintillaEditor.IndentationGuides = IndentView.LookBoth;
            ScintillaEditor.StyleResetDefault();
            ScintillaEditor.Styles[0].Font = "Consolas";
            ScintillaEditor.Styles[0].Size = 12;
        }
    }
}
