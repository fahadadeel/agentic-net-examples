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

        // Add a rectangle auto shape and set its text
        Aspose.Slides.IAutoShape rect = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 300f, 150f);
        rect.AddTextFrame("Animated Shape");

        // Add a PathFootball animation effect to the rectangle (after previous)
        slide.Timeline.MainSequence.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathFootball,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Add a button shape (bevel) that will trigger the interactive sequence
        Aspose.Slides.IShape button = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Bevel, 450f, 100f, 100f, 50f);

        // Create an interactive sequence linked to the button
        Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences.Add(button);

        // Add a PathUser animation effect to the rectangle, triggered on click
        Aspose.Slides.Animation.IEffect motionEffect = interactiveSeq.AddEffect(
            rect,
            Aspose.Slides.Animation.EffectType.PathUser,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Retrieve the motion behavior from the effect
        Aspose.Slides.Animation.IMotionEffect motionBhv = (Aspose.Slides.Animation.IMotionEffect)motionEffect.Behaviors[0];

        // Define points for the motion path
        System.Drawing.PointF[] pts = new System.Drawing.PointF[1];
        pts[0] = new System.Drawing.PointF(0f, 0f);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        pts[0] = new System.Drawing.PointF(200f, 0f);
        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            pts,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        motionBhv.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.End,
            null,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            false);

        // Save the presentation in PPTX format
        presentation.Save("AnimatedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}