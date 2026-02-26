using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define initial column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Clone the first column and insert it as a new column at the end of the table
        Aspose.Slides.IColumn templateColumn = table.Columns[0];
        table.Columns.InsertClone(table.Columns.Count, templateColumn, false);

        // Set the width of the newly added column
        table.Columns[table.Columns.Count - 1].Width = 100;

        // Save the presentation
        pres.Save("AddColumns.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}