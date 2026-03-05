using System;
using Aspose.Slides;
using System.Drawing;

namespace MergeTableCellsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Merge first two cells in the first row (horizontal merge)
            Aspose.Slides.ICell cell1 = table.Rows[0][0];
            Aspose.Slides.ICell cell2 = table.Rows[0][1];
            table.MergeCells(cell1, cell2, false);
            cell1.TextFrame.Text = "Merged Columns";

            // Merge first cell of first two rows (vertical merge)
            Aspose.Slides.ICell vCell1 = table.Rows[0][2];
            Aspose.Slides.ICell vCell2 = table.Rows[1][2];
            table.MergeCells(vCell1, vCell2, false);
            vCell1.TextFrame.Text = "Merged Rows";

            // Save the presentation
            pres.Save("MergedCellsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}