using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Get the text frame and clear any existing paragraphs
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        textFrame.Paragraphs.Clear();

        // Create superscript paragraph
        Aspose.Slides.IParagraph superPar = new Aspose.Slides.Paragraph();
        Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion();
        portion1.Text = "Title ";
        superPar.Portions.Add(portion1);
        Aspose.Slides.IPortion superPortion = new Aspose.Slides.Portion();
        superPortion.PortionFormat.Escapement = 100f; // superscript
        superPortion.Text = "2";
        superPar.Portions.Add(superPortion);

        // Create subscript paragraph
        Aspose.Slides.IParagraph subPar = new Aspose.Slides.Paragraph();
        Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion();
        portion2.Text = "a";
        subPar.Portions.Add(portion2);
        Aspose.Slides.IPortion subPortion = new Aspose.Slides.Portion();
        subPortion.PortionFormat.Escapement = -100f; // subscript
        subPortion.Text = "i";
        subPar.Portions.Add(subPortion);

        // Add paragraphs to the text frame
        textFrame.Paragraphs.Add(superPar);
        textFrame.Paragraphs.Add(subPar);

        // Save the presentation
        string outPath = "SuperscriptSubscript.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Open the saved file
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
    }
}