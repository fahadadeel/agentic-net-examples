using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToHtmlWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set up HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOpt = new Aspose.Slides.Export.HtmlOptions();
            // Use a simple document formatter (template name can be empty, false for not embedding resources)
            htmlOpt.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("", false);

            // Configure notes layout to include speaker notes at the bottom
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            // Assign notes options to the HTML options (SlidesLayoutOptions can be null if not needed)
            htmlOpt.SlidesLayoutOptions = null;

            // Save the presentation as HTML with notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}