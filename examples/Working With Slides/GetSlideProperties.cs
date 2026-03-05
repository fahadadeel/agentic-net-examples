using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the slide collection
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Iterate through each slide and read its properties
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];

            // Read slide number, name and hidden status
            Console.WriteLine("Slide Number: " + slide.SlideNumber);
            Console.WriteLine("Slide Name: " + slide.Name);
            Console.WriteLine("Is Hidden: " + slide.Hidden);

            // Example modification: ensure the slide is visible
            slide.Hidden = false;
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}