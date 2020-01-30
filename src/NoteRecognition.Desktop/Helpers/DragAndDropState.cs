using System;
using System.Linq;

namespace NoteRecognition.Desktop.Helpers
{
    internal class DragAndDropState
    {
        public string FilePath { get; set; }

        public void OnStartDragging(string[] filePaths)
        {
            FilePath = filePaths.FirstOrDefault();
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new ArgumentNullException(nameof(FilePath));
            }
        }
    }
}
