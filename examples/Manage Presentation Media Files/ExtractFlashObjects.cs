using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FlashExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create SWF export options
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            // Example: exclude the integrated viewer if only raw SWF data is needed
            swfOptions.ViewerIncluded = false;

            // Save the presentation as a SWF file (Flash format)
            presentation.Save("output.swf", Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Dispose the presentation to release resources
            presentation.Dispose();
        }
    }
}