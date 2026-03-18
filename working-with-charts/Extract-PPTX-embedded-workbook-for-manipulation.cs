using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExtractEmbeddedWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, output presentation and extracted workbook
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string workbookPath = "extractedWorkbook.xlsx";

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the first shape on the first slide is a chart
                    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Access the chart data workbook (embedded Excel workbook)
                    IChartDataWorkbook chartWorkbook = chart.ChartData.ChartDataWorkbook;

                    // Read the embedded workbook into a memory stream
                    IChartData chartData = chart.ChartData;
                    using (MemoryStream workbookStream = chartData.ReadWorkbookStream())
                    {
                        // Save the workbook to a file for further manipulation
                        using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create, FileAccess.Write))
                        {
                            workbookStream.WriteTo(fileStream);
                        }
                    }

                    // Save the presentation (required before exit)
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Workbook extracted to: " + workbookPath);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}