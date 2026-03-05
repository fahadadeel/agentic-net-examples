using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace SequenceShapeAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SequenceShapeAnimations.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape rectangle = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);

            // Get the animation timeline for the slide (IAnimationTimeLine)
            Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;

            // Add first animation effect (Fade) triggered on click
            Aspose.Slides.Animation.IEffect fadeEffect = timeline.MainSequence.AddEffect(
                rectangle,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            // Add second animation effect (Fly) triggered after previous effect
            Aspose.Slides.Animation.IEffect flyEffect = timeline.MainSequence.AddEffect(
                rectangle,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Add third animation effect (Zoom) triggered after previous effect
            Aspose.Slides.Animation.IEffect zoomEffect = timeline.MainSequence.AddEffect(
                rectangle,
                Aspose.Slides.Animation.EffectType.Zoom,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}