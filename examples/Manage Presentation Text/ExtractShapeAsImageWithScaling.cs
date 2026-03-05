using System;
using System.Drawing.Imaging;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var shapeImagePath = "shape_image.png";
        var outputPresentationPath = "output.pptx";

        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            var slide = presentation.Slides[0];
            var shape = slide.Shapes[0];
            var image = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f);
            image.Save(shapeImagePath, ImageFormat.Png);

            // Save the presentation before exiting
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}