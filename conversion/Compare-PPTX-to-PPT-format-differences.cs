using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";
            // Path for the converted PPT file
            string outputPath = "output.ppt";

            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Save it in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}