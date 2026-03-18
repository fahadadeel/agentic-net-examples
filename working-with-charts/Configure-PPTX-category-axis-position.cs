using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AxisPositionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                    // Configure the category (horizontal) axis position
                    IAxis categoryAxis = chart.Axes.HorizontalAxis;
                    categoryAxis.Position = AxisPositionType.Bottom;

                    // Configure the value (vertical) axis position
                    IAxis valueAxis = chart.Axes.VerticalAxis;
                    valueAxis.Position = AxisPositionType.Left;

                    // Save the presentation
                    presentation.Save("AxisPositionDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}