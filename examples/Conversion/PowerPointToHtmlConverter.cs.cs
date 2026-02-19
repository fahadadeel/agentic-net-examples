using System;

class Program
{
    static void Main()
    {
        // Input PowerPoint file path
        System.String inputPath = "input.pptx";
        // Output HTML file path
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set HTML export options
        Aspose.Slides.Export.HtmlOptions htmlOpt = new Aspose.Slides.Export.HtmlOptions();
        // Use a simple document formatter (no slide show)
        htmlOpt.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("document.html", false);

        // Configure notes layout options (optional)
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        // Assign notes options to HTML options if needed
        // (Here we only set SlidesLayoutOptions to null as a placeholder)
        htmlOpt.SlidesLayoutOptions = null;

        // Save the presentation as HTML
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

        // Dispose the presentation object
        presentation.Dispose();
    }
}