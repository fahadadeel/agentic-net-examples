using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // -------------------- Create Treemap Chart --------------------
                IChart treemapChart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);
                treemapChart.ChartData.Categories.Clear();
                treemapChart.ChartData.Series.Clear();

                IChartDataWorkbook wbTreemap = treemapChart.ChartData.ChartDataWorkbook;
                wbTreemap.Clear(0);

                // Add a single category with grouping
                IChartCategory category = treemapChart.ChartData.Categories.Add(wbTreemap.GetCell(0, "C1", "Root"));
                category.GroupingLevels.SetGroupingItem(0, "Group1");

                // Add series
                IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(ChartType.Treemap);
                treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points
                treemapSeries.DataPoints.AddDataPointForTreemapSeries(wbTreemap.GetCell(0, "D1", 30));
                treemapSeries.DataPoints.AddDataPointForTreemapSeries(wbTreemap.GetCell(0, "D2", 70));

                // Customize the first data point (index 0)
                IChartDataPoint treemapDataPoint = treemapSeries.DataPoints[0];
                IChartDataPointLevel treemapLevel = treemapDataPoint.DataPointLevels[0];

                // Set fill color of the data point level
                treemapLevel.Format.Fill.FillType = FillType.Solid;
                treemapLevel.Format.Fill.SolidFillColor.Color = Color.Red;

                // Set fill color of the data label text
                treemapLevel.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                treemapLevel.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Set parent label layout
                treemapSeries.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

                // -------------------- Create Sunburst Chart --------------------
                IChart sunburstChart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 500f, 500f, 400f);
                sunburstChart.ChartData.Categories.Clear();
                sunburstChart.ChartData.Series.Clear();

                IChartDataWorkbook wbSunburst = sunburstChart.ChartData.ChartDataWorkbook;
                wbSunburst.Clear(0);

                // Add categories with grouping (two levels)
                IChartCategory sunburstLeaf1 = sunburstChart.ChartData.Categories.Add(wbSunburst.GetCell(0, "C1", "Root"));
                sunburstLeaf1.GroupingLevels.SetGroupingItem(0, "Stem1");
                sunburstLeaf1.GroupingLevels.SetGroupingItem(1, "Branch1");

                IChartCategory sunburstLeaf2 = sunburstChart.ChartData.Categories.Add(wbSunburst.GetCell(0, "C2", "Leaf2"));
                sunburstLeaf2.GroupingLevels.SetGroupingItem(0, "Stem2");

                // Add series
                IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(ChartType.Sunburst);
                sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points
                sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wbSunburst.GetCell(0, "D1", 40));
                sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wbSunburst.GetCell(0, "D2", 60));

                // Customize the first data point (index 0)
                IChartDataPoint sunburstDataPoint = sunburstSeries.DataPoints[0];
                IChartDataPointLevel sunburstLevel = sunburstDataPoint.DataPointLevels[0];

                // Set fill color of the data point level
                sunburstLevel.Format.Fill.FillType = FillType.Solid;
                sunburstLevel.Format.Fill.SolidFillColor.Color = Color.Green;

                // Set fill color of the data label text
                sunburstLevel.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                sunburstLevel.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Save the presentation
                pres.Save("CustomizedTreemapSunburst.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}