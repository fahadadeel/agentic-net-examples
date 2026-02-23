using System;

class Program
{
    static void Main()
    {
        // Define input Excel file and output XML file paths
        System.String dataDir = "Data";
        System.String excelPath = System.IO.Path.Combine(dataDir, "input.xlsx");
        System.String outputPath = System.IO.Path.Combine(dataDir, "output.xml");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get a blank layout slide
        Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Add an empty slide using the blank layout
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

        // Save the presentation as PowerPoint XML format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xml);
    }
}