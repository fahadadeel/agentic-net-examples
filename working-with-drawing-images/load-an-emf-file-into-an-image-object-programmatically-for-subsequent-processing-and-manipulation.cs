using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file to be loaded
        string emfFilePath = @"C:\Images\sample.emf";

        // Load the EMF file using the unified Image.Load method
        using (Image image = Image.Load(emfFilePath))
        {
            // Cast the loaded Image to EmfImage for EMF‑specific operations
            EmfImage emfImage = (EmfImage)image;

            // Optional: cache data to ensure all records are loaded
            emfImage.CacheData();

            // Example: access basic properties for further processing
            Console.WriteLine($"Width: {emfImage.Width}");
            Console.WriteLine($"Height: {emfImage.Height}");

            // At this point, emfImage can be manipulated (resize, rotate, etc.)
            // Example: resize the image to 200x200 pixels
            emfImage.Resize(200, 200);

            // Save the modified image if needed (demonstrates usage of Save)
            string outputPath = @"C:\Images\sample_resized.emf";
            emfImage.Save(outputPath);
        }
    }
}