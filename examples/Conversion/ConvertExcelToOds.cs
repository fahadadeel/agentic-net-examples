using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths
        System.String dataDir = "C:\\Data\\";
        System.String excelPath = System.IO.Path.Combine(dataDir, "input.xlsx");
        System.String outputPath = System.IO.Path.Combine(dataDir, "output.odp"); // ODP is the closest OpenDocument format

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get a blank layout slide
        Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Add an empty slide based on the blank layout
        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

        // Import a chart from the Excel workbook
        Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
            slide.Shapes,
            10f,
            10f,
            excelPath,
            "Sheet1",
            "ColumnClustered",
            false);

        // Save the presentation (as ODP)
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
    }
}