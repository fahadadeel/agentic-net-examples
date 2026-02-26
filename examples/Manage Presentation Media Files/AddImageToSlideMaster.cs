using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImageToSlideMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
            string imagePath = Path.Combine(dataDir, "image.png");
            string outputPath = Path.Combine(dataDir, "PresentationWithMasterImage.pptx");

            // Read image bytes
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add image to the presentation's image collection
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Get the master slide of the first slide
            Aspose.Slides.IMasterSlide masterSlide = pres.Slides[0].LayoutSlide.MasterSlide;

            // Add picture frame to the master slide
            masterSlide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                10f,   // X position
                10f,   // Y position
                100f,  // Width
                100f,  // Height
                img);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}