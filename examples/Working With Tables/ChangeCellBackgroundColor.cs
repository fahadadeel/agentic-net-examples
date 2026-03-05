using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table shape to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Get a specific cell (row 0, column 0) and set its background color
        Aspose.Slides.ICell cell = table[0, 0];
        cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

        // Save the presentation to disk
        presentation.Save("ChangeCellBackgroundColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}