using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the source presentation and the output TIFF file
        string inputPath = "input.pptx";
        string outputPath = "output.tiff";

        // Load the presentation from the specified file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set up TIFF options for black-and-white conversion
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
        tiffOptions.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

        // Save the presentation as a multi-page black-and-white TIFF image
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Release resources
        presentation.Dispose();
    }
}