using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAxesCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // ----- Customize Horizontal (Category) Axis -----
            Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            // Show axis title and set its text
            horizontalAxis.HasTitle = true;
            horizontalAxis.Title.AddTextFrameForOverriding("Months");
            // Rotate tick labels for better readability
            horizontalAxis.TickLabelRotationAngle = 45f;
            // Set major tick mark type
            horizontalAxis.MajorTickMark = TickMarkType.Outside;

            // ----- Customize Vertical (Value) Axis -----
            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
            // Disable automatic min/max and set explicit range
            verticalAxis.IsAutomaticMinValue = false;
            verticalAxis.MinValue = 0;
            verticalAxis.IsAutomaticMaxValue = false;
            verticalAxis.MaxValue = 100;
            // Show axis title and set its text
            verticalAxis.HasTitle = true;
            verticalAxis.Title.AddTextFrameForOverriding("Revenue (K)");
            // Disable automatic major unit and set a fixed major unit
            verticalAxis.IsAutomaticMajorUnit = false;
            verticalAxis.MajorUnit = 10;
            // Show major grid lines (default is visible)
            verticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
            verticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.LightGray;

            // ----- Hide Secondary Vertical Axis (if present) -----
            Aspose.Slides.Charts.IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
            secondaryVerticalAxis.IsVisible = false;

            // Save the presentation
            presentation.Save("ChartAxes_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}