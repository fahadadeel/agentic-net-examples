using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Prepare CSV file
                StreamWriter writer = new StreamWriter("chart_data.csv", false, Encoding.UTF8);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        IChart chart = shape as IChart;

                        if (chart != null)
                        {
                            // Write a simple identifier for the chart
                            writer.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}");

                            // Retrieve chart data range (if the chart uses an embedded workbook)
                            string range = (chart.ChartData as ChartData).GetRange();
                            writer.WriteLine($"Data Range: {range}");
                            writer.WriteLine(); // Empty line for readability
                        }
                    }
                }

                // Close the writer
                writer.Flush();
                writer.Close();

                // Save the presentation (no modifications, but required by the task)
                presentation.Save("output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}