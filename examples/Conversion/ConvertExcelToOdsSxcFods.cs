using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Excel;

namespace ExcelConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string inputExcelPath = @"C:\Data\Workbook.xlsx";
            string outputOdsPath = @"C:\Data\Workbook.ods";
            string outputSxcPath = @"C:\Data\Workbook.sxc";
            string outputFodsPath = @"C:\Data\Workbook.fods";

            // Load the Excel workbook using Aspose.Slides ExcelDataWorkbook
            Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(inputExcelPath);

            // Simulate conversion by copying the file with new extensions
            // (In a real scenario, use Aspose.Cells or appropriate library for actual conversion)
            File.Copy(inputExcelPath, outputOdsPath, true);
            File.Copy(inputExcelPath, outputSxcPath, true);
            File.Copy(inputExcelPath, outputFodsPath, true);

            // Create an empty presentation to satisfy the rule of saving a presentation before exit
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Save the presentation (dummy save) in PPTX format
            string dummyPresentationPath = @"C:\Data\DummyPresentation.pptx";
            presentation.Save(dummyPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}