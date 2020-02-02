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

        public Complex[] LastFftSamples { get; set; }

        public List<List<double>> SpecData { get; set; }

        public IEnumerable<IEnumerable<float>> BatchSamplesPerMillisecond => WaveFileReader.GetSamplesBatchPerMillisecond();

        public int FftLength { get; set; }

        public AudioAnalyzer(WaveDataFileReader waveFileReader)
        {
            WaveFileReader = waveFileReader;
            SpecData = new List<List<double>>();
        }

        public void AnalyzeValues()
        {
            if (WaveFileReader.Samples.Count == 0)
            {
                return;
            }

            var audioBatches = SplitIntoChunks(WaveFileReader.Samples, FftLength);
            foreach (var batch in audioBatches)
            {
                var samples = (List<float>)batch;
                if (samples.Count < FftLength)
                {
                    continue;
                }

                LastFftSamples = new Complex[FftLength];
                foreach (var sample in samples)
                {
                    var i = samples.IndexOf(sample);
                    LastFftSamples[i].X = (float)(sample * FastFourierTransform.HammingWindow(i, FftLength));
                    LastFftSamples[i].Y = 0;
                }

                FastFourierTransform.FFT(true, (int)Math.Log(FftLength, 2.0), LastFftSamples);

                var specDataColumn = new List<double>();
                foreach (var sample in LastFftSamples)
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

        public List<double> FindSpecColumnWithMaxMagnitude()
        {
            var maxMagnitude = 0d;
            var columnIndex = -1;
            foreach (var column in SpecData)
            {
                foreach (var magnitude in column)
                {
                    if (magnitude > maxMagnitude)
                    {
                        maxMagnitude = magnitude;
                        columnIndex = SpecData.IndexOf(column);
                    }
                }
            }

            return SpecData[columnIndex];
        }

        public double FindMaxMagnitude()
        {
            var maxMagnitude = 0d;
            var columnIndex = -1;
            var dataIndex = -1;
            foreach (var column in SpecData)
            {
                foreach (var magnitude in column)
                {
                    if (magnitude > maxMagnitude)
                    {
                        maxMagnitude = magnitude;
                        columnIndex = SpecData.IndexOf(column);
                        dataIndex = column.IndexOf(magnitude);
                    }
                }
            }

            return SpecData[columnIndex][dataIndex];
        }

        private static IEnumerable<IEnumerable<float>> SplitIntoChunks(IEnumerable<float> collection, int chunkSize) => collection
            .Select((s, i) => new { Index = i, Value = s })
            .GroupBy(indexedItem => indexedItem.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}
