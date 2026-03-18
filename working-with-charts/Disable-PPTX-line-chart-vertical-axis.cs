using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DisableVerticalAxis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a chart
                        IChart chart = shape as IChart;
                        if (chart != null && chart.Type == ChartType.Line)
                        {
                            // Disable the vertical axis visibility
                            IAxis verticalAxis = chart.Axes.VerticalAxis;
                            verticalAxis.IsVisible = false;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}