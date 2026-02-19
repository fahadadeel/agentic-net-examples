using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string __inputPath__;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            __inputPath__ = args[0];
        else
            __inputPath__ = "input.pptx";

        // Build output PDF path
        string __directory__ = Path.GetDirectoryName(__inputPath__);
        string __filenameWithoutExt__ = Path.GetFileNameWithoutExtension(__inputPath__);
        string __outputPath__ = Path.Combine(__directory__ ?? "", __filenameWithoutExt__ + ".pdf");

        // Load presentation
        Presentation presentation = new Presentation(__inputPath__);

        // Set PDF options to include hidden slides
        PdfOptions pdfOptions = new PdfOptions();
        pdfOptions.ShowHiddenSlides = true;

        // Save as PDF with hidden slides
        presentation.Save(__outputPath__, SaveFormat.Pdf, pdfOptions);

        // Clean up
        presentation.Dispose();
    }
}