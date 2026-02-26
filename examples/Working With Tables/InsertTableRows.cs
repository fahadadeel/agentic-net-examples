using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableRowInsertionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and initial row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Populate the first two rows with sample text
            table.Rows[0][0].TextFrame.Text = "R0C0";
            table.Rows[0][1].TextFrame.Text = "R0C1";
            table.Rows[0][2].TextFrame.Text = "R0C2";

            table.Rows[1][0].TextFrame.Text = "R1C0";
            table.Rows[1][1].TextFrame.Text = "R1C1";
            table.Rows[1][2].TextFrame.Text = "R1C2";

            // Insert a new row at position 1 (between the existing rows) by cloning the first row
            Aspose.Slides.IRow[] insertedRows = table.Rows.InsertClone(1, table.Rows[0], false);
            Aspose.Slides.IRow newRow = insertedRows[0];

            // Set text for the newly inserted row
            newRow[0].TextFrame.Text = "NewR1C0";
            newRow[1].TextFrame.Text = "NewR1C1";
            newRow[2].TextFrame.Text = "NewR1C2";

            // Save the presentation
            presentation.Save("InsertRowTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}