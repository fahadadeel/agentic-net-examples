using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with text
        Aspose.Slides.IAutoShape rect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
        rect.AddTextFrame("Animated Rectangle");

        // Add a PathFootball animation that starts after the previous effect
        slide.Timeline.MainSequence.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathFootball,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Add a button shape to trigger an interactive sequence
        Aspose.Slides.IShape button = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Bevel, 300, 50, 100, 50);

        // Create an interactive sequence linked to the button
        Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences.Add(button);

        // Add a user-defined path animation that starts on click
        Aspose.Slides.Animation.IEffect motionEffect = interactiveSeq.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathUser,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Retrieve the motion behavior from the effect
        Aspose.Slides.Animation.IMotionEffect motionBhv = (Aspose.Slides.Animation.IMotionEffect)motionEffect.Behaviors[0];

        // Define points for the motion path
        System.Drawing.PointF[] pts = new System.Drawing.PointF[1];
        pts[0] = new System.Drawing.PointF(0, 0);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        pts[0] = new System.Drawing.PointF(100, 0);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        // End the motion path
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.End,
            null,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        // Save the presentation
        presentation.Save("AnimationSequences.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}