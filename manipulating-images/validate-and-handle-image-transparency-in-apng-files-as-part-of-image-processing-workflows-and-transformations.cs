using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class ApngTransparencyHandler
{
    static void Main()
    {
        // Paths to the source APNG and the processed output
        string inputPath = "input.apng";
        string outputPath = "output_processed.apng";

        // Load the APNG image using the provided Image.Load rule
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Determine whether the APNG already contains an alpha channel
            bool hasAlpha = apng.HasAlpha;

            // If the image lacks an alpha channel, define a transparent color to simulate transparency
            if (!hasAlpha)
            {
                // Example: treat pure magenta as fully transparent
                apng.TransparentColor = Aspose.Imaging.Color.Magenta;
                // The HasTransparentColor flag is read‑only; setting TransparentColor is sufficient
            }

            // Iterate through each frame (page) of the APNG
            foreach (var page in apng.Pages)
            {
                ApngFrame frame = (ApngFrame)page;

                // If a particular frame does not have an alpha channel, set its background to fully transparent
                if (!frame.HasAlpha)
                {
                    frame.BackgroundColor = Aspose.Imaging.Color.Transparent;
                }

                // Optional: ensure the frame uses alpha blending when rendered
                // (UseAlphaBlending is a read‑only property that reflects the current state)
                // No explicit setter is required; the presence of alpha in the frame enables blending
            }

            // Save the modified APNG using the provided Image.Save rule
            apng.Save(outputPath);
        }
    }
}