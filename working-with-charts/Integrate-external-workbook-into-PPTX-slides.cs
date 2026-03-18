using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Import;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the output presentation and the external Excel workbook
            string presentationPath = "output.pptx";
            string workbookPath = "data.xlsx";
            string worksheetName = "Sheet1";
            string chartName = "Chart 1";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a chart from the external workbook (linked, not embedded)
                ExcelWorkbookImporter.AddChartFromWorkbook(
                    pres.Slides[0].Shapes,
                    50f,
                    50f,
                    workbookPath,
                    worksheetName,
                    chartName,
                    false);

                // Save the presentation
                pres.Save(presentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}