using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <inputPath> <outputPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image (could be animated/multipage)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Determine canvas size from the first frame
            int width, height;
            IMultipageImage multipage = sourceImage as IMultipageImage;
            if (multipage != null && multipage.PageCount > 0)
            {
                using (RasterImage first = (RasterImage)multipage.Pages[0])
                {
                    width = first.Width;
                    height = first.Height;
                }
            }
            else
            {
                using (RasterImage ri = (RasterImage)sourceImage)
                {
                    width = ri.Width;
                    height = ri.Height;
                }
            }

            // APNG creation options
            ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // default 100 ms per frame
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, width, height))
            {
                // Masking export options (in‑memory)
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Common masking options for background removal
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Process each frame
                if (multipage != null)
                {
                    foreach (var pageObj in multipage.Pages)
                    {
                        using (RasterImage frame = (RasterImage)pageObj)
                        using (MaskingResult maskResult = new ImageMasking(frame).Decompose(maskingOptions))
                        using (RasterImage foreground = (RasterImage)maskResult[1].GetImage())
                        {
                            apng.AddFrame(foreground);
                        }
                    }
                }
                else
                {
                    using (RasterImage frame = (RasterImage)sourceImage)
                    using (MaskingResult maskResult = new ImageMasking(frame).Decompose(maskingOptions))
                    using (RasterImage foreground = (RasterImage)maskResult[1].GetImage())
                    {
                        apng.AddFrame(foreground);
                    }
                }

                // Save the resulting APNG
                apng.Save();
            }
        }
    }
}