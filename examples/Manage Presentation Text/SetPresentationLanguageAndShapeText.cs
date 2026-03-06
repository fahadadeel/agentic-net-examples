using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Hello World");

        // Set the language identifier for the first portion of the text
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-US";

        // Save the presentation before exiting
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}