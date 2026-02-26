using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableRowExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and initial row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Clone the first row and add it as a new row at the bottom of the table
            Aspose.Slides.IRow templateRow = table.Rows[0];
            table.Rows.AddClone(templateRow, false);

            // Set text for cells in the newly added row
            int newRowIndex = table.Rows.Count - 1;
            for (int cellIndex = 0; cellIndex < table.Rows[newRowIndex].Count; cellIndex++)
            {
                table.Rows[newRowIndex][cellIndex].TextFrame.Text = "New Cell " + cellIndex;
            }

            // Save the presentation
            presentation.Save("AddRowsTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}