using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Get the default slide (first slide)
                ISlide defaultSlide = presentation.Slides[0];

                // Add empty slides for sections
                ISlide section1Slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                ISlide section1Slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                ISlide section2Slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Create sections and associate them with slides
                ISection section1 = presentation.Sections.AddSection("Section 1", section1Slide);
                ISection section2 = presentation.Sections.AddSection("Section 2", section2Slide);

                // Add a chart to the first slide of Section 1
                IChart chart = section1Slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 400, 300);

                // Prepare chart data
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));

                // Add a series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                IChartSeries series = chart.ChartData.Series[0];

                // Add data points
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));

                // Save the presentation
                presentation.Save("HierarchicalDataPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}