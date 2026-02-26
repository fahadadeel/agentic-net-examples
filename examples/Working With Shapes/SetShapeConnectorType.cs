using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add two shapes to connect
            IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
            IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

            // Add a straight connector
            IConnector straightConnector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 0, 0, 10, 10);
            straightConnector.StartShapeConnectedTo = ellipse;
            straightConnector.EndShapeConnectedTo = rectangle;
            straightConnector.ShapeType = ShapeType.StraightConnector1;
            straightConnector.Reroute();

            // Add an elbow (bent) connector
            IConnector elbowConnector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
            elbowConnector.StartShapeConnectedTo = ellipse;
            elbowConnector.EndShapeConnectedTo = rectangle;
            elbowConnector.ShapeType = ShapeType.BentConnector2;
            elbowConnector.Reroute();

            // Add a curved connector
            IConnector curvedConnector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);
            curvedConnector.StartShapeConnectedTo = ellipse;
            curvedConnector.EndShapeConnectedTo = rectangle;
            curvedConnector.ShapeType = ShapeType.CurvedConnector2;
            curvedConnector.Reroute();

            // Save the presentation
            presentation.Save("ConnectorTypes.pptx", SaveFormat.Pptx);
        }
    }
}