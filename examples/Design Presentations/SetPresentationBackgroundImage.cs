using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set the background to use a picture fill
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

        // Path to the background image file
        string dataDir = Directory.GetCurrentDirectory();
        string imagePath = Path.Combine(dataDir, "background.jpg"); // replace with your image file name

        // Load the image and add it to the presentation's image collection
        Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);

        // Assign the image to the slide background
        slide.Background.FillFormat.PictureFillFormat.Picture.Image = pptImage;

        // Save the presentation
        string outputPath = Path.Combine(dataDir, "OutputPresentation.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}