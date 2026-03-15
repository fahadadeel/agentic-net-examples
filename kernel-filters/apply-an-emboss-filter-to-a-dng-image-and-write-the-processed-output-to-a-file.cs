using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EmbossDngExample
{
    static void Main()
    {
        // Path to the folder containing the source DNG file.
        string dataDir = @"c:\temp\";

        // Load the DNG image.
        using (Image image = Image.Load(dataDir + "input.dng"))
        {
            // Cast the generic Image to a DngImage to access DNG‑specific members.
            DngImage dngImage = (DngImage)image;

            // Apply an emboss filter to the entire image.
            // The Bounds property represents the full rectangular area of the image.
            dngImage.Filter(dngImage.Bounds, new EmbossFilterOptions());

            // Save the processed image. Here we choose PNG as the output format,
            // but any supported format can be used by providing the appropriate options.
            dngImage.Save(dataDir + "output_emboss.png", new PngOptions());
        }
    }
}