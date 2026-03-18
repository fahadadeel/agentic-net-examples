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
            string presentationPath = "LinkedChartPresentation.pptx";
            string workbookPath = "DataWorkbook.xlsx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,
                50f,
                400f,
                300f,
                true);

            // Get chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

            // Associate external workbook without updating chart data immediately
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, false);

            // Save the presentation
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}