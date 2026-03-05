using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT file
        string inputPath = "input.ppt";
        // Path for the generated XPS file
        string outputPath = "output.xps";

        // Load the presentation from the PPT file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in XPS format using default options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}