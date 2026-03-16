using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

string inputPath = "input.gif";
string outputPath = "output.gif";

using (GifImage gif = (GifImage)Image.Load(inputPath))
{
    // Remove all existing GIF blocks (frames), leaving the image empty.
    gif.ClearBlocks();

    // Save the cleared image; it now has no pixel data and represents a transparent canvas.
    gif.Save(outputPath);
}