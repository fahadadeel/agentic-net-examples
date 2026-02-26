using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Retrieve the first ActiveX control on the slide, if any
        Aspose.Slides.IControl control = null;
        if (slide.Controls.Count > 0)
        {
            control = slide.Controls[0];
        }

        // If the control supports XML based properties, assign a value to its "Value" property
        if (control != null && control.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
        {
            control.Properties["Value"] = "NewValue";
        }

        // Save the presentation before exiting
        presentation.Save("ActiveXControlProperty_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}