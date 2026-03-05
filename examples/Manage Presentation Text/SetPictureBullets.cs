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

        // Add a rectangle auto shape to hold text
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
        autoShape.AddTextFrame("Bullet with picture");

        // Access the first paragraph
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

        // Set bullet type to picture
        paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;

        // Load picture from file and add to presentation images collection
        string imagePath = "bullet.png";
        Aspose.Slides.IPPImage bulletImage;
        using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            bulletImage = presentation.Images.AddImage(fileStream);
        }

        // Assign the picture to the bullet
        Aspose.Slides.ISlidesPicture bulletPicture = paragraph.ParagraphFormat.Bullet.Picture;
        bulletPicture.Image = bulletImage;

        // Save the presentation
        presentation.Save("PictureBulletPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}