using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory for the PPTX file
        System.String outputDir = "Output";
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);

        // Full path of the output PPTX file
        System.String outPath = System.IO.Path.Combine(outputDir, "DesignPresentation.pptx");

        // Create a new presentation (contains one empty slide by default)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation as PPTX
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}