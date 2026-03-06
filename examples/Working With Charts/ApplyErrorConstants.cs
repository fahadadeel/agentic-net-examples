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

        // Add a rectangle shape to the slide
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Save the presentation before exiting
        presentation.Save("ErrorConstantsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation to simulate an invalid edit operation
        presentation.Dispose();

        try
        {
            // Attempt to modify the slide after disposal to trigger an edit exception
            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 150, 80);
        }
        catch (Aspose.Slides.PptxEditException ex)
        {
            // Handle the edit exception
            Console.WriteLine("Caught PptxEditException: " + ex.Message);
        }
    }
}