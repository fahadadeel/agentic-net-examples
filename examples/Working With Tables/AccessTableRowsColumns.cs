using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableExample
{
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
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Access rows collection
            Aspose.Slides.IRowCollection rows = table.Rows;

            // Iterate through rows and output the number of cells in each row
            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                Aspose.Slides.IRow row = rows[rowIndex];
                Console.WriteLine($"Row {rowIndex} has {row.Count} cells.");
            }

            // Access columns collection
            Aspose.Slides.IColumnCollection columns = table.Columns;

            // Iterate through columns and output the width of each column
            for (int colIndex = 0; colIndex < columns.Count; colIndex++)
            {
                Aspose.Slides.IColumn column = columns[colIndex];
                Console.WriteLine($"Column {colIndex} width: {column.Width}");
            }

            // Save the presentation
            presentation.Save("TableRowsColumns.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}