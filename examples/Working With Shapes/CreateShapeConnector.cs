using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0f, 100f, 100f, 100f);

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 300f, 100f, 100f);

            // Add a bent connector shape
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0f, 0f, 10f, 10f);

            // Connect the shapes using the connector
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Reroute the connector to the shortest path
            connector.Reroute();

            // Save the presentation
            presentation.Save("Shapes-connector.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}