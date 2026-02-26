using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Output file path
        System.String outPath = "FormattedPresentation.pptx";

        // Add a rectangle auto shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100f,   // X coordinate
            100f,   // Y coordinate
            400f,   // Width
            200f    // Height
        );

        // Add a text frame with sample text
        shape.AddTextFrame("Column 1 text. Column 2 text. Column 3 text.");

        // Get the text frame format for column settings
        Aspose.Slides.TextFrameFormat format = (Aspose.Slides.TextFrameFormat)shape.TextFrame.TextFrameFormat;

        // Set the number of columns
        format.ColumnCount = 3;

        // Set spacing between columns (double value)
        format.ColumnSpacing = 15.0;

        // Set autofit mode to resize shape to fit text
        format.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Set rotation angle (float literal with 'F' suffix)
        format.RotationAngle = 0F;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}