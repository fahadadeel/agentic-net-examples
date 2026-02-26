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
        ITable table = slide.Shapes.AddTable(0, 0, columnWidths, rowHeights);

        // Delete the second column (index 1) and also remove attached rows
        table.Columns.RemoveAt(1, true);

        // Save the presentation
        pres.Save("output.pptx", SaveFormat.Pptx);
    }
}