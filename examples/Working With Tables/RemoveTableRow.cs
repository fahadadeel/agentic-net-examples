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
        double[] rowHeights = new double[] { 50, 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

        // Remove the second row (index 1) and also delete attached rows
        table.Rows.RemoveAt(1, true);

        // Save the presentation
        presentation.Save("RemoveRowTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}