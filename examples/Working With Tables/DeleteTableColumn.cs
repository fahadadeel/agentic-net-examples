using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
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

            // If a table was found, remove the column at the specified index
            if (table != null)
            {
                int columnIndex = 1; // zero‑based index of the column to delete
                bool withAttachedRows = true; // also delete attached rows if needed
                table.Columns.RemoveAt(columnIndex, withAttachedRows);
            }

            // Save the modified presentation to a new file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}