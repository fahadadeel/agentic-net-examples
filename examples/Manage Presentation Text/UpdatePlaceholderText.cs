using System;

namespace PlaceholderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide in the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Check if the shape has a placeholder
                if (shape.Placeholder != null)
                {
                    // Cast the shape to IAutoShape to modify its text
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                    // Set new text for the placeholder
                    autoShape.TextFrame.Text = "This is a Placeholder";
                }
            }

            // Save the modified presentation to a new file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}