using System;

namespace AddTreemapSunburstDataPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // -------------------- Treemap Chart --------------------
            Aspose.Slides.Charts.IChart treemapChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Treemap, 0f, 0f, 500f, 400f);
            treemapChart.ChartData.Categories.Clear();
            treemapChart.ChartData.Series.Clear();
            Aspose.Slides.Charts.IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;
            treemapWb.Clear(0);

            // Branch 1
            Aspose.Slides.Charts.IChartCategory leaf = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, 1, 0, "Stem1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch1");
            treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 2, 0, "Leaf2"));
            leaf = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, 3, 0, "Stem2"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
            treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 4, 0, "Leaf4"));

            // Branch 2
            leaf = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, 5, 0, "Stem3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem3");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch2");
            treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 6, 0, "Leaf6"));
            leaf = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, 7, 0, "Stem4"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem4");
            treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 8, 0, "Leaf8"));

            // Series and data points
            Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Treemap);
            treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 1, 1, 10));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 2, 1, 20));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 3, 1, 30));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 4, 1, 40));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 5, 1, 50));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 6, 1, 60));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 7, 1, 70));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 8, 1, 80));
            treemapSeries.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // -------------------- Sunburst Chart --------------------
            Aspose.Slides.Charts.IChart sunburstChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Sunburst, 520f, 0f, 500f, 400f);
            sunburstChart.ChartData.Categories.Clear();
            sunburstChart.ChartData.Series.Clear();
            Aspose.Slides.Charts.IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;
            sunburstWb.Clear(0);

            // Branch 1
            Aspose.Slides.Charts.IChartCategory sunLeaf = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, 1, 0, "Stem1"));
            sunLeaf.GroupingLevels.SetGroupingItem(0, "Stem1");
            sunLeaf.GroupingLevels.SetGroupingItem(1, "Branch1");
            sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 2, 0, "Leaf2"));
            sunLeaf = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, 3, 0, "Stem2"));
            sunLeaf.GroupingLevels.SetGroupingItem(0, "Stem2");
            sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 4, 0, "Leaf4"));

            // Branch 2
            sunLeaf = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, 5, 0, "Stem3"));
            sunLeaf.GroupingLevels.SetGroupingItem(0, "Stem3");
            sunLeaf.GroupingLevels.SetGroupingItem(1, "Branch2");
            sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 6, 0, "Leaf6"));
            sunLeaf = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, 7, 0, "Stem4"));
            sunLeaf.GroupingLevels.SetGroupingItem(0, "Stem4");
            sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 8, 0, "Leaf8"));

            // Series and data points
            Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Sunburst);
            sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 1, 1, 10));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 2, 1, 20));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 3, 1, 30));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 4, 1, 40));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 5, 1, 50));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 6, 1, 60));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 7, 1, 70));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 8, 1, 80));

            // Save the presentation
            pres.Save("TreemapSunburst.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}