using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Create a file stream for the output PNG image
        using (FileStream stream = new FileStream("output.png", FileMode.Create))
        {
            // Set up PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Instantiate Graphics and bind it to the image
                Graphics graphics = new Graphics(image);

                // Example operation: clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Additional drawing operations can be performed using 'graphics' here

                // Save changes to the image (the stream is already bound)
                image.Save();
            }
        }
    }
}