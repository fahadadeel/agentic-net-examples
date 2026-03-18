using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < presentation.Slides[slideIndex].Shapes.Count; shapeIndex++)
                    {
                        // Check if the shape is a chart
                        if (presentation.Slides[slideIndex].Shapes[shapeIndex] is IChart)
                        {
                            IChart chart = (IChart)presentation.Slides[slideIndex].Shapes[shapeIndex];
                            // Process only line charts
                            if (chart.Type == ChartType.Line)
                            {
                                // Disable the horizontal axis
                                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                                horizontalAxis.IsVisible = false;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}