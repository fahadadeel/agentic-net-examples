using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths of the presentations to be merged
            List<string> sourceFiles = new List<string>
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Create a new presentation that will hold the merged slides
            using (Presentation combinedPresentation = new Presentation())
            {
                // Remove the default empty slide created by the constructor
                combinedPresentation.Slides.RemoveAt(0);

                // Iterate through each source file
                foreach (string filePath in sourceFiles)
                {
                    // Load the source presentation
                    using (Presentation sourcePresentation = new Presentation(filePath))
                    {
                        // Clone each slide into the combined presentation
                        for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                        {
                            ISlide sourceSlide = sourcePresentation.Slides[i];
                            combinedPresentation.Slides.AddClone(sourceSlide);
                        }
                    }
                }

                // Save the merged presentation
                combinedPresentation.Save("CombinedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}