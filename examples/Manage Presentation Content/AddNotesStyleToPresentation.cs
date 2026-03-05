using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddNotesStyleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Define output file path
            string outputPath = Path.Combine(dataDir, "AddNotesStyle_out.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the master notes slide (if it exists)
            IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
            if (notesMaster != null)
            {
                // Get the notes style from the master notes slide
                ITextStyle notesStyle = notesMaster.NotesStyle;

                // Get the paragraph format for level 0 and set bullet type to Symbol
                IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
                paragraphFormat.Bullet.Type = BulletType.Symbol;
            }

            // Save the presentation in PPTX format
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}