using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationInkObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Define full path for the PPTX file
            string outPath = Path.Combine(outputDir, "ManagedInkPresentation.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a simple line shape (as a placeholder for ink-related content)
            slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Save the presentation in PPTX format
            presentation.Save(outPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}