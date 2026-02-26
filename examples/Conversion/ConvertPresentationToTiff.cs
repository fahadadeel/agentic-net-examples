using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation file
            Presentation presentation = new Presentation("DemoFile.pptx");

            // Create TiffOptions and set custom pixel format
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;

            // Save the presentation as a multi-page TIFF image with the specified options
            presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, tiffOptions);
        }
    }
}