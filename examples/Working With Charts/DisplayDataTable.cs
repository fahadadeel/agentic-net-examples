using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 40, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Populate table cells with sample data and set borders
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                table.Rows[row][col].TextFrame.Text = $"R{row + 1}C{col + 1}";

                // Top border
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderTop.Width = 1;

                // Bottom border
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderBottom.Width = 1;

                // Left border
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderLeft.Width = 1;

                // Right border
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderRight.Width = 1;
            }
        }

        // Save the presentation
        presentation.Save("DataTablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}