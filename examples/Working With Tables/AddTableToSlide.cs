using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights (in points)
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

        // Add a table shape to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

        // Example: set text in the first cell
        table.Rows[0][0].TextFrame.Text = "Hello";

        // Save the presentation to disk
        presentation.Save("TableExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}