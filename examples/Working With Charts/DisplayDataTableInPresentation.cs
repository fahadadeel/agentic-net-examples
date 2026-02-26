using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            System.String outputPath = "DisplayDataTable.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line,
                50f, 50f, 450f, 300f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Set number format for the first series values
            chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}