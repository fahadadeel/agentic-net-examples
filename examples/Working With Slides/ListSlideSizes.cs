using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Iterate over all predefined slide size types
        foreach (Aspose.Slides.SlideSizeType sizeType in Enum.GetValues(typeof(Aspose.Slides.SlideSizeType)))
        {
            // Apply the slide size without scaling existing content
            presentation.SlideSize.SetSize(sizeType, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Retrieve the dimensions of the slide in points
            SizeF dimensions = presentation.SlideSize.Size;

            // Output the slide size type and its dimensions
            Console.WriteLine($"{sizeType}: Width={dimensions.Width}, Height={dimensions.Height}");
        }

        // Save the presentation before exiting
        presentation.Save("SupportedSlideSizes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}