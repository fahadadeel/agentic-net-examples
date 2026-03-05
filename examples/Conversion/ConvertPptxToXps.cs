using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path for the resulting XPS file
        string outputPath = "output.xps";

        // Load the presentation from the PPTX file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in XPS format using default options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}