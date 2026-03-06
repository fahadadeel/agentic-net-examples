using System;
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

        // Add a callout shape (Callout1) at position (100,100) with width 300 and height 150
        Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(ShapeType.Callout1, 100, 100, 300, 150);

        // Set the text of the callout
        callout.TextFrame.Text = "This is a callout";

        // Optionally format the text
        callout.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

        // Save the presentation
        presentation.Save("CalloutPresentation.pptx", SaveFormat.Pptx);
    }
}