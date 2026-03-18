using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a 3D clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 50, 50, 500, 400, true);

            // Configure 3D rotation properties
            IRotation3D rotation = chart.Rotation3D;
            rotation.RotationX = -30; // sbyte value between -90 and 90
            rotation.RotationY = 45;  // ushort value between 0 and 360
            rotation.DepthPercents = 200; // ushort value between 20 and 2000

            // Save the presentation
            presentation.Save("3DChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}