using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define the folder containing the presentation
        string dataDir = Path.GetFullPath("Data");

        // Load an existing presentation (must be a macro-enabled PPTM)
        Presentation pres = new Presentation(Path.Combine(dataDir, "input.pptm"));

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Access the first ActiveX control on the slide
        IControl control = slide.Controls[0];

        // Retrieve the current frame of the control
        IShapeFrame oldFrame = control.Frame;

        // Create a new frame with updated width and height (example values)
        ShapeFrame newFrame = new ShapeFrame(
            oldFrame.X,          // keep existing X
            oldFrame.Y,          // keep existing Y
            200f,                // new width in points
            100f,                // new height in points
            oldFrame.FlipH,      // preserve flip horizontal flag
            oldFrame.FlipV,      // preserve flip vertical flag
            oldFrame.Rotation    // preserve rotation
        );

        // Assign the new frame to the control
        control.Frame = newFrame;

        // Save the modified presentation
        pres.Save(Path.Combine(dataDir, "output.pptm"), SaveFormat.Pptm);

        // Clean up resources
        pres.Dispose();
    }
}