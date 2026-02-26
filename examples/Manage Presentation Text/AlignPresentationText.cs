using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("ParagraphsAlignment.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Get the first and second placeholders as AutoShape and retrieve their TextFrames
        Aspose.Slides.ITextFrame tf1 = ((Aspose.Slides.IAutoShape)slide.Shapes[0]).TextFrame;
        Aspose.Slides.ITextFrame tf2 = ((Aspose.Slides.IAutoShape)slide.Shapes[1]).TextFrame;

        // Set new text for both placeholders
        tf1.Text = "Center Align by Aspose";
        tf2.Text = "Center Align by Aspose";

        // Retrieve the first paragraph of each TextFrame
        Aspose.Slides.IParagraph para1 = tf1.Paragraphs[0];
        Aspose.Slides.IParagraph para2 = tf2.Paragraphs[0];

        // Align the paragraphs to center
        para1.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
        para2.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Save the modified presentation
        pres.Save("Centeralign_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}