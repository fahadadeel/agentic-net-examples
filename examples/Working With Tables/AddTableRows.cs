using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and initial row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

        // Get the row collection of the table
        Aspose.Slides.IRowCollection rows = table.Rows;

        // Clone the first row and add it as a new row at the bottom
        Aspose.Slides.IRow firstRow = rows[0];
        rows.AddClone(firstRow, false);

        // Optionally set text for the newly added row cells
        for (int col = 0; col < table.Columns.Count; col++)
        {
            table.Rows[rows.Count - 1][col].TextFrame.Text = "New Cell " + col;
        }

        // Save the presentation
        presentation.Save("AddRowsTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}