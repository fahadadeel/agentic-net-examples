using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation that contains an ActiveX control
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Iterate through all ActiveX controls on the slide
        foreach (Aspose.Slides.IControl control in slide.Controls)
        {
            // Basic handling: check the persistence type and modify a property if possible
            if (control.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
            {
                // Update an XML‑based property of the control
                control.Properties["Value"] = "NewValue";
                Console.WriteLine("ActiveX control property updated.");
            }
            else
            {
                // For binary‑persisted controls, retrieve the binary data (custom handling may be required)
                byte[] binaryData = control.ActiveXControlBinary;
                Console.WriteLine("ActiveX control uses binary persistence (size: " + binaryData.Length + " bytes).");
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}