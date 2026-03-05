using System;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        System.String sourcePath = "input.pptx";
        // Output PDF file path
        System.String outputPath = "output.pdf";

        // Configure load options to keep the source file locked (BLOB handling)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        // Load the presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Set PDF export options (optional: include OLE data)
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.IncludeOleData = true;

        // Export the presentation to PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Ensure the presentation is saved before exiting
        presentation.Dispose();
    }
}