using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";
        // Output PDF file
        string outputPath = "output.pdf";

        // Load presentation
        Aspose.Slides.Presentation __presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options
        Aspose.Slides.Export.PdfOptions __pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Set notes layout options to display notes at the bottom (full)
        Aspose.Slides.Export.NotesCommentsLayoutingOptions __notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        __notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Assign notes options to PDF options
        __pdfOptions.SlidesLayoutOptions = __notesOptions;

        // Save presentation as PDF with notes view
        __presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, __pdfOptions);
    }
}