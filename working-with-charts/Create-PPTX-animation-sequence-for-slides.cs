using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first (default) slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with some text
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            shape.TextFrame.Text = "Animated Text";

            // Access the main animation sequence of the slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Add a Fade effect to the shape
            mainSequence.AddEffect(shape,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Save the presentation
            presentation.Save("AnimatedPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}