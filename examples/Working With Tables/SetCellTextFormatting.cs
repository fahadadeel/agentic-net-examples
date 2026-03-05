using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set text for some cells
        table[0, 0].TextFrame.Text = "Cell 1";
        table[0, 1].TextFrame.Text = "Cell 2";
        table[0, 2].TextFrame.Text = "Cell 3";

        // Create a PortionFormat to define font style, size, and color
        PortionFormat portionFormat = new PortionFormat();
        portionFormat.FontHeight = 24f;
        portionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portionFormat.FontItalic = Aspose.Slides.NullableBool.True;
        portionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
        portionFormat.FillFormat.FillType = FillType.Solid;
        portionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Apply the formatting to all cells' portions in the table
        table.SetTextFormat(portionFormat);

        // Save the presentation
        presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
    }
}