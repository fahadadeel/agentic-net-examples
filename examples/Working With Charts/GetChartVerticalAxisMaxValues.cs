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
                if (shape is Aspose.Slides.Charts.IChart)
                {
                    Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;

                    // Validate chart layout to get actual axis values
                    chart.ValidateChartLayout();

                    // Get the vertical axis
                    Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;

                    // Retrieve the actual maximum value on the vertical axis
                    double actualMax = verticalAxis.ActualMaxValue;

                    // Output the value
                    Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Vertical Axis Actual Max Value = {actualMax}");
                }
            }
        }

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}