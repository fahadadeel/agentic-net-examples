using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OptimizePresentationImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (adjust as needed)
            string imagePath = "image.jpg";
            string outputPptxPath = "optimized.pptx";
            string outputPdfPath = "optimized.pdf";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add the image once to the presentation's image collection
            Aspose.Slides.IPPImage sharedImage;
            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                sharedImage = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            }

            // Place the shared image on the master slide (reused graphics)
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];
            Aspose.Slides.IPictureFrame masterPicture = (Aspose.Slides.IPictureFrame)masterSlide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0, 0, 200, 200,
                sharedImage);
            // Compress the image on the master (reasonable resolution)
            masterPicture.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi150);

            // Add the same image to the first slide using the shared resource
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            Aspose.Slides.IPictureFrame slidePicture = (Aspose.Slides.IPictureFrame)firstSlide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                300, 0, 200, 200,
                sharedImage);
            // Compress the image on the slide as well
            slidePicture.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi150);

            // Save the presentation in PPTX format (required before PDF conversion)
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Prepare PDF options with best image compression
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.BestImagesCompressionRatio = true;

            // Save the presentation as PDF using the compression options
            presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Clean up
            presentation.Dispose();
        }
    }
}