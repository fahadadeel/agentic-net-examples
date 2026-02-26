using System;
using System.Drawing;
using Aspose.Slides;

namespace ListSlideSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Iterate through all predefined slide size types
            foreach (Aspose.Slides.SlideSizeType sizeType in Enum.GetValues(typeof(Aspose.Slides.SlideSizeType)))
            {
                // Apply the slide size without scaling existing content
                presentation.SlideSize.SetSize(sizeType, Aspose.Slides.SlideSizeScaleType.DoNotScale);

                // Retrieve the dimensions of the current slide size
                System.Drawing.SizeF dimensions = presentation.SlideSize.Size;

                // Output the slide size type and its dimensions
                Console.WriteLine($"{sizeType}: Width = {dimensions.Width} pt, Height = {dimensions.Height} pt");
            }

            // Save the presentation before exiting
            presentation.Save("SupportedSlideSizes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}