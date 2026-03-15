using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EPS and output files
        string epsPath = "input.eps";
        string pngPath = "output.png";
        string pdfPath = "output.pdf";

        // Load the EPS image
        using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
        {
            // Resize the image to 800x600 using high‑quality Lanczos resampling
            epsImage.Resize(800, 600, ResizeType.LanczosResample);

            // Rotate the image 90 degrees clockwise without flipping
            epsImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the transformed image as PNG
            epsImage.Save(pngPath, new PngOptions());

            // Save the transformed image as PDF
            epsImage.Save(pdfPath, new PdfOptions());
        }
    }
}