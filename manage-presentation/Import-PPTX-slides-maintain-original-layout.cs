using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths for source and output presentations
            var sourcePath = "source.pptx";
            var outputPath = "merged.pptx";

            // Load the source presentation
            using (var sourcePres = new Presentation(sourcePath))
            {
                // Create a new empty presentation
                using (var targetPres = new Presentation())
                {
                    // Clone each slide from source to target preserving layout and formatting
                    foreach (var slide in sourcePres.Slides)
                    {
                        targetPres.Slides.InsertClone(targetPres.Slides.Count, slide);
                    }

                    // Save the merged presentation
                    targetPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}