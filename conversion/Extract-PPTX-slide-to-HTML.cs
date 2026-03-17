using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Path for the output HTML file (single slide)
            string outputPath = "slide1.html";

            // Slide numbers to export (1‑based indexing)
            int[] slideIndices = new int[] { 1 };

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Export the specified slide to HTML format
                presentation.Save(outputPath, slideIndices, SaveFormat.Html);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}