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
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100f, 50f, columnWidths, rowHeights);

        // Merge first two cells in the first row (across columns)
        Aspose.Slides.ICell cellA = table.Rows[0][0];
        Aspose.Slides.ICell cellB = table.Rows[0][1];
        Aspose.Slides.ICell mergedAcrossColumns = table.MergeCells(cellA, cellB, false);
        mergedAcrossColumns.TextFrame.Text = "Merged Across Columns";

        // Merge first two cells in the first column (across rows)
        Aspose.Slides.ICell cellC = table.Rows[0][0];
        Aspose.Slides.ICell cellD = table.Rows[1][0];
        Aspose.Slides.ICell mergedAcrossRows = table.MergeCells(cellC, cellD, false);
        mergedAcrossRows.TextFrame.Text = "Merged Across Rows";

        // Save the presentation
        presentation.Save("MergedTable.pptx", SaveFormat.Pptx);
    }
}