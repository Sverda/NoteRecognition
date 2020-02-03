using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteRecognition.Audio.Analyzers;
using NoteRecognition.Audio.Readers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NoteRecognition.Tests
{
    [TestClass]
    public class NotesTests
    {
        [TestMethod]
        public void G()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void A()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void B()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void C()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void D()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void E()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void F()
        {
            TestCurrentNote();
        }

        [TestMethod]
        public void Unknown()
        {
            TestCurrentNote();
        }

        private void TestCurrentNote()
        {
            var filePath = GetCurrentNotePath();

            var waveReader = new WaveDataFileReader(filePath);
            var audioAnalyzer = new AudioAnalyzer(waveReader)
            {
                FftLength = 1024 * 16
            };
            audioAnalyzer.AnalyzeValues();

            var result = audioAnalyzer.FindMaxAmplitudeInScope();
            var actualResult = new NoteAnalyzer().CheckNote(result.Frequency);

            AssertNote(actualResult);
        }

        private string GetCurrentNotePath()
        {
            var noteName = GetCurrentTestName();
            var filePath = $"..\\..\\..\\..\\audio\\{noteName}.wav";
            return filePath;
        }

        private void AssertNote(string actualNote)
        {
            Assert.AreEqual(GetCurrentTestName(), actualNote);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string GetCurrentTestName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(3);

            return sf.GetMethod().Name;
        }
    }
}
