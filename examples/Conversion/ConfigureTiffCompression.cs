using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create and configure TiffOptions for compression
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW; // Set desired compression type

            // Save the presentation as a TIFF file with the specified options
            presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}