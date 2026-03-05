using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide (automatically added)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50, 50 };

        // Add a table shape to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Remove the second row (index 1) without deleting attached rows
        table.Rows.RemoveAt(1, false);

        // Save the presentation to disk
        pres.Save("output.pptx", SaveFormat.Pptx);
    }
}