using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Access error bars formats for X and Y directions
        Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

        // Make error bars visible
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;

        // Set error bars to use custom values
        errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
        errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

        // Get the data points collection of the series
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;

        // Specify that custom error values are literal doubles
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Assign custom error values to each data point
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
        }

        // Save the presentation
        string outputPath = "AddCustomErrorBarValues.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}