using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlides3DRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50,   // X position
                50,   // Y position
                400,  // Width
                300   // Height
            );

            // Set 3D rotation properties
            chart.Rotation3D.RotationX = (sbyte)30;   // Rotate around X-axis (Y direction)
            chart.Rotation3D.RotationY = (ushort)45; // Rotate around Y-axis (X direction)
            chart.Rotation3D.RightAngleAxes = false; // Use perspective
            chart.Rotation3D.Perspective = (byte)30; // Set perspective angle

            // Save the presentation
            presentation.Save("3DRotationChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}