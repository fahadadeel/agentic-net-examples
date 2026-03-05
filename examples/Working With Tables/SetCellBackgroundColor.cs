using System;
using Aspose.Slides;
using System.Drawing;

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

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set the background color of the cell at row 0, column 0
        Aspose.Slides.ICell cell = table[0, 0];
        cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

        // Save the presentation
        presentation.Save("SetCellBackgroundColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}