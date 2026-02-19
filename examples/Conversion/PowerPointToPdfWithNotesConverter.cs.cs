using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";
        // Output PDF file with notes
        string outputPath = "output.pdf";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create PDF export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            // Configure notes layout options
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            // Assign notes options to PDF options
            pdfOptions.SlidesLayoutOptions = notesOptions;

            // Save the presentation as PDF with notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
    }
}