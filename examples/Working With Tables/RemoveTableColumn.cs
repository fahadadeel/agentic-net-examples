using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Remove the second column (index 1) without deleting attached rows
        IColumnCollection columns = table.Columns;
        columns.RemoveAt(1, false);

        // Save the presentation
        pres.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}