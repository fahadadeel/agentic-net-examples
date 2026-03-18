using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace UpdateEmbeddedWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (adjust as needed)
            string dataDir = "Data" + Path.DirectorySeparatorChar;
            string inputPath = dataDir + "input.pptx";
            string outputPath = dataDir + "output.pptx";
            string workbookPath = dataDir + "data.xlsx";

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Assume the first shape is a chart
                    IChart chart = (IChart)slide.Shapes[0];

                    // Get chart data
                    IChartData chartData = chart.ChartData;

                    // Set external workbook and update chart data
                    ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

                    // Embed the workbook as an OLE object to keep data integrity
                    byte[] workbookBytes = File.ReadAllBytes(workbookPath);
                    IOleEmbeddedDataInfo oleDataInfo = new OleEmbeddedDataInfo(workbookBytes, "xlsx");

                    // Add OLE object frame covering the whole slide
                    IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(
                        0f,
                        0f,
                        pres.SlideSize.Size.Width,
                        pres.SlideSize.Size.Height,
                        oleDataInfo);

                    // Save the updated presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation updated and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}