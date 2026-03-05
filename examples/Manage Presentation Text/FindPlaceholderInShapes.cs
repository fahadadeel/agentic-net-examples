using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Iterate through all slides in the presentation
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the current slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape has a placeholder
                    if (shape.Placeholder != null)
                    {
                        // If the shape is an AutoShape, change its text
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            autoShape.TextFrame.Text = "This is a Placeholder";
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}