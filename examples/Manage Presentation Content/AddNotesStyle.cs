using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory
        string dataDir = "Data";
        if (!System.IO.Directory.Exists(dataDir))
            System.IO.Directory.CreateDirectory(dataDir);

        // Define input and output file paths
        string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
        string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the master notes slide
        Aspose.Slides.IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
        if (notesMaster != null)
        {
            // Get the notes style from the master notes slide
            Aspose.Slides.ITextStyle notesStyle = notesMaster.NotesStyle;

            // Retrieve paragraph format for level 0
            Aspose.Slides.IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);

            // Set bullet type to Symbol
            paragraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        }

        // Save the presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}