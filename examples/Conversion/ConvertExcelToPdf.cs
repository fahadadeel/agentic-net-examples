using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input Excel file and output PDF file
        string dataDir = "Data";
        string excelPath = Path.Combine(dataDir, "input.xlsx");
        string outputPath = Path.Combine(dataDir, "output.pdf");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a blank slide to host the chart
        Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

        // Import a chart from the Excel workbook onto the slide
        Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
            slide.Shapes,
            10f,
            10f,
            excelPath,
            "Sheet1",
            "Chart 1",
            false);

        // Save the presentation as a PDF document
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
    }
}