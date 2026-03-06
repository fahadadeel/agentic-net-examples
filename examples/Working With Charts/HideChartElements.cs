using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                // Get the current shape
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a chart
                if (shape is Aspose.Slides.Charts.Chart)
                {
                    // Cast the shape to a Chart object
                    Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)shape;

                    // Hide chart elements
                    chart.HasLegend = false;      // Hide legend
                    chart.HasTitle = false;       // Hide title
                    chart.HasDataTable = false;   // Hide data table
                }
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}