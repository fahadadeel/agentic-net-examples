using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation pres = new Presentation("input.pptx");

        // Access the first slide in the presentation
        ISlide slide = pres.Slides[0];

        // Assume the first shape on the slide is a table
        IShape shape = slide.Shapes[0];
        ITable table = shape as ITable;

        if (table != null)
        {
            // Delete the row at index 1 (second row) without removing attached rows
            table.Rows.RemoveAt(1, false);
        }

        // Save the modified presentation
        pres.Save("output.pptx", SaveFormat.Pptx);
    }
}