using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a Treemap chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);

        // Clear default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        // Clear the workbook (index 0)
        wb.Clear(0);

        // Add hierarchical categories (leaves) with grouping levels
        // Branch 1
        Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem A");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch A1");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem B");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));
        // Branch 2
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 5"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem C");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch B1");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 6"));
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 7"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem D");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 8"));

        // Add a series for the treemap
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

        // Add data points (size values) for each leaf
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));

        // Set parent label layout to overlapping
        series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

        // Save the presentation
        pres.Save("HierarchicalData_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}