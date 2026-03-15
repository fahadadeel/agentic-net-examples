using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the source multi‑page APNG image (all frames are loaded automatically)
        using (Image sourceImage = Image.Load("source.apng"))
        {
            // Configure APNG save options to keep original metadata
            var saveOptions = new ApngOptions
            {
                KeepMetadata = true
            };

            // Export the loaded image (including all frames) to a new APNG file
            sourceImage.Save("exported.apng", saveOptions);
        }
    }
}