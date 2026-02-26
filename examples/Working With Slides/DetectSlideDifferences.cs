using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideDifferenceDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to save the (unchanged) presentation after processing
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Iterate through all slide pairs and compare them
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    for (int j = i + 1; j < presentation.Slides.Count; j++)
                    {
                        // Use BaseSlide.Equals to determine if slides are identical
                        bool areEqual = presentation.Slides[i].Equals(presentation.Slides[j]);

                        if (!areEqual)
                        {
                            Console.WriteLine($"Slide #{i} is different from Slide #{j}");
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}