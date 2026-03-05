using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file and output PDF file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Configure notes layout options to include notes in the PDF
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Assign the notes layout options to the PDF options
        pdfOptions.SlidesLayoutOptions = notesOptions;

        // Save the presentation as PDF with notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Clean up resources
        presentation.Dispose();
    }
}