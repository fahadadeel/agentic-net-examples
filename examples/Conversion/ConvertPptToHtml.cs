using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPT file
            string inputPath = "input.pptx";

            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation from the specified file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation in HTML format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
            }

            // Indicate completion
            Console.WriteLine("Conversion completed.");
        }
    }
}