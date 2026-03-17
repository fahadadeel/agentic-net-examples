using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFiles = new string[] { "sample.ppt", "sample.pptx" };
            foreach (string inputPath in inputFiles)
            {
                try
                {
                    Presentation presentation = new Presentation(inputPath);
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.JpegQuality = 90;
                    pdfOptions.SaveMetafilesAsPng = true;
                    pdfOptions.TextCompression = PdfTextCompression.Flate;
                    pdfOptions.Compliance = PdfCompliance.Pdf15;
                    pdfOptions.ShowHiddenSlides = true;
                    string outputPath = System.IO.Path.ChangeExtension(inputPath, ".pdf");
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file '{0}': {1}", inputPath, ex.Message);
                }
            }
        }
    }
}