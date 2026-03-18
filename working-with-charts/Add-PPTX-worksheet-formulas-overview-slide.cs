using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a chart with worksheet formulas on the first slide
            Aspose.Slides.ISlide chartSlide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = chartSlide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells and set a formula
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Add an overview slide describing the worksheet formulas
            Aspose.Slides.ISlide overviewSlide = presentation.Slides.AddEmptySlide(
                presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleOnly));
            Aspose.Slides.IAutoShape overviewShape = overviewSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 300);
            Aspose.Slides.ITextFrame textFrame = overviewShape.AddTextFrame(
                "Worksheet Formulas Overview\n" +
                "B2 = 2\n" +
                "B3 = 3\n" +
                "B4 = B2+B3 (calculated as 5)");
            textFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            string outputPath = System.IO.Path.Combine(
                System.IO.Directory.GetCurrentDirectory(),
                "WorksheetFormulasOverview.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}