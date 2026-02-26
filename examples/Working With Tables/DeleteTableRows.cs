using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Get the first shape on the slide and cast it to a table
        Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
        if (table == null)
        {
            // No table found; save and exit
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            return;
        }

        // Remove the second row (index 1) without deleting attached rows
        table.Rows.RemoveAt(1, false);

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}