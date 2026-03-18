using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartAxisCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Data");

                // Customize the horizontal (category) axis
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.HasTitle = true;
                horizontalAxis.Title.AddTextFrameForOverriding("Quarter");
                horizontalAxis.IsAutomaticMaxValue = false;
                horizontalAxis.MaxValue = 5;
                horizontalAxis.IsAutomaticMinValue = false;
                horizontalAxis.MinValue = 0;
                horizontalAxis.IsVisible = true;
                horizontalAxis.NumberFormat = "0";

                // Customize the vertical (value) axis
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.HasTitle = true;
                verticalAxis.Title.AddTextFrameForOverriding("Revenue (USD)");
                verticalAxis.IsAutomaticMaxValue = false;
                verticalAxis.MaxValue = 200000;
                verticalAxis.IsAutomaticMinValue = false;
                verticalAxis.MinValue = 0;
                verticalAxis.MajorUnit = 50000;
                verticalAxis.NumberFormat = "#,##0";
                verticalAxis.IsVisible = true;

                // Save the presentation
                pres.Save("CustomizedChartAxes.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}