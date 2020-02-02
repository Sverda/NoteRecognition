using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using System.Linq;

namespace NoteRecognition.Audio.Readers
{
    public class WaveDataFileReader
    {
        private readonly float[] _buffer;

        public int BufferSize { get; }

        public List<float> Samples { get; }

        public int SamplesPerMillisecond { get; set; }

        public double SamplingFrequency => SamplesPerMillisecond * 1000d;

        public WaveDataFileReader(string filePath)
        {
            BufferSize = 1024 * 1024;
            _buffer = new float[BufferSize];
            Samples = new List<float>();
            ReadWaveDataFromFile(filePath);
        }

        public void ReadWaveDataFromFile(string filePath)
        {
            using (var reader = new WaveFileReader(filePath))
            {
                SamplesPerMillisecond = reader.WaveFormat.SampleRate / 1000;

                var channel = new SampleChannel(reader);
                var readNumber = channel.Read(_buffer, 0, BufferSize * 4);
                for (var i = 0; i < readNumber; i += channel.WaveFormat.Channels)
                {
                    Samples.Add(_buffer[i]);
                }
            }
        }

        public IEnumerable<IEnumerable<float>> GetSamplesBatchPerMillisecond()
        {
            var batches = Samples.Select((sample, index) => new { Value = sample, Index = index })
                .GroupBy(indexedSample => indexedSample.Index / SamplesPerMillisecond, indexedSample => indexedSample.Value)
                .Cast<IEnumerable<float>>();
            return batches;
        }
    }
}