using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChangeSeriesName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation (lifecycle rule)
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Access the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Index of the default worksheet (usually 0)
                int defaultWorksheetIndex = 0;

                // Change the name of the first series.
                // Series names are stored in the first row of the worksheet.
                // Column 1 (zero‑based) holds the name of the first series.
                Aspose.Slides.Charts.IChartDataCell nameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "New Series Name");
                // The GetCell method sets the cell value to the provided string,
                // effectively updating the series name in the chart.
            }

            // Save the presentation before exit (authoring rule)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}