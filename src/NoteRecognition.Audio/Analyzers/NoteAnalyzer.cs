namespace NoteRecognition.Audio.Analyzers
{
    public class NoteAnalyzer
    {
        public string CheckNote(double frequency)
        {
            if (369.9 <= frequency && frequency < 403.5)
            {
                return "G";
            }

            if (403.5 <= frequency && frequency < 427.5)
            {
                return "Ab";
            }

            if (427.5 <= frequency && frequency < 451.5)
            {
                return "A";
            }

            if (451.5 <= frequency && frequency < 479.5)
            {
                return "Bb";
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
                return "Db";
            }

            if (570.5 <= frequency && frequency < 604.5)
            {
                return "D";
            }

            if (604.5 <= frequency && frequency < 640.5)
            {
                return "Eb";
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
                return "Gb";
            }

            if (762 <= frequency && frequency < 830)
            {
                return "G";
            }

            return "Unknown";
        }
    }
}
