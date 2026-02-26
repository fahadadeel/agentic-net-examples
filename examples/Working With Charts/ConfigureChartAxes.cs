using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAxesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // ----- Configure Horizontal Axis -----
            Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            horizontalAxis.HasTitle = true;                                   // Enable axis title
            horizontalAxis.Title.AddTextFrameForOverriding("Horizontal Axis"); // Set title text
            horizontalAxis.MinValue = 0;                                      // Set minimum value
            horizontalAxis.MaxValue = 100;                                    // Set maximum value
            horizontalAxis.IsVisible = true;                                  // Ensure axis is visible

            // ----- Configure Vertical Axis -----
            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.HasTitle = true;                                     // Enable axis title
            verticalAxis.Title.AddTextFrameForOverriding("Vertical Axis");    // Set title text
            verticalAxis.IsLogarithmic = false;                               // Use linear scale
            verticalAxis.IsAutomaticMaxValue = false;                         // Allow custom max value
            verticalAxis.MaxValue = 200;                                      // Set custom maximum
            verticalAxis.IsAutomaticMinValue = false;                         // Allow custom min value
            verticalAxis.MinValue = 0;                                        // Set custom minimum

            // ----- Configure Series Axis (if needed) -----
            Aspose.Slides.Charts.IAxis seriesAxis = chart.Axes.SeriesAxis;
            seriesAxis.HasTitle = true;
            seriesAxis.Title.AddTextFrameForOverriding("Series Axis");

            // Save the presentation to disk
            pres.Save("ChartAxes_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}