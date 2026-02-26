using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Chart3DRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a clustered column chart to the first slide
                IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Set 3D rotation angles
                chart.Rotation3D.RotationX = 30; // Rotate around X-axis (Y direction)
                chart.Rotation3D.RotationY = 40; // Rotate around Y-axis (X direction)

                // Save the presentation
                pres.Save("Chart3DRotation.pptx", SaveFormat.Pptx);
            }
        }
    }
}