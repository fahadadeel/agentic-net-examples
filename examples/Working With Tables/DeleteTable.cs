using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide (adjust index as needed)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through shapes to find a table
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                if (shape is Aspose.Slides.ITable)
                {
                    // Remove the table shape from the slide
                    slide.Shapes.Remove(shape);
                    break; // Assuming only one table needs to be removed
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}