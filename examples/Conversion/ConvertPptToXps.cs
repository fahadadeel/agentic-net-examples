using System;

class Program
{
    static void Main()
    {
        // Path to the source PPT/PPTX file
        System.String inputPath = "input.pptx";

        // Path where the XPS file will be saved
        System.String outputPath = "output.xps";

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create XPS conversion options
        Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();

        // Example option: convert metafiles to PNG images
        xpsOptions.SaveMetafilesAsPng = true;

        // Save the presentation as XPS using the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

        // Release resources
        presentation.Dispose();
    }
}