using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Load the existing APNG image (preserves all animation frames)
        using (ApngImage apng = (ApngImage)Image.Load("input.apng"))
        {
            // Iterate through each frame and apply the desired rotation/flip
            for (int i = 0; i < apng.PageCount; i++)
            {
                // Set the current frame as the active one
                apng.ActiveFrameIndex = i;

                // Example: rotate 90 degrees clockwise without flipping
                // Change RotateFlipType to achieve other transformations
                apng.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            // Save the transformed APNG, keeping the animation intact
            apng.Save("output.apng");
        }
    }
}