using System;

namespace AsposeSlides3DChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a 3D clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
                50f,   // X position
                50f,   // Y position
                600f,  // Width
                400f   // Height
            );

            // Configure 3D rotation and depth
            Aspose.Slides.Charts.IRotation3D rotation = chart.Rotation3D;
            rotation.RotationX = 20;        // Rotate around X axis (degrees)
            rotation.RotationY = 30;        // Rotate around Y axis (degrees)
            rotation.DepthPercents = 150;   // Depth as percentage of chart width
            rotation.HeightPercents = 100;  // Height as percentage of chart width

            // Save the presentation to a PPTX file
            string outputPath = "3DChartPresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}