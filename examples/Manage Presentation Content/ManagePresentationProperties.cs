using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation with one empty slide
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the document properties (read‑only property, but its members are writable)
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        docProps.Author = "John Doe";
        docProps.Title = "Managed Presentation";
        docProps.Subject = "Aspose.Slides Demo";
        docProps.Comments = "Created programmatically";

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Save the presentation in PPT format before exiting
        presentation.Save("ManagedPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}