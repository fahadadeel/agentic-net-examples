using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var dataDir = "data";
        var imagePath = Path.Combine(dataDir, "bullet.png");

        using (var presentation = new Aspose.Slides.Presentation())
        {
            var slide = presentation.Slides[0];

            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
            shape.AddTextFrame("Sample bullet text");
            var textFrame = shape.TextFrame;
            var paragraph = textFrame.Paragraphs[0];

            paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;

            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                var pictureImage = presentation.Images.AddImage(fs);
                paragraph.ParagraphFormat.Bullet.Picture.Image = pictureImage;
            }

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}