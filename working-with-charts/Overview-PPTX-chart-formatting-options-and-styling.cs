using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // -------------------------------------------------
            // 1. Clustered Column Chart – basic formatting
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart columnChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
            columnChart.HasTitle = true;
            columnChart.ChartTitle.AddTextFrameForOverriding("Sales Overview");
            columnChart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            columnChart.ChartTitle.Height = 20;

            // Enable data labels for the first series
            columnChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Set gap width between column clusters (set-gap-width rule)
            columnChart.ChartData.Series[0].ParentSeriesGroup.GapWidth = 150; // 150%

            // Prepare workbook and clear default data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = columnChart.ChartData.ChartDataWorkbook;
            columnChart.ChartData.Series.Clear();
            columnChart.ChartData.Categories.Clear();

            // Add categories (X‑axis labels)
            columnChart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
            columnChart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));
            columnChart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Q3"));
            columnChart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Q4"));

            // Add two series
            Aspose.Slides.Charts.IChartSeries series2019 = columnChart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "2019"), columnChart.Type);
            Aspose.Slides.Charts.IChartSeries series2020 = columnChart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "2020"), columnChart.Type);

            // Populate series data
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 120));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 150));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 170));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 1, 200));

            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 130));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 160));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 180));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 2, 210));

            // Format series – fill and outline
            series2019.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2019.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;
            series2019.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            series2019.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;

            series2020.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2020.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;
            series2020.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            series2020.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkGreen;

            // -------------------------------------------------
            // 2. Pie Chart – automatic slice colors
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart pieChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 600, 50, 400, 300);
            pieChart.HasTitle = true;
            pieChart.ChartTitle.AddTextFrameForOverriding("Market Share");
            pieChart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            pieChart.ChartTitle.Height = 20;

            Aspose.Slides.Charts.IChartDataWorkbook pieWorkbook = pieChart.ChartData.ChartDataWorkbook;
            pieChart.ChartData.Series.Clear();
            pieChart.ChartData.Categories.Clear();

            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 1, 0, "Product A"));
            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 2, 0, "Product B"));
            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 3, 0, "Product C"));

            Aspose.Slides.Charts.IChartSeries pieSeries = pieChart.ChartData.Series.Add(
                pieWorkbook.GetCell(0, 0, 1, "Share"), pieChart.Type);
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 1, 1, 45));
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 2, 1, 30));
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 3, 1, 25));

            // Enable varied colors for each slice (setting-automic-pie-chart-slice-colors rule)
            pieSeries.ParentSeriesGroup.IsColorVaried = true;

            // -------------------------------------------------
            // 3. Doughnut Chart – custom hole size
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart doughnutChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut, 50, 500, 400, 300);
            doughnutChart.HasTitle = true;
            doughnutChart.ChartTitle.AddTextFrameForOverriding("Revenue Distribution");
            doughnutChart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            doughnutChart.ChartTitle.Height = 20;

            Aspose.Slides.Charts.IChartDataWorkbook doughnutWorkbook = doughnutChart.ChartData.ChartDataWorkbook;
            doughnutChart.ChartData.Series.Clear();
            doughnutChart.ChartData.Categories.Clear();

            doughnutChart.ChartData.Categories.Add(doughnutWorkbook.GetCell(0, 1, 0, "Online"));
            doughnutChart.ChartData.Categories.Add(doughnutWorkbook.GetCell(0, 2, 0, "Retail"));
            doughnutChart.ChartData.Categories.Add(doughnutWorkbook.GetCell(0, 3, 0, "Wholesale"));

            Aspose.Slides.Charts.IChartSeries doughnutSeries = doughnutChart.ChartData.Series.Add(
                doughnutWorkbook.GetCell(0, 0, 1, "Revenue"), doughnutChart.Type);
            doughnutSeries.DataPoints.AddDataPointForDoughnutSeries(doughnutWorkbook.GetCell(0, 1, 1, 50));
            doughnutSeries.DataPoints.AddDataPointForDoughnutSeries(doughnutWorkbook.GetCell(0, 2, 1, 30));
            doughnutSeries.DataPoints.AddDataPointForDoughnutSeries(doughnutWorkbook.GetCell(0, 3, 1, 20));

            // Set the doughnut hole size to 60 %
            doughnutSeries.ParentSeriesGroup.DoughnutHoleSize = 60;

            // -------------------------------------------------
            // 4. Data Point Callout – styling via IChartDataPoint.Format
            // -------------------------------------------------
            // Enable callout for the first series data labels
            columnChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Access the first data point
            Aspose.Slides.Charts.IChartDataPoint firstPoint = columnChart.ChartData.Series[0].DataPoints[0];

            // Style the callout using the data point's Format (cs1061 rule fix)
            firstPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            firstPoint.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Yellow;
            firstPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            firstPoint.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Orange;

            // Show category name inside the callout
            firstPoint.Label.DataLabelFormat.ShowCategoryName = true;

            // -------------------------------------------------
            // 5. Trend Line – adding and formatting
            // -------------------------------------------------
            Aspose.Slides.Charts.ITrendline linearTrend = columnChart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            linearTrend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            linearTrend.DisplayEquation = false;
            linearTrend.DisplayRSquaredValue = false;

            // -------------------------------------------------
            // 6. Automatic Series Color – using NotDefined fill
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart autoColorChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 600, 400, 400, 300);
            Aspose.Slides.Charts.IChartDataWorkbook autoWorkbook = autoColorChart.ChartData.ChartDataWorkbook;
            autoColorChart.ChartData.Series.Clear();
            autoColorChart.ChartData.Categories.Clear();

            autoColorChart.ChartData.Categories.Add(autoWorkbook.GetCell(0, 1, 0, "Jan"));
            autoColorChart.ChartData.Categories.Add(autoWorkbook.GetCell(0, 2, 0, "Feb"));
            autoColorChart.ChartData.Categories.Add(autoWorkbook.GetCell(0, 3, 0, "Mar"));

            Aspose.Slides.Charts.IChartSeries autoSeries = autoColorChart.ChartData.Series.Add(
                autoWorkbook.GetCell(0, 0, 1, "Sales"), autoColorChart.Type);
            autoSeries.DataPoints.AddDataPointForBarSeries(autoWorkbook.GetCell(0, 1, 1, 100));
            autoSeries.DataPoints.AddDataPointForBarSeries(autoWorkbook.GetCell(0, 2, 1, 120));
            autoSeries.DataPoints.AddDataPointForBarSeries(autoWorkbook.GetCell(0, 3, 1, 140));

            // Set FillType to NotDefined so the chart uses automatic colors (automatic-chart-seriescolor rule)
            autoSeries.Format.Fill.FillType = Aspose.Slides.FillType.NotDefined;

            // -------------------------------------------------
            // Save the presentation
            // -------------------------------------------------
            presentation.Save("ChartFormattingDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}