using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableMarginsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights (in points)
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Set top and left margins for each cell in the table
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < table.Rows[rowIndex].Count; colIndex++)
                    {
                        Aspose.Slides.ICell cell = table.Rows[rowIndex][colIndex];
                        cell.MarginTop = 5.0;   // top margin in points
                        cell.MarginLeft = 5.0;  // left margin in points
                    }
                }

                // Save the presentation
                presentation.Save("TableMargins.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}