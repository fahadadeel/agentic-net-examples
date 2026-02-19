using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input PowerPoint file and output HTML file paths
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Load the presentation from the input file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create HTML5 export options
        Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();

        // Set the folder where external resources (images, fonts, etc.) will be saved
        html5Options.OutputPath = System.IO.Path.GetDirectoryName(outputPath);

        // Configure notes and comments layout options
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Assign the notes/comments layout options to the HTML5 options
        html5Options.SlidesLayoutOptions = notesOptions;

        // Save the presentation as HTML5, which includes comments and notes
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);

        // Release resources
        pres.Dispose();
    }
}