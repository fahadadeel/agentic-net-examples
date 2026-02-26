using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first shape on the first slide
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

            // ----- Effective Fill Format -----
            Aspose.Slides.IFillFormatEffectiveData fillEff = shape.FillFormat.GetEffective();
            Console.WriteLine("=== Effective Fill Format ===");
            Console.WriteLine("Fill Type: " + fillEff.FillType);
            if (fillEff.FillType == Aspose.Slides.FillType.Solid)
            {
                Console.WriteLine("Solid Fill Color: " + fillEff.SolidFillColor);
            }

            // ----- Effective Effect Format -----
            Aspose.Slides.IEffectFormatEffectiveData effectEff = shape.EffectFormat.GetEffective();
            Console.WriteLine("\n=== Effective Effect Format ===");
            Console.WriteLine("Is No Effects: " + effectEff.IsNoEffects);
            if (effectEff.OuterShadowEffect != null)
            {
                Console.WriteLine("Outer Shadow Color: " + effectEff.OuterShadowEffect.ShadowColor);
                Console.WriteLine("Outer Shadow Distance: " + effectEff.OuterShadowEffect.Distance);
            }
            if (effectEff.GlowEffect != null)
            {
                Console.WriteLine("Glow Color: " + effectEff.GlowEffect.Color);
            }

            // ----- Effective Line Format -----
            Aspose.Slides.ILineFormatEffectiveData lineEff = shape.LineFormat.GetEffective();
            Console.WriteLine("\n=== Effective Line Format ===");
            Console.WriteLine("Line Style: " + lineEff.Style);
            Console.WriteLine("Line Width: " + lineEff.Width);
            Console.WriteLine("Line Fill Type: " + lineEff.FillFormat.FillType);

            // ----- Effective 3‑D Format -----
            Aspose.Slides.IThreeDFormatEffectiveData threeDEff = shape.ThreeDFormat.GetEffective();
            Console.WriteLine("\n=== Effective 3‑D Format ===");
            Console.WriteLine("Camera Type: " + threeDEff.Camera.CameraType);
            Console.WriteLine("Camera Field of View: " + threeDEff.Camera.FieldOfViewAngle);
            Console.WriteLine("Light Rig Type: " + threeDEff.LightRig.LightType);
            Console.WriteLine("Light Rig Direction: " + threeDEff.LightRig.Direction);
            Console.WriteLine("Top Bevel Type: " + threeDEff.BevelTop.BevelType);
            Console.WriteLine("Top Bevel Width: " + threeDEff.BevelTop.Width);
            Console.WriteLine("Top Bevel Height: " + threeDEff.BevelTop.Height);

            // ----- Effective Text Frame (if applicable) -----
            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
            if (autoShape != null && autoShape.TextFrame != null)
            {
                Aspose.Slides.ITextFrameFormatEffectiveData textFrameEff = autoShape.TextFrame.TextFrameFormat.GetEffective();
                Console.WriteLine("\n=== Effective Text Frame Format ===");
                Console.WriteLine("Anchoring Type: " + textFrameEff.AnchoringType);
                Console.WriteLine("Autofit Type: " + textFrameEff.AutofitType);
                Console.WriteLine("Text Vertical Type: " + textFrameEff.TextVerticalType);
                Console.WriteLine("Margins - Left: " + textFrameEff.MarginLeft + ", Top: " + textFrameEff.MarginTop +
                                  ", Right: " + textFrameEff.MarginRight + ", Bottom: " + textFrameEff.MarginBottom);
            }

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}