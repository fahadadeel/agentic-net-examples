using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Retrieve the first chart on the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Set an external workbook as the chart's data source
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook("data.xlsx");

            // Get the data source type of the chart
            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;

            // If the data source is an external workbook, output its path
            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                string externalPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("External workbook path: " + externalPath);
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}