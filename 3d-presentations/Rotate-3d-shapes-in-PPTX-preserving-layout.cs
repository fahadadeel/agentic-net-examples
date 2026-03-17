using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Apply 3‑D rotation if the shape supports ThreeDFormat
                    if (shape.ThreeDFormat != null)
                    {
                        // Set rotation angles (X, Y, Z) in degrees
                        shape.ThreeDFormat.Camera.SetRotation(30, 40, 50);

                        // Optional: adjust depth to make the effect more visible
                        shape.ThreeDFormat.Depth = 5;
                    }
                }
            }

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}