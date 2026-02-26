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

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Merge first two cells in the first row
        Aspose.Slides.ICell cell1 = table.Rows[0][0];
        Aspose.Slides.ICell cell2 = table.Rows[0][1];
        table.MergeCells(cell1, cell2, false);

        // Add text to the merged cell
        cell1.TextFrame.Text = "Merged Cells";

        // Save the presentation
        presentation.Save("MergedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}