using System;

namespace ConvertPptxToPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";
            // Path for the resulting PPT file
            string outputPath = "output.ppt";

            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Release resources
            presentation.Dispose();
        }
    }
}