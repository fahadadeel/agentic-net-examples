using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first (default) slide
            var firstSlide = presentation.Slides[0];

            // Add a second slide to link to
            var secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a rectangle shape with the text "See also" on the first slide
            var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 200, 50);
            shape.TextFrame.Text = "See also";

            // Set an internal hyperlink on the shape to navigate to the second slide
            shape.HyperlinkClick = new Hyperlink(secondSlide);

            // Save the presentation
            presentation.Save("SeeAlsoReference.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}