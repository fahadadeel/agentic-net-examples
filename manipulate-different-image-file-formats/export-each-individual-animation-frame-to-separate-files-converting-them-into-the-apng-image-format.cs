using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string sourceFile = "animation.webp";

// Load the multi‑frame image (e.g., animated WebP, GIF, etc.)
using (Image image = Image.Load(sourceFile))
{
    int frameCount = image.PageCount;

    // Iterate through each frame
    for (int i = 0; i < frameCount; i++)
    {
        // Obtain the current frame as a RasterImage
        using (RasterImage frame = (RasterImage)image.Frames[i])
        {
            // Define output file name for the individual frame
            string outputFile = $"frame_{i}.png";

            // Save the single frame as an APNG file (single‑frame animation)
            frame.Save(outputFile, new ApngOptions());
        }
    }
}