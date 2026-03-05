using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define initial column widths and row heights
        double[] columnWidths = new double[] { 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Add a new column by cloning the first column and inserting at position 2 (zero‑based index)
        Aspose.Slides.IColumnCollection columns = table.Columns;
        Aspose.Slides.IColumn templateColumn = columns[0];
        columns.InsertClone(2, templateColumn, false);

        // Set width for the newly added column
        columns[2].Width = 120;

        // Save the presentation
        presentation.Save("ExpandedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}