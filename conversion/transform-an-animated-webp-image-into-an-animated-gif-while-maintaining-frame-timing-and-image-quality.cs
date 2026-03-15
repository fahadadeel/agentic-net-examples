using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
        {
            if (webpImage.Pages == null || webpImage.Pages.Length == 0)
                throw new InvalidOperationException("The WebP image does not contain any frames.");

            RasterImage firstRaster = (RasterImage)webpImage.Pages[0];
            int width = firstRaster.Width;
            int height = firstRaster.Height;

            using (GifImage gifImage = new GifImage())
            {
                using (GifFrameBlock firstGifBlock = new GifFrameBlock(width, height))
                {
                    int[] pixels = firstRaster.LoadArgb32Pixels(firstRaster.Bounds);
                    firstGifBlock.SaveArgb32Pixels(firstGifBlock.Bounds, pixels);
                    firstGifBlock.DelayTime = 10; // default 100 ms
                    gifImage.AddPage(firstGifBlock);
                }

                for (int i = 1; i < webpImage.Pages.Length; i++)
                {
                    RasterImage raster = (RasterImage)webpImage.Pages[i];
                    using (GifFrameBlock gifBlock = new GifFrameBlock(raster.Width, raster.Height))
                    {
                        int[] framePixels = raster.LoadArgb32Pixels(raster.Bounds);
                        gifBlock.SaveArgb32Pixels(gifBlock.Bounds, framePixels);

                        int durationMs = 100;
                        if (webpImage.Pages[i] is WebPFrameBlock webpFrame)
                        {
                            durationMs = webpFrame.Duration;
                        }

                        ushort delay = (ushort)Math.Max(1, durationMs / 10);
                        gifBlock.DelayTime = delay;

                        gifImage.AddPage(gifBlock);
                    }
                }

                GifOptions gifOptions = new GifOptions
                {
                    LoopsCount = 0 // infinite looping
                };

                gifImage.Save(outputPath, gifOptions);
            }
        }
    }
}