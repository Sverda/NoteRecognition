using NoteRecognition.Audio.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoteRecognition.Desktop.Controls
{
    public partial class NoteIndication : UserControl
    {
        private NoteAnalyzer _noteAnalyzer;

        public AudioAnalyzer Analyzer { get; set; }

        public NoteIndication()
        {
            InitializeComponent();

            _noteAnalyzer = new NoteAnalyzer();
        }

        public void UpdateNote()
        {
            var bins = Analyzer.FftSamples.Length;
            var firstPeak = bins / 2;   // The first peak is for a positive frequency

            var maxFftFrequency = Analyzer.WaveFileReader.SamplesPerMillisecond * 1000;  // frequency (Hz) is cycles per second
            var frequencyStep = maxFftFrequency / firstPeak;
            var frequency = 0;
            var maxSuspens = new List<(double Frequency, double Magnitude)>();
            for (var i = 0; i < firstPeak; i++)
            {
                var amplitude = Analyzer.FftSamples[i];
                var intensityDb = 10 * Math.Log10(Math.Sqrt(amplitude.X * amplitude.X + amplitude.Y * amplitude.Y));
                maxSuspens.Add((frequency, intensityDb));

                frequency += frequencyStep;
            }

            var maxMag = maxSuspens.Select(ms => ms.Magnitude).Max();
            var maxFreq = maxSuspens.Single(ms => Math.Abs(ms.Magnitude - maxMag) < 0.1);
            noteOutput.Text = maxFreq.Frequency.ToString();
        }
    }
}
