using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a Pie‑of‑Pie chart
                Aspose.Slides.Charts.IChart pieOfPieChart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PieOfPie, 50, 50, 400, 300);
                Aspose.Slides.Charts.IChartSeries pieSeries = pieOfPieChart.ChartData.Series[0];
                // Configure secondary plot settings
                pieSeries.ParentSeriesGroup.SecondPieSize = 150; // 150%
                pieSeries.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByValue;
                pieSeries.ParentSeriesGroup.PieSplitPosition = 30; // value threshold

                // Add a Bar‑of‑Pie chart
                Aspose.Slides.Charts.IChart barOfPieChart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.BarOfPie, 50, 400, 400, 300);
                Aspose.Slides.Charts.IChartSeries barSeries = barOfPieChart.ChartData.Series[0];
                // Configure secondary plot settings
                barSeries.ParentSeriesGroup.SecondPieSize = 120; // 120%
                barSeries.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
                barSeries.ParentSeriesGroup.PieSplitPosition = 20; // percentage threshold

                // Save the presentation
                pres.Save("SecondaryPlotSettings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}