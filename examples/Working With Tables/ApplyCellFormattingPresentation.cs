using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Populate table cells with sample text
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                table[row, col].TextFrame.Text = $"R{row + 1}C{col + 1}";
            }
        }

        // Apply formatting to the first cell (row 0, column 0)
        Aspose.Slides.ICell cell = table[0, 0];
        cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;

        cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
        cell.CellFormat.BorderTop.Width = 2;

        cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
        cell.CellFormat.BorderBottom.Width = 2;

        cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
        cell.CellFormat.BorderLeft.Width = 2;

        cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
        cell.CellFormat.BorderRight.Width = 2;

        // Save the presentation
        presentation.Save("CellFormatting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}