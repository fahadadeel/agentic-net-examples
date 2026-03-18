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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide's shape collection
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Configure the first series to show values with two decimal places
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00";

            // Save the presentation
            pres.Save("ChartDataLabelPrecision.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}