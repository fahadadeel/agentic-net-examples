using System;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable the data table for the chart
        chart.HasDataTable = true;

        // Set number format for the first series values
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Save the presentation
        presentation.Save("ChartDataTableOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}