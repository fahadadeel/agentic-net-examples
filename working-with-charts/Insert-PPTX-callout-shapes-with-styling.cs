using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to act as a callout background
                Aspose.Slides.IAutoShape calloutShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);
                // Set fill color
                calloutShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                calloutShape.FillFormat.SolidFillColor.Color = Color.LightYellow;
                // Set line style
                calloutShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                calloutShape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkGray;
                calloutShape.LineFormat.Width = 2;

                // Add text to the callout
                calloutShape.AddTextFrame("This is a callout annotation.");
                // Format the text portion
                Aspose.Slides.IPortion portion = calloutShape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.FontHeight = 14;
                portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                presentation.Save("CalloutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}