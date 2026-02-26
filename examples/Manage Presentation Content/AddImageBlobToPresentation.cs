using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory
        System.String outDir = "output";
        if (!System.IO.Directory.Exists(outDir))
            System.IO.Directory.CreateDirectory(outDir);

        // Paths for image and output presentation
        System.String imagePath = "large_image.jpg";
        System.String outputPath = System.IO.Path.Combine(outDir, "presentationWithLargeImage.ppt");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add image as BLOB with KeepLocked behavior
        using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            Aspose.Slides.IPPImage img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        }

        // Save the presentation in PPT format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        pres.Dispose();
    }
}