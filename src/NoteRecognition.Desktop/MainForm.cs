using NoteRecognition.Audio.Analyzers;
using NoteRecognition.Audio.Readers;
using NoteRecognition.Desktop.Helpers;
using System.Windows.Forms;

namespace NoteRecognition.Desktop
{
    public partial class MainForm : Form
    {
        private AudioAnalyzer _audioAnalyzer;

        private readonly DragAndDropState _dnd;

        public MainForm()
        {
            InitializeComponent();

            _dnd = new DragAndDropState();
        }

        private void dragNDrop_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data is null)
            {
                return;
            }

            _dnd.OnStartDragging((string[])data);
        }

        private void dragNDrop_DragDrop(object sender, DragEventArgs e)
        {
            UpdatePlots(_dnd.FilePath);
        }

        private void UpdatePlots(string fileName)
        {
            var waveReader = new WaveDataFileReader(fileName);
            _audioAnalyzer = new AudioAnalyzer(waveReader)
            {
                FftLength = 1024 * 16
            };
            _audioAnalyzer.AnalyzeValues();

            audioPlotUc1.Analyzer = _audioAnalyzer;
            audioPlotUc1.UpdatePlot();

            fftPlotUc1.Analyzer = _audioAnalyzer;
            fftPlotUc1.UpdatePlot();

            var findMaxAmplitude = _audioAnalyzer.FindMaxAmplitude();
            noteIndication.MaxMagnitudeInDb = findMaxAmplitude.Amplitude;
            noteIndication.MaxMagnitudeFrequency = findMaxAmplitude.Frequency;
            noteIndication.NoteName = new NoteAnalyzer().CheckNote(findMaxAmplitude.Frequency);
            noteIndication.UpdateControl();
        }

        private void dragNDrop_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
