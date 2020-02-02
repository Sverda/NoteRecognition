using System;

namespace NoteRecognition.Audio.Analyzers
{
    public class NoteAnalyzer
    {
        public string CheckNote(double frequency)
        {
            if (frequency < 403.5)
            {
                return "G";
            }

            if (403.5 <= frequency && frequency < 427.5)
            {
                return "G#";
            }

            if (427.5 <= frequency && frequency < 451.5)
            {
                return "A";
            }

            if (451.5 <= frequency && frequency < 479.5)
            {
                return "A#";
            }

            if (479.5 <= frequency && frequency < 508)
            {
                return "B";
            }

            if (508 <= frequency && frequency < 538.5)
            {
                return "C";
            }

            if (538.5 <= frequency && frequency < 570.5)
            {
                return "C#";
            }

            if (570.5 <= frequency && frequency < 604.5)
            {
                return "D";
            }

            if (604.5 <= frequency && frequency < 640.5)
            {
                return "D#";
            }

            if (640.5 <= frequency && frequency < 678.5)
            {
                return "E";
            }

            if (678.5 <= frequency && frequency < 719)
            {
                return "F";
            }

            if (719 <= frequency && frequency < 762)
            {
                return "F#";
            }

            if (762 <= frequency)
            {
                return "G";
            }

            throw new ArgumentException("Unknown note");
        }
    }
}
