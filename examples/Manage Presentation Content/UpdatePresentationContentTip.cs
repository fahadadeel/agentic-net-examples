using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add a rectangle shape that will contain the tip text
            Aspose.Slides.IAutoShape tipShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Add a text frame with the tip
            tipShape.AddTextFrame("Tip: Review the content before finalizing.");

            // Optionally set the fill color of the shape
            tipShape.FillFormat.FillType = FillType.Solid;
            tipShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightYellow;

            // Save the presentation in PPT format
            presentation.Save("ContentTip.ppt", SaveFormat.Ppt);
        }
    }
}