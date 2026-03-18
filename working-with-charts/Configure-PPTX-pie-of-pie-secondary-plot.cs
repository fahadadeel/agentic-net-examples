using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add Pie-of-Pie chart
                IChart pieOfPieChart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 400, 300);
                pieOfPieChart.ChartData.Series.Clear();
                pieOfPieChart.ChartData.Categories.Clear();

                IChartDataWorkbook workbook = pieOfPieChart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Add series
                IChartSeries series1 = pieOfPieChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), pieOfPieChart.Type);
                series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 50));

                // Configure secondary plot settings via ParentSeriesGroup
                series1.ParentSeriesGroup.SecondPieSize = 150; // 150%
                series1.ParentSeriesGroup.PieSplitBy = PieSplitType.ByValue;
                series1.ParentSeriesGroup.PieSplitPosition = 25; // values less than 25 go to secondary

                // Add Bar-of-Pie chart
                IChart barOfPieChart = slide.Shapes.AddChart(ChartType.BarOfPie, 50, 400, 400, 300);
                barOfPieChart.ChartData.Series.Clear();
                barOfPieChart.ChartData.Categories.Clear();

                // Add categories
                barOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Cat 1"));
                barOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Cat 2"));
                barOfPieChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Cat 3"));

                // Add series
                IChartSeries series2 = barOfPieChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), barOfPieChart.Type);
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 40));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 50));

                // Configure secondary plot settings via ParentSeriesGroup
                series2.ParentSeriesGroup.SecondPieSize = 120;
                series2.ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
                series2.ParentSeriesGroup.PieSplitPosition = 30; // percent threshold

                // Save presentation
                pres.Save("SecondaryPlotSettings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}