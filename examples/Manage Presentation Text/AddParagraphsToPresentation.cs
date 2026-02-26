using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);
        shape.AddTextFrame(" ");
        var textFrame = shape.TextFrame;
        textFrame.Paragraphs.Clear();

        var paragraph1 = new Aspose.Slides.Paragraph();
        var portion1a = new Aspose.Slides.Portion();
        portion1a.Text = "First paragraph, first portion. ";
        var portion1b = new Aspose.Slides.Portion();
        portion1b.Text = "Second portion.";
        paragraph1.Portions.Add(portion1a);
        paragraph1.Portions.Add(portion1b);
        textFrame.Paragraphs.Add(paragraph1);

        var paragraph2 = new Aspose.Slides.Paragraph();
        var portion2a = new Aspose.Slides.Portion();
        portion2a.Text = "Second paragraph, only portion.";
        paragraph2.Portions.Add(portion2a);
        textFrame.Paragraphs.Add(paragraph2);

        presentation.Save("MultipleParagraphs.pptx", SaveFormat.Pptx);
    }
}