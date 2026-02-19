using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";
        // Output PDF file with notes
        string outputPath = "output.pdf";

        // Load presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set PDF options to include speaker notes at the bottom
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        pdfOptions.SlidesLayoutOptions = notesOptions;

        // Save as PDF preserving notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Clean up
        presentation.Dispose();
    }
}