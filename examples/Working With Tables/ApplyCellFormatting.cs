using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 50, 50, 50 };
        double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

        // Add a table to the slide
        ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

        // Apply red solid borders of width 5 to each cell
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int cell = 0; cell < table.Rows[row].Count; cell++)
            {
                // Top border
                table.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][cell].CellFormat.BorderTop.Width = 5;

                // Bottom border
                table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][cell].CellFormat.BorderBottom.Width = 5;

                // Left border
                table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

                // Right border
                table.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][cell].CellFormat.BorderRight.Width = 5;
            }
        }

        // Merge the first two cells of the first row
        table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
        table.Rows[0][0].TextFrame.Text = "Merged Cells";

        // Save the presentation
        pres.Save("CellFormattingTable.pptx", SaveFormat.Pptx);
    }
}