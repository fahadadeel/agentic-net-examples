using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Define initial column widths and row heights
        double[] columnWidths = { 100, 100 };
        double[] rowHeights = { 50, 50, 50 };

        // Add a table to the slide
        var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Insert a new column at index 1 (between the existing columns)
        // Use the first column as a template for the new column
        var templateColumn = table.Columns[0];
        table.Columns.InsertClone(1, templateColumn, false);

        // Save the presentation
        presentation.Save("InsertedColumnTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}