using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

        // Identify and display supported integral types
        Console.WriteLine("Supported Integral Types:");
        foreach (Aspose.Slides.MathText.MathIntegralTypes integralType in Enum.GetValues(typeof(Aspose.Slides.MathText.MathIntegralTypes)))
        {
            Console.WriteLine("- " + integralType);
        }

        // Identify and display supported fraction types
        Console.WriteLine("Supported Fraction Types:");
        foreach (Aspose.Slides.MathText.MathFractionTypes fractionType in Enum.GetValues(typeof(Aspose.Slides.MathText.MathFractionTypes)))
        {
            Console.WriteLine("- " + fractionType);
        }

        // Save the presentation before exiting
        presentation.Save("SupportedMathTypes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}