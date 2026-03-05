using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        using var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var callout = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Callout1, 100, 100, 300, 150);
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = Color.Yellow;
        callout.LineFormat.Width = 2;
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
        callout.TextFrame.Text = "Custom Callout";
        presentation.Save("CustomCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}