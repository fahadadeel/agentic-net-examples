using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a table with 2 columns and 2 rows
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, new double[] { 100, 100 }, new double[] { 50, 50 });

        // Access the cell at row 0, column 0
        Aspose.Slides.ICell cell = table[0, 0];

        // Set text in the cell
        cell.TextFrame.Text = "Hello, World!";

        // Save the presentation
        presentation.Save("SetCellText_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}