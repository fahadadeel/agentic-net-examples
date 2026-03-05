using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights for the table
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50, 50 };

            // Add a table shape to the slide (3 columns x 5 rows)
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Access a specific cell using column and row indices (columnIndex = 2, rowIndex = 1)
            Aspose.Slides.ICell cell = table[2, 1];

            // Set text for the accessed cell
            cell.TextFrame.Text = "Hello from cell (2,1)";

            // Output the cell text to the console
            Console.WriteLine("Cell text: " + cell.TextFrame.Text);

            // Save the presentation before exiting
            presentation.Save("TableCellExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}