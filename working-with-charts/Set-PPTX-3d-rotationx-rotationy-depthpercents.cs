using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlides3DChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a slide
                ISlide slide = presentation.Slides[0];

                // Add a 3D Pie chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie3D, 50, 50, 500, 400);

                // Configure 3D rotation properties
                chart.Rotation3D.RotationX = -30;          // Rotate around X-axis
                chart.Rotation3D.RotationY = 45;           // Rotate around Y-axis
                chart.Rotation3D.DepthPercents = 200;      // Set depth percentage

                // Save the presentation
                presentation.Save("3DChartPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}