using System;
using System.IO;

namespace PresentationOverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (automatically created)
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Display basic information about the presentation
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Number of slides: " + slideCount);

            // Iterate through all slides and print their slide numbers
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Console.WriteLine("Slide Number: " + slide.SlideNumber);
            }

            // Save the presentation before exiting
            string outputPath = Path.Combine(outDir, "Overview.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}