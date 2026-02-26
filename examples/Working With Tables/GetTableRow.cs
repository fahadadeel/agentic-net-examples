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
        double[] rowHeights = new double[] { 50, 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Access the third row (zero‑based index 2)
        Aspose.Slides.Row thirdRow = (Aspose.Slides.Row)table.Rows[2];

        // Modify a writable property of the row
        thirdRow.MinimalHeight = 80;

        // Save the presentation before exiting
        presentation.Save("AccessRow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}