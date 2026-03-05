using System;

class Program
{
    static void Main()
    {
        // Path to the input PowerPoint file
        string inputPath = "input.pptx";
        // Path to the output PDF file
        string outputPath = "output.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options and set the password
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.Password = "myPassword";

        // Save the presentation as a password‑protected PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}