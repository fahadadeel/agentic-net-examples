using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (var slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (var shape in slide.Shapes)
                    {
                        // Process only chart shapes
                        if (shape is Aspose.Slides.Charts.IChart chart)
                        {
                            // Example: remove the second data point from the first series, if it exists
                            if (chart.ChartData.Series.Count > 0)
                            {
                                var series = chart.ChartData.Series[0];
                                if (series.DataPoints.Count > 1)
                                {
                                    // Remove data point at index 1
                                    series.DataPoints.RemoveAt(1);
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}