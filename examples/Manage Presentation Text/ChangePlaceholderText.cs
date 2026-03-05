using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Check if the shape has a placeholder and is an AutoShape
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    // Change the text in the placeholder
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "New placeholder text";
                }
            }

            // Save the updated presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}