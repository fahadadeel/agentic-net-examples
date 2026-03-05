using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output files
        string dataDir = "Data/";
        string inputFile = dataDir + "input.pptx";
        string outputFile = dataDir + "output.pptx";

        // Load an existing presentation (or create a new one by using the parameterless constructor)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the new table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Apply a built‑in table style
        table.StylePreset = Aspose.Slides.TableStylePreset.MediumStyle2Accent1;

        // Save the presentation
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}