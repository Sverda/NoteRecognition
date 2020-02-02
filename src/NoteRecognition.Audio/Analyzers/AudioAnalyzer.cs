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
                foreach (var sampleAfterFFT in LastFftSamples)
                {
                    var magnitude = 2 * Math.Sqrt(sampleAfterFFT.X * sampleAfterFFT.X + sampleAfterFFT.Y * sampleAfterFFT.Y) / FftLength;
                    var amplitudeInDb = 10 * Math.Log10(magnitude);
                    specDataColumn.Add(amplitudeInDb);
                }
                specDataColumn.Reverse();
                SpecData.Add(specDataColumn);
            }
        }

        public List<double> FindSpecColumnWithMaxAmplitudeInDb()
        {
            var maxAmplitude = double.MaxValue;
            var columnIndex = -1;
            foreach (var column in SpecData)
            {
                foreach (var amplitude in column)
                {
                    if (amplitude < maxAmplitude)
                    {
                        maxAmplitude = amplitude;
                        columnIndex = SpecData.IndexOf(column);
                    }
                }
            }

            return SpecData[columnIndex];
        }

        public double FindMaxAmplitudeValue()
        {
            var maxAmplitude = double.MaxValue;
            var columnIndex = -1;
            var rowIndex = -1;
            foreach (var column in SpecData)
            {
                foreach (var amplitude in column)
                {
                    if (amplitude < maxAmplitude)
                    {
                        maxAmplitude = amplitude;
                        columnIndex = SpecData.IndexOf(column);
                        rowIndex = column.IndexOf(amplitude);
                    }
                }
            }

            return SpecData[columnIndex][rowIndex];
        }

        private static IEnumerable<IEnumerable<float>> SplitIntoChunks(IEnumerable<float> collection, int chunkSize) => collection
            .Select((s, i) => new { Index = i, Value = s })
            .GroupBy(indexedItem => indexedItem.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}
