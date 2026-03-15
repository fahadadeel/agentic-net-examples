using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.EmfPlus.Objects;

class Program
{
    static void Main()
    {
        // Input EMF file path
        string inputPath = "input.emf";
        // Output EMF file path
        string outputPath = "output.emf";

        // Load the EMF image using Aspose.Imaging's unified load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to the specific EmfImage type
            EmfImage emfImage = (EmfImage)image;

            // Create a blur effect object and configure its properties
            EmfPlusBlurEffect blurEffect = new EmfPlusBlurEffect
            {
                BlurRadius = 5.0f,   // Radius in pixels (0.0 – 255.0)
                ExpandEdge = true   // Expand bitmap edges to accommodate the blur
            };

            // Add the blur effect to the EMF records collection.
            // This inserts the effect into the vector drawing stream.
            emfImage.Records.Add(blurEffect);

            // Save the modified EMF image to the specified output file
            emfImage.Save(outputPath);
        }
    }
}