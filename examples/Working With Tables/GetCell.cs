using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a table
            Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[0];

            // Retrieve the cell at column index 0 and row index 0
            Aspose.Slides.ICell cell = table[0, 0];

            // Read the text inside the cell's text frame
            string cellText = cell.TextFrame.Text;
            Console.WriteLine("Cell text: " + cellText);

            // Save the presentation (even if unchanged)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}