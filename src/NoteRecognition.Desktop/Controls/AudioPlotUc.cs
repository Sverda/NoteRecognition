using NoteRecognition.Audio.Analyzers;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NoteRecognition.Desktop.Controls
{
    public partial class AudioPlotUc : UserControl
    {
        private const string _plotName = "wave";

        public AudioAnalyzer Analyzer { get; set; }

        public AudioPlotUc()
        {
            InitializeComponent();

            chart1.Titles.Add("Audio signal");
            chart1.Series.Add(_plotName);
            chart1.Series[_plotName].ChartType = SeriesChartType.FastLine;
            chart1.Series[_plotName].ChartArea = "ChartArea1";
            chart1.Series[_plotName].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.Title = "Time [mm:ss:ms]";
            chart1.ChartAreas[0].AxisY.Title = "Amplitude";
        }

        public void UpdatePlot()
        {
            var audioTime = DateTime.MinValue;
            var ms = TimeSpan.FromMilliseconds(1);
            foreach (var batch in Analyzer.BatchSamplesPerMillisecond)
            {
                foreach (var sample in batch)
                {
                    chart1.Series[_plotName].Points.AddXY(audioTime, sample);
                }
                audioTime += ms;
            }
        }
    }
}
