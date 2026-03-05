using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the PPTX presentation
        Presentation pres = new Presentation(inputPath);

        // Create PPTX save options using the factory
        SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
        IPptxOptions ipptxOptions = optionsFactory.CreatePptxOptions();

        // Cast to concrete PptxOptions to set properties
        PptxOptions pptxOptions = (PptxOptions)ipptxOptions;
        // Example option: do not refresh thumbnail
        pptxOptions.RefreshThumbnail = false;

        // Save the presentation with the specified options
        pres.Save(outputPath, SaveFormat.Pptx, pptxOptions);

        // Clean up resources
        pres.Dispose();
    }
}