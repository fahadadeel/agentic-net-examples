using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape (optional, just to ensure math support)
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // List supported integral types
        Console.WriteLine("Supported Math Integral Types:");
        foreach (Aspose.Slides.MathText.MathIntegralTypes integral in Enum.GetValues(typeof(Aspose.Slides.MathText.MathIntegralTypes)))
        {
            Console.WriteLine("- " + integral.ToString());
        }

        // List supported fraction types
        Console.WriteLine("Supported Math Fraction Types:");
        foreach (Aspose.Slides.MathText.MathFractionTypes fraction in Enum.GetValues(typeof(Aspose.Slides.MathText.MathFractionTypes)))
        {
            Console.WriteLine("- " + fraction.ToString());
        }

        // Save the presentation before exiting
        presentation.Save("SupportedMathTypes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}