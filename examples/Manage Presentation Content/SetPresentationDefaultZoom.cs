using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SetZoom_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set default zoom values for slide view and notes view (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 100;
            presentation.ViewProperties.NotesViewProperties.Scale = 100;

            // Save the presentation in PPTX format (as per the set-zoom rule)
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}