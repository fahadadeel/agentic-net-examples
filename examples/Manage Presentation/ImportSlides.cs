using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImportSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation that will hold the imported slides
            Aspose.Slides.Presentation targetPresentation = new Aspose.Slides.Presentation();

            // Import slides from a PDF document (different file format) and add them to the end of the collection
            targetPresentation.Slides.AddFromPdf("source.pdf");

            // Save the resulting presentation in PPTX format
            targetPresentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}