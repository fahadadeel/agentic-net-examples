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
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Enable data callouts for all data labels in this series
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Show value and series name in data labels
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowSeriesName = true;

            // Set a custom number format
            series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            series.Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

            // Style the callout fill for the first data point
            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[0];
            point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            point.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Save the presentation
            presentation.Save("CustomDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}