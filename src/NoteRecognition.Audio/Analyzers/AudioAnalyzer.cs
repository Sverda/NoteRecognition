using NAudio.Dsp;
using NoteRecognition.Audio.Models;
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
            var max = FindMaxAmplitude();

            return SpecData[max.ColumnIndex];
        }

        public AmplitudeResult FindMaxAmplitude(double minFrequency = 390d, double maxFrequency = 790d)
        {
            var maxAmplitude = new AmplitudeResult
            {
                Amplitude = double.MinValue
            };

            var minFrequencyIndex = (int)(minFrequency / WaveFileReader.SamplingFrequency * FftLength);
            var maxFrequencyIndex = (int)(maxFrequency / WaveFileReader.SamplingFrequency * FftLength);
            foreach (var column in SpecData)
            {
                foreach (var amplitude in column.Take(maxFrequencyIndex).Skip(minFrequencyIndex))
                {
                    if (amplitude > maxAmplitude.Amplitude)
                    {
                        maxAmplitude = new AmplitudeResult
                        {
                            ColumnIndex = SpecData.IndexOf(column),
                            RowIndex = column.IndexOf(amplitude),
                            Amplitude = amplitude,
                            Frequency = column.IndexOf(amplitude) * WaveFileReader.SamplingFrequency / FftLength
                        };
                    }
                }
            }

            return maxAmplitude;
        }

        private static IEnumerable<IEnumerable<float>> SplitIntoChunks(IEnumerable<float> collection, int chunkSize) => collection
            .Select((s, i) => new { Index = i, Value = s })
            .GroupBy(indexedItem => indexedItem.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}
