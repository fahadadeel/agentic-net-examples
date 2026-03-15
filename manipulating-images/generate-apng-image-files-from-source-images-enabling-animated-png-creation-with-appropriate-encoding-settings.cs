using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "not_animated.png";
        string outputPath = "raster_animation.png";

        const int AnimationDuration = 1000;
        const int FrameDuration = 70;

        using (Aspose.Imaging.RasterImage sourceImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)FrameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                apngImage.RemoveAllFrames();

                int numOfFrames = AnimationDuration / FrameDuration;
                int halfFrames = numOfFrames / 2;

                apngImage.AddFrame(sourceImage);

                for (int i = 1; i < numOfFrames - 1; ++i)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = i >= halfFrames ? numOfFrames - i - 1 : i;
                    lastFrame.AdjustGamma(gamma);
                }

                apngImage.AddFrame(sourceImage);
                apngImage.Save();
            }
        }
    }
}