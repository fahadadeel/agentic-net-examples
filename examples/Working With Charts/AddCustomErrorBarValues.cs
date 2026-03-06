using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            50f, 50f, 500f, 400f, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Enable custom error bars for both X and Y directions
        Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;
        errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
        errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Set the data source type for custom error bar values
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Assign custom error values for each data point
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
        }

        // Save the presentation
        presentation.Save("CustomErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}