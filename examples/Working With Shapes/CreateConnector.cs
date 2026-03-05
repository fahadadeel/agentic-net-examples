using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector shape
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes using the connector
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Reroute the connector to take the shortest path
        connector.Reroute();

        // Save the presentation
        presentation.Save("Shapes-connector.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}