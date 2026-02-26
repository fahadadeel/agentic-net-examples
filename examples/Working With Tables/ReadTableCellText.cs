using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Try to get the first shape as a table
        Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
        if (table != null)
        {
            // Read text from the cell at column 0, row 0
            Aspose.Slides.ICell cell = table[0, 0];
            string cellText = cell.TextFrame.Text;
            Console.WriteLine("Cell[0,0] text: " + cellText);
        }
        else
        {
            Console.WriteLine("No table found on the first slide.");
        }

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}