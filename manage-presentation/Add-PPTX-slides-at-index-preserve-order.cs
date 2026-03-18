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
            Presentation presentation = new Presentation("input.pptx");

            // Index at which the new slide will be inserted (zero‑based)
            int insertIndex = 2;

            // Use the first layout slide as a template for the new slide
            ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

            // Insert an empty slide at the specified position
            ISlide insertedSlide = presentation.Slides.InsertEmptySlide(insertIndex, layoutSlide);

            // (Optional) Add content to the inserted slide here

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}