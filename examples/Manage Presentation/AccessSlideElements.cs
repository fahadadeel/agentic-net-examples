using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Define column widths and row heights for a table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide (use the correct ITable interface)
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50f, 300f, columnWidths, rowHeights);

        // Set border formatting for each cell in the table
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int cell = 0; cell < table.Rows[row].Count; cell++)
            {
                table.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][cell].CellFormat.BorderTop.Width = 1;

                table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][cell].CellFormat.BorderBottom.Width = 1;

                table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][cell].CellFormat.BorderLeft.Width = 1;

                table.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                table.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][cell].CellFormat.BorderRight.Width = 1;
            }
        }

        // Save the presentation before exiting
        presentation.Save("AccessSlideElements_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}