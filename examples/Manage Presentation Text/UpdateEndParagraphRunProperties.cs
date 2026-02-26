using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 10, 10, 200, 250);

        // Create the first paragraph with a single portion
        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.Portions.Add(new Aspose.Slides.Portion("First paragraph"));

        // Create the second paragraph with a single portion
        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.Portions.Add(new Aspose.Slides.Portion("Second paragraph"));

        // Define the end‑paragraph portion format (run properties)
        Aspose.Slides.PortionFormat endPortionFormat = new Aspose.Slides.PortionFormat();
        endPortionFormat.FontHeight = 48f;
        endPortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

        // Assign the end‑paragraph portion format to the second paragraph
        para2.EndParagraphPortionFormat = endPortionFormat;

        // Add paragraphs to the shape's text frame
        shape.TextFrame.Paragraphs.Add(para1);
        shape.TextFrame.Paragraphs.Add(para2);

        // Save the modified presentation as PPTX
        pres.Save("EndParagraphRunProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}