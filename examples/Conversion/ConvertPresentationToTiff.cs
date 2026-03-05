using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";
        // Path for the output black‑and‑white TIFF file
        string outputPath = "output.tiff";

        // Load the presentation from file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create TIFF options and configure black‑and‑white conversion
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
            tiffOptions.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

            // Save the presentation as a multi‑page black‑and‑white TIFF image
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}