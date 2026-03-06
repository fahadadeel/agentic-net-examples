using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (the presentation contains one empty slide by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will hold the FAQ text
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // X position
            50,   // Y position
            600,  // Width
            400   // Height
        );

        // Cast the shape to IAutoShape to add a text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(
            "FAQ\n" +
            "Q1: What is Aspose.Slides?\n" +
            "A1: A .NET library for working with PowerPoint files.\n" +
            "Q2: How to create a presentation?\n" +
            "A2: Use the Presentation class.\n" +
            "Q3: How to add text?\n" +
            "A3: Add a shape and a TextFrame."
        );

        // Save the presentation to a file
        presentation.Save("FAQPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}