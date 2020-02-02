using System.Windows.Forms;

namespace NoteRecognition.Desktop.Controls
{
    public partial class NoteIndication : UserControl
    {
        public double MaxMagnitude { get; set; }

        public NoteIndication()
        {
            InitializeComponent();
        }

        public void UpdateControl()
        {
            noteOutput.Text = MaxMagnitude.ToString();
        }
    }
}
