using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Define column widths and row heights (in points)
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 40, 30, 30, 30 };

        // Add a table shape to the slide
        var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Apply red borders of width 5 to each cell
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                var cell = table.Rows[row][col];

                cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderTop.Width = 5;

                cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderBottom.Width = 5;

                cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderLeft.Width = 5;

                cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderRight.Width = 5;
            }
        }

        // Merge the first two cells of the first row
        table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
        // Add text to the merged cell
        table.Rows[0][0].TextFrame.Text = "Header";

        // Save the presentation
        presentation.Save("FormattedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}