using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CreatePictureBullets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input image and output presentation paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputImagePath = Path.Combine(dataDir, "bullet.png");
            string outputPath = Path.Combine(dataDir, "PictureBullet.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a SmartArt diagram of type VerticalPictureList
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                50f,   // x
                50f,   // y
                400f,  // width
                300f,  // height
                Aspose.Slides.SmartArt.SmartArtLayoutType.VerticalPictureList);

            // Get the first node of the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[0];

            // Apply picture bullet if the BulletFillFormat is available
            if (node.BulletFillFormat != null)
            {
                // Load the image from file
                Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(inputImagePath);

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);

                // Set bullet fill to picture and assign the image
                node.BulletFillFormat.FillType = Aspose.Slides.FillType.Picture;
                node.BulletFillFormat.PictureFillFormat.Picture.Image = pptImage;
                node.BulletFillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}