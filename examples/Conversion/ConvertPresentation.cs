using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input PPT file and output PPTX file paths
        string inputPath = "input.ppt";
        string outputPath = "output.pptx";

        // Load the PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PPTX save options using the factory
        Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
        Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

        // Save the presentation as PPTX with the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

        // Clean up resources
        presentation.Dispose();
    }
}