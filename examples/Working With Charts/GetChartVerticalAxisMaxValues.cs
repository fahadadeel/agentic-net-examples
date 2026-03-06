using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a chart
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    // Access the vertical axis of the chart
                    Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;

                    // Retrieve the maximum value set on the vertical axis
                    double maxValue = verticalAxis.MaxValue;

                    Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Vertical Axis MaxValue = {maxValue}");
                }
            }
        }

        // Save the presentation (unchanged)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}