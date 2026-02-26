using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set text in the first cell
        table.Rows[0][0].TextFrame.Text = "Header";

        // Clone the first row and add it to the bottom of the table
        Aspose.Slides.IRow firstRow = table.Rows[0];
        table.Rows.AddClone(firstRow, false);

        // Clone the second row and insert it at index 1
        Aspose.Slides.IRow secondRow = table.Rows[1];
        table.Rows.InsertClone(1, secondRow, false);

        // Remove the last row from the table
        int lastIndex = table.Rows.Count - 1;
        table.Rows.RemoveAt(lastIndex, false);

        // Save the presentation
        pres.Save("TableRowsColumns.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}