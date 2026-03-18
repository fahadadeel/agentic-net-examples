using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;
            Aspose.Slides.Charts.IChart chart = shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 500);

            // Enable data point values for every series in the chart
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
                series.Labels.DefaultDataLabelFormat.ShowValue = true;
            }

            // Save the presentation
            pres.Save("EnableDataPointValues.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}