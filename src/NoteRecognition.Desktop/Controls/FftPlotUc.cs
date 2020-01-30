using NoteRecognition.Audio.Analyzers;
using System;
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

            chart1.Titles.Add("Fast Fourier Transform");
            chart1.Series.Add(_chartName);
            chart1.Series[_chartName].ChartType = SeriesChartType.FastLine;
            chart1.Series[_chartName].ChartArea = "ChartArea1";
            chart1.Series[_chartName].XValueType = ChartValueType.Auto;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Frequency [Hz]";
            chart1.ChartAreas[0].AxisY.Title = "Magnitude [dB]";
        }

        public void UpdatePlot()
        {
            var bins = Analyzer.FftSamples.Length;
            var firstPeak = bins / 2;   // The first peak is for a positive frequency

            var maxFftFrequency = Analyzer.WaveFileReader.SamplesPerMillisecond * 1000;  // frequency (Hz) is cycles per second
            chart1.ChartAreas[0].AxisX.Maximum = maxFftFrequency;
            var frequencyStep = maxFftFrequency / firstPeak;
            var frequency = 0;
            for (var i = 0; i < firstPeak; i++)
            {
                var amplitude = Analyzer.FftSamples[i];
                var intensityDb = 10 * Math.Log10(Math.Sqrt(amplitude.X * amplitude.X + amplitude.Y * amplitude.Y));
                chart1.Series[_chartName].Points.AddXY(frequency, intensityDb);
                frequency += frequencyStep;
            }
        }
    }
}
