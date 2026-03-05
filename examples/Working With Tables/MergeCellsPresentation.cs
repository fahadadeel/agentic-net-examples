using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Merge the first two cells in the first row
        Aspose.Slides.ICell mergedCell = table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);

        // Add text to the merged cell
        mergedCell.TextFrame.Text = "Merged Cells";

        // Save the presentation
        presentation.Save("MergedCellsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}