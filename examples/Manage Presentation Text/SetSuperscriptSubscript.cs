using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to hold the text
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Get the text frame of the shape and clear any existing paragraphs
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        textFrame.Paragraphs.Clear();

        // Create a paragraph for superscript text
        Aspose.Slides.IParagraph superPar = new Aspose.Slides.Paragraph();

        // Normal portion: "E = mc"
        Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion();
        portion1.Text = "E = mc";
        superPar.Portions.Add(portion1);

        // Superscript portion: "2"
        Aspose.Slides.IPortion superPortion = new Aspose.Slides.Portion();
        superPortion.PortionFormat.Escapement = 100; // 100% = superscript
        superPortion.Text = "2";
        superPar.Portions.Add(superPortion);

        // Create a paragraph for subscript text
        Aspose.Slides.IParagraph subPar = new Aspose.Slides.Paragraph();

        // Normal portion: "H"
        Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion();
        portion2.Text = "H";
        subPar.Portions.Add(portion2);

        // Subscript portion: "2"
        Aspose.Slides.IPortion subPortion = new Aspose.Slides.Portion();
        subPortion.PortionFormat.Escapement = -100; // -100% = subscript
        subPortion.Text = "2";
        subPar.Portions.Add(subPortion);

        // Add the paragraphs to the text frame
        textFrame.Paragraphs.Add(superPar);
        textFrame.Paragraphs.Add(subPar);

        // Save the presentation
        string outPath = "SuperscriptSubscript.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Open the saved file
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
    }
}