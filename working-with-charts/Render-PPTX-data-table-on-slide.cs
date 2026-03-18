using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights for the table
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 30, 30, 30, 30 };

            // Add a table shape to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Populate header row
            table[0, 0].TextFrame.Text = "ID";
            table[0, 1].TextFrame.Text = "Name";
            table[0, 2].TextFrame.Text = "Score";

            // Populate data rows
            table[1, 0].TextFrame.Text = "1";
            table[1, 1].TextFrame.Text = "Alice";
            table[1, 2].TextFrame.Text = "85";

            table[2, 0].TextFrame.Text = "2";
            table[2, 1].TextFrame.Text = "Bob";
            table[2, 2].TextFrame.Text = "92";

            table[3, 0].TextFrame.Text = "3";
            table[3, 1].TextFrame.Text = "Charlie";
            table[3, 2].TextFrame.Text = "78";

            // Save the presentation to a PPTX file
            presentation.Save("DataTablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}