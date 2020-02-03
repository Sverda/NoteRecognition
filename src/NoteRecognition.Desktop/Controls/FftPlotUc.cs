using NoteRecognition.Audio.Analyzers;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NoteRecognition.Desktop.Controls
{
    public partial class FftPlotUc : UserControl
    {
        private const string _chartName = "wave";

        public AudioAnalyzer Analyzer { get; set; }

        public FftPlotUc()
        {
            InitializeComponent();

            chart1.Titles.Add("FFT with Max Amplitude");
            chart1.Series.Add(_chartName);
            chart1.Series[_chartName].ChartType = SeriesChartType.FastLine;
            chart1.Series[_chartName].ChartArea = "ChartArea1";
            chart1.Series[_chartName].XValueType = ChartValueType.Auto;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Frequency [Hz]";
            chart1.ChartAreas[0].AxisY.Title = "Amplitude [dB]";
        }

        public void UpdatePlot()
        {
            var fftSamples = Analyzer.FindSpecColumnWithMaxAmplitudeInDb();
            var amountOfPositiveFrequencyValues = fftSamples.Count / 2;

            var maxFftFrequency = Analyzer.WaveFileReader.SamplingFrequency;
            chart1.ChartAreas[0].AxisX.Minimum = 0d;
            chart1.ChartAreas[0].AxisX.Maximum = 4400d;
            var frequencyStep = maxFftFrequency / amountOfPositiveFrequencyValues;

            var frequency = 0d;
            foreach (var intensityDb in fftSamples.Take(amountOfPositiveFrequencyValues))
            {
                chart1.Series[_chartName].Points.AddXY(frequency, intensityDb);
                frequency += frequencyStep;
            }
        }
    }
}
