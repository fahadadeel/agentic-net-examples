using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string inputFile = Path.Combine(dataDir, "input.pptx");
        string outputFile = Path.Combine(dataDir, "output.pptx");

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Get the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Locate the first table shape on the slide
        Aspose.Slides.ITable table = null;
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.ITable)
            {
                table = (Aspose.Slides.ITable)shape;
                break;
            }
        }

        if (table != null)
        {
            // Access a specific row (e.g., the second row, index 1)
            Aspose.Slides.IRow irow = table.Rows[1];

            // Cast the IRow to the concrete Row class to use Row-specific members
            Aspose.Slides.Row row = irow as Aspose.Slides.Row;
            if (row != null)
            {
                // Example operation: set the minimal height of the row
                row.MinimalHeight = 30.0;
            }
        }

        // Save the modified presentation to the output file
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}