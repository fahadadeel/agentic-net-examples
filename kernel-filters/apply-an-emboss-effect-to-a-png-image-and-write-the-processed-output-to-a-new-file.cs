using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Filters;

string dir = @"c:\temp\";

// Load the PNG image from file
using (PngImage pngImage = new PngImage(Path.Combine(dir, "input.png")))
{
    // Apply the emboss filter to the entire image area
    Rectangle fullRect = new Rectangle(0, 0, pngImage.Width, pngImage.Height);
    pngImage.Filter(fullRect, new EmbossFilter());

    // Save the processed image to a new file
    pngImage.Save(Path.Combine(dir, "output_emboss.png"));
}