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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the specific slide (e.g., second slide)
                ISlide slide = pres.Slides[1];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Data");

                // Enable legend and set its position
                chart.HasLegend = true;
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}