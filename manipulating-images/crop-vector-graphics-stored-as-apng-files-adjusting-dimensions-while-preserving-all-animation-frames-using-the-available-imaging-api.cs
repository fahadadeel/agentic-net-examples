using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

string inputPath = "input.apng";
string outputPath = "output_cropped.apng";

using (ApngImage apng = (ApngImage)Image.Load(inputPath))
{
    // Define how many pixels to remove from each side.
    int leftShift = 10;   // pixels to cut from the left
    int rightShift = 10;  // pixels to cut from the right
    int topShift = 10;    // pixels to cut from the top
    int bottomShift = 10; // pixels to cut from the bottom

    // Crop all frames of the APNG. The Crop method works on the whole image
    // and automatically applies the operation to each animation frame.
    apng.Crop(leftShift, rightShift, topShift, bottomShift);

    // Save the cropped animation, preserving all frames.
    apng.Save(outputPath);
}