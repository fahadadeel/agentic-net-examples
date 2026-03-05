using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Create PPTX save options using the factory
                Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
                Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

                // Save the presentation as PPTX
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

                // Create PDF save options (default options)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Save the presentation as PDF
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}