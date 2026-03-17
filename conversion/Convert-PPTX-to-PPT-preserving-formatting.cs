using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for source PPTX and target PPT files
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        try
        {
            // Load the PPTX presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation in PPT format, preserving all slides and formatting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}