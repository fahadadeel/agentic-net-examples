using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyFadeAnimationToShape
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a rectangle shape to the first slide
                IShape rectangle = presentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle,    // Shape type
                    100,                    // X position
                    100,                    // Y position
                    200,                    // Width
                    100);                   // Height

                // Apply a Fade animation to the rectangle
                IEffect fadeEffect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                    rectangle,                     // Target shape
                    EffectType.Fade,               // Animation type
                    EffectSubtype.None,            // Subtype
                    EffectTriggerType.OnClick);    // Trigger

                // Save the presentation
                presentation.Save("FadeAnimation.pptx", SaveFormat.Pptx);
            }
        }
    }
}