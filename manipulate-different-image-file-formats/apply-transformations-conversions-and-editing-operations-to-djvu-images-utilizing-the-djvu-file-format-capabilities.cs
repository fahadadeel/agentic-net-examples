using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputDir = "output";

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            foreach (var pageObj in djvu.Pages)
            {
                DjvuPage page = (DjvuPage)pageObj;

                page.Grayscale();
                page.Resize(page.Width / 2, page.Height / 2, ResizeType.NearestNeighbourResample);

                string pagePath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");
                page.Save(pagePath, new PngOptions());
            }

            if (djvu.Pages.Length >= 2)
            {
                DjvuPage firstPage = (DjvuPage)djvu.Pages[0];
                DjvuPage secondPage = (DjvuPage)djvu.Pages[1];

                int canvasWidth = firstPage.Width + secondPage.Width;
                int canvasHeight = Math.Max(firstPage.Height, secondPage.Height);

                var jpegOptions = new JpegOptions { Quality = 90 };
                jpegOptions.Source = new FileCreateSource(Path.Combine(outputDir, "combined.jpg"), false);

                using (RasterImage canvas = (RasterImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(firstPage, new Aspose.Imaging.Rectangle(0, 0, firstPage.Width, firstPage.Height));
                    graphics.DrawImage(secondPage, new Aspose.Imaging.Rectangle(firstPage.Width, 0, secondPage.Width, secondPage.Height));
                    canvas.Save();
                }
            }

            string pdfPath = Path.Combine(outputDir, "document.pdf");
            var pdfOptions = new PdfOptions();
            djvu.Save(pdfPath, pdfOptions);
        }
    }
}