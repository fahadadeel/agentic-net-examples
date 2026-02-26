using System;
using System.Drawing;
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

        // Define initial column widths and row heights
        double[] columnWidths = new double[] { 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set text in the first cell
        table[0, 0].TextFrame.Text = "Cell 0,0";

        // Clone the second column (index 1) and insert it as a new third column (index 2)
        Aspose.Slides.IColumn templateColumn = table.Columns[1];
        table.Columns.InsertClone(2, templateColumn, false);

        // Set width for the newly added column
        table.Columns[2].Width = 100;

        // Save the presentation
        presentation.Save("AddColumnTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}