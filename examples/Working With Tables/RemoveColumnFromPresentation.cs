using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide in the presentation
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

        // If a table was found, remove the second column (index 1) and delete attached rows
        if (table != null)
        {
            // Parameters: column index to remove, whether to delete attached rows
            table.Columns.RemoveAt(1, true);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}