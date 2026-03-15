using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file (animated or static)
        string inputGifPath = "input.gif";
        // Output APNG file (lossless PNG based animation)
        string outputApngPath = "output.apng";

        // Load the GIF image
        using (Image gifImage = Image.Load(inputGifPath))
        {
            // Save as APNG using default options (lossless compression)
            gifImage.Save(outputApngPath, new ApngOptions());
        }

        Console.WriteLine("Conversion completed: GIF -> APNG (lossless).");
    }
}