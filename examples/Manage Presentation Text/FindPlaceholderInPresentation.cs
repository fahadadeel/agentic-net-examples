using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Check if the shape has a placeholder and is an AutoShape
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    // Change the text of the placeholder
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "This is a Placeholder";
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}