using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Output file path
        System.String outputPath = "ManagedPlaceholders.pptx";

        // Get a blank layout slide
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Get the placeholder manager for the layout slide
        Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;

        // Add different types of placeholders to the layout
        placeholderManager.AddContentPlaceholder(10, 10, 300, 200);
        placeholderManager.AddVerticalTextPlaceholder(350, 10, 200, 300);
        placeholderManager.AddChartPlaceholder(10, 350, 300, 300);
        placeholderManager.AddTablePlaceholder(350, 350, 300, 200);

        // Create a new slide based on the modified layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}