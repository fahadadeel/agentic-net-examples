using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Add initial auto shapes to the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 100, 50);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 250, 100, 100, 50);

        // Add another auto shape to the same group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 175, 200, 100, 80);

        // Save the presentation
        pres.Save("GroupShapeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}