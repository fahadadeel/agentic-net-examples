using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // x
            50,   // y
            400,  // width
            100,  // height
            false // isGrouped
        );

        // Add an empty text frame to the shape
        shape.AddTextFrame("");

        // Clear any default portions
        shape.TextFrame.Paragraphs[0].Portions.Clear();

        // Create two portions with text
        Aspose.Slides.IPortion portion0 = new Aspose.Slides.Portion("Hello ");
        Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion("World!");

        // Add portions to the paragraph
        shape.TextFrame.Paragraphs[0].Portions.Add(portion0);
        shape.TextFrame.Paragraphs[0].Portions.Add(portion1);

        // Set default text style font heights
        presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24f;
        shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 20f;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 18f;
        shape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 22f;

        // Save the presentation
        presentation.Save("SetDefaultTextStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}