using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        double[] rowHeights = new double[] { 40, 40, 40 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Insert a new row at index 1 (second position) using the first row as a template
        Aspose.Slides.IRowCollection rows = table.Rows;
        Aspose.Slides.IRow templateRow = rows[0];
        rows.InsertClone(1, templateRow, false);

        // Set text for the newly inserted row cells
        Aspose.Slides.ICell newCell0 = rows[1][0];
        newCell0.TextFrame.Text = "New Row Cell 1";
        Aspose.Slides.ICell newCell1 = rows[1][1];
        newCell1.TextFrame.Text = "New Row Cell 2";
        Aspose.Slides.ICell newCell2 = rows[1][2];
        newCell2.TextFrame.Text = "New Row Cell 3";

        // Save the presentation
        presentation.Save("InsertRows.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}