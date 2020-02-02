using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteRecognition.Audio.Analyzers;
using NoteRecognition.Audio.Readers;

namespace NoteRecognition.Tests
{
    [TestClass]
    public class NotesTests
    {
        [TestMethod]
        public void G()
        {
            var filePath = @"C:\Users\Damian\source\repos\NoteRecognition\audio\G.wav";

            var waveReader = new WaveDataFileReader(filePath);
            var audioAnalyzer = new AudioAnalyzer(waveReader)
            {
                FftLength = 1024 * 16
            };
            audioAnalyzer.AnalyzeValues();

            var maxFrequency = audioAnalyzer.FindMaxAmplitude().Frequency;

        }
    }
}
