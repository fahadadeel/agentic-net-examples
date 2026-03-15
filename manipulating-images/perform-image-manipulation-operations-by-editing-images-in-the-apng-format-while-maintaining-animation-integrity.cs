using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

string inputPath = "input.apng";
string outputPath = "output.apng";

// Load the existing APNG image
using (Image image = Image.Load(inputPath))
{
    // Cast to ApngImage to access frame collection
    ApngImage apng = (ApngImage)image;

    // Iterate through each frame and apply a brightness adjustment
    foreach (ApngFrame frame in apng.Pages)
    {
        // Increase brightness by 20 (value can be adjusted as needed)
        frame.AdjustBrightness(20);
    }

    // Save the modified APNG, preserving animation integrity
    apng.Save(outputPath);
}