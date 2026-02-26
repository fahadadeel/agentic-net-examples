using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set values in cells B2 and B3
        workbook.GetCell(0, 1, 1).Value = 2;
        workbook.GetCell(0, 2, 1).Value = 3;

        // Set formula in cell B4 to sum B2 and B3
        workbook.GetCell(0, 3, 1).Formula = "B2+B3";

        // Calculate all formulas
        workbook.CalculateFormulas();

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "WorksheetFormulas.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}