using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionWienerApngProcessor
{
    static void Main()
    {
        // Paths to the source and destination APNG files
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to ApngImage to access frame collection
            ApngImage apng = (ApngImage)image;

            // Iterate through each frame in the animation
            foreach (ApngFrame frame in apng.Frames)
            {
                // Apply the Motion Wiener filter to the entire frame
                // Length = 10, Brightness = 1.0, Angle = 90 degrees
                frame.Filter(
                    frame.Bounds,
                    new MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the processed APNG while preserving animation integrity
            apng.Save(outputPath);
        }
    }
}