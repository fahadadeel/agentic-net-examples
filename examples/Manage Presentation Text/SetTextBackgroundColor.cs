using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetTextBackgroundColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            autoShape.TextFrame.Text = "Sample Text";

            // Get the first portion of the first paragraph
            Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];

            // Set the background color of the text (using solid fill)
            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

            // Save the presentation
            presentation.Save("TextBackgroundColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}