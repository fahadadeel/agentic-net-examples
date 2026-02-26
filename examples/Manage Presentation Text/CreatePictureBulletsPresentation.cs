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

        // Load an image to be used as a picture bullet
        using (FileStream imageStream = new FileStream("bullet.png", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage bulletImage = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will contain the text
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 200);

            // Add a text frame to the shape
            shape.AddTextFrame("Placeholder");

            // Access the text frame and clear default paragraphs
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
            textFrame.Paragraphs.Clear();

            // Create a new paragraph with picture bullet
            Aspose.Slides.IParagraph paragraph = new Aspose.Slides.Paragraph();
            paragraph.Text = "Bullet with picture";

            // Set bullet type to picture
            paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;

            // Assign the picture to the bullet
            paragraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;

            // Add the paragraph to the text frame
            textFrame.Paragraphs.Add(paragraph);
        }

        // Save the presentation
        presentation.Save("PictureBulletPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}