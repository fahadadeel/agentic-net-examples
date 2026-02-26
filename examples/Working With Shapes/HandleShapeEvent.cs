using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation that contains an ActiveX control
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the collection of ActiveX controls on the slide
        Aspose.Slides.IControlCollection controls = slide.Controls;

        // If there is at least one control, work with it
        if (controls.Count > 0)
        {
            Aspose.Slides.IControl control = controls[0];

            // Change the control's name (writable property)
            control.Name = "MyActiveXControl";

            // Check how the control stores its properties
            if (control.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
            {
                // Set an XML‑based property
                control.Properties["Value"] = "123";
            }
            else
            {
                // For binary persistence, read the binary data (read‑only)
                byte[] binaryData = control.ActiveXControlBinary;
                Console.WriteLine("ActiveX binary length: " + binaryData.Length);
                // Custom handling of binary data could be placed here
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}