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
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Define output file path
            string outputPath = Path.Combine(dataDir, "AddNotesStyle_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the master notes slide
            Aspose.Slides.IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
            if (notesMaster != null)
            {
                // Get the notes style and modify paragraph format
                Aspose.Slides.ITextStyle notesStyle = notesMaster.NotesStyle;
                Aspose.Slides.IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
                paragraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            }

            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}