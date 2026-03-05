using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path where the XPS file will be saved
        string outputPath = "output.xps";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create XPS options and set desired properties
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        options.SaveMetafilesAsPng = true;

        // Save the presentation as XPS using the options
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);

        // Release resources
        pres.Dispose();
    }
}