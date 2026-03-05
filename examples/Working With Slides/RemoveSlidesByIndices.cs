using System;
using System.Collections.Generic;
using Aspose.Slides;

namespace RemoveSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // List of slide indices to remove (zero‑based)
                List<int> indicesToRemove = new List<int> { 2, 4, 6 };

                // Sort indices in descending order to avoid shifting issues
                indicesToRemove.Sort((a, b) => b.CompareTo(a));

                // Remove slides at specified indices
                foreach (int index in indicesToRemove)
                {
                    // Ensure the index is within the current slide count
                    if (index >= 0 && index < presentation.Slides.Count)
                    {
                        presentation.Slides.RemoveAt(index);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}