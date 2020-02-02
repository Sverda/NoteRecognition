using System.Globalization;
using System.Windows.Forms;

namespace NoteRecognition.Desktop.Controls
{
    public partial class NoteIndication : UserControl
    {
        public double MaxMagnitudeInDb { get; set; }

        public double MaxMagnitudeFrequency { get; set; }

        public string NoteName { get; set; }

        public NoteIndication()
        {
            InitializeComponent();
        }

        public void UpdateControl()
        {
            noteOutputDb.Text = MaxMagnitudeInDb.ToString(CultureInfo.InvariantCulture);
            noteOutputHz.Text = MaxMagnitudeFrequency.ToString(CultureInfo.InvariantCulture);
            noteOutputName.Text = NoteName;
        }
    }
}
