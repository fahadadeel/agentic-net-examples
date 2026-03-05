using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Set up data directory
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // Define image and output paths
        string imagePath = Path.Combine(dataDir, "image.png");
        string outPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide and its master slide
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IMasterSlide master = slide.LayoutSlide.MasterSlide;

        // Load image from file and add it to the presentation's image collection
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);

        // Add picture frame to the master slide using the image
        Aspose.Slides.IPictureFrame pictureFrame = master.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0,
            0,
            imgx.Width,
            imgx.Height,
            imgx);

        // Apply line formatting to the picture frame
        pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
        pictureFrame.LineFormat.Width = 5;
        pictureFrame.Rotation = 0;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}