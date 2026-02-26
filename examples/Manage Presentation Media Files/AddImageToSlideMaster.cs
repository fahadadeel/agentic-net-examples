using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the data directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Path to the image file to be added to the master slide
            string imageFileName = "heading.png";
            string imagePath = Path.Combine(dataDir, imageFileName);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];

            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img = pres.Images.AddImage(File.ReadAllBytes(imagePath));

            // Add a picture frame to the master slide (covering the whole slide)
            masterSlide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                pres.SlideSize.Size.Width,
                pres.SlideSize.Size.Height,
                img);

            // Save the presentation
            string outPath = Path.Combine(dataDir, "PresentationWithMasterImage.pptx");
            pres.Save(outPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}