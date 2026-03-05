using System;

namespace AsposeSlidesTiffConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourceFile = "input.pptx";
            // Path to the output TIFF file
            string outputFile = "output.tiff";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourceFile))
            {
                // Save the presentation as a multi‑page TIFF image
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Tiff);
            }
        }
    }
}