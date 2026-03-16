using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input image files to be drawn onto the TIFF canvas
        string[] inputFiles = { "input1.jpg", "input2.png" };
        // Output TIFF file path
        string outputPath = "output.tif";

        // Determine canvas size based on input images
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var file in inputFiles)
        {
            using (Image img = Image.Load(file))
            {
                if (img.Width > canvasWidth)
                    canvasWidth = img.Width;
                canvasHeight += img.Height;
            }
        }

        // Configure TIFF options and bind the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create the TIFF canvas with the calculated dimensions
        using (Image tiffImage = Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(tiffImage);
            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw each input image onto the canvas
            int offsetY = 0;
            foreach (var file in inputFiles)
            {
                using (Image img = Image.Load(file))
                {
                    graphics.DrawImage(img, 0, offsetY);
                    offsetY += img.Height;
                }
            }

            // Save the TIFF image (output is already bound to the file)
            tiffImage.Save();
        }
    }
}