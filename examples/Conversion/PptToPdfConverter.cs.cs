using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Convert PPT file to PDF
        string pptPath = Path.Combine(inputDir, "sample.ppt");
        string pdfFromPptPath = Path.Combine(outputDir, "sample_from_ppt.pdf");
        Aspose.Slides.Presentation presPpt = new Aspose.Slides.Presentation(pptPath);
        presPpt.Save(pdfFromPptPath, Aspose.Slides.Export.SaveFormat.Pdf);
        presPpt.Dispose();

        // Convert PPTX file to PDF
        string pptxPath = Path.Combine(inputDir, "sample.pptx");
        string pdfFromPptxPath = Path.Combine(outputDir, "sample_from_pptx.pdf");
        Aspose.Slides.Presentation presPptx = new Aspose.Slides.Presentation(pptxPath);
        presPptx.Save(pdfFromPptxPath, Aspose.Slides.Export.SaveFormat.Pdf);
        presPptx.Dispose();
    }
}