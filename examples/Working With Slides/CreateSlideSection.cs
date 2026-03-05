using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first (default) slide
            ISlide firstSlide = presentation.Slides[0];

            // Add a new section named "Introduction" starting from the first slide
            ISection introductionSection = presentation.Sections.AddSection("Introduction", firstSlide);

            // Save the presentation to a file
            presentation.Save("IntroductionSection.pptx", SaveFormat.Pptx);
        }
    }
}