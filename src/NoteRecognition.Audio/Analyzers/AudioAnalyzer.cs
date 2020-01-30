using NAudio.Dsp;
using NoteRecognition.Audio.Readers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteRecognition.Audio.Analyzers
{
    public class AudioAnalyzer
    {
        public readonly WaveDataFileReader WaveFileReader;

        public Complex[] FftSamples { get; set; }

        public List<List<double>> SpecData { get; set; }

        public bool UseLogScale { get; set; }

        public IEnumerable<IEnumerable<float>> BatchSamplesPerMillisecond => WaveFileReader.GetSamplesBatchPerMillisecond();

        public int FftLength { get; set; }

        public double Overlap { get; set; }

        public AudioAnalyzer(WaveDataFileReader waveFileReader)
        {
            WaveFileReader = waveFileReader;
            SpecData = new List<List<double>>();
        }

        public void AnalyzeValues()
        {
            if (WaveFileReader.Samples.Count == 0)
                return;

            var audioBatches = splitIntoChunks(WaveFileReader.Samples, FftLength);
            foreach (var batch in audioBatches)
            {
                var samples = (List<float>)batch;
                if (samples.Count < FftLength)
                {
                    continue; ;
                }
                FftSamples = new Complex[FftLength];
                foreach (var sample in samples)
                {
                    var i = samples.IndexOf(sample);
                    FftSamples[i].X = (float)(sample * FastFourierTransform.HammingWindow(i, FftLength));
                    FftSamples[i].Y = 0;
                }

                FastFourierTransform.FFT(true, (int)Math.Log(FftLength, 2.0), FftSamples);

                var specDataColumn = new List<double>();
                foreach (var sample in FftSamples)
                {
                    var amplitude = Math.Sqrt(sample.X * sample.X + sample.Y * sample.Y);
                    var specValue = Math.Log(amplitude) / Math.Log(10);
                    const double min = -96.0;
                    specValue = Math.Max(specValue, min);
                    specValue = specValue / min * byte.MaxValue;
                    specDataColumn.Add(specValue);
                }
                specDataColumn.Reverse();
                SpecData.Add(specDataColumn);
            }
        }

        public IEnumerable<IEnumerable<float>> BatchFftSamplesPerMilisecond()
        {
            var batch = FftSamples.Select((s, i) => new { Index = i, Value = s.X })
                .GroupBy(indexedSample => indexedSample.Value / WaveFileReader.SamplesPerMillisecond,
                    indexedSample => indexedSample.Value)
                .Cast<IEnumerable<float>>();
            return batch;
        }

        private IEnumerable<IEnumerable<float>> splitIntoChunks(IEnumerable<float> collection, int chunkSize) => collection
            .Select((s, i) => new { Index = i, Value = s })
            .GroupBy(indexedItem => indexedItem.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}
