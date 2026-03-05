using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape and set its text
        Aspose.Slides.IAutoShape rect = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
        rect.AddTextFrame("Animated Shape");

        // Add a path animation to the rectangle (plays after previous)
        slide.Timeline.MainSequence.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathFootball,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Add a button shape that will trigger an interactive sequence
        Aspose.Slides.IShape button = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Bevel, 50, 300, 100, 50);

        // Create an interactive sequence linked to the button
        Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences.Add(button);

        // Add a user-defined path animation to the rectangle (triggered on click)
        Aspose.Slides.Animation.IEffect motionEffect = interactiveSeq.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathUser,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Get the motion behavior from the effect
        Aspose.Slides.Animation.IMotionEffect motionBhv = (Aspose.Slides.Animation.IMotionEffect)motionEffect.Behaviors[0];

        // Define points for the custom motion path
        System.Drawing.PointF[] pts = new System.Drawing.PointF[1];

        // First segment
        pts[0] = new System.Drawing.PointF(0f, 0f);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            true);

        // Second segment
        pts[0] = new System.Drawing.PointF(100f, 0f);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            true);

        // End of the motion path
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.End,
            null,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            true);

        // Save the presentation
        pres.Save("AnimationSequences_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}