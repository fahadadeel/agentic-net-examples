using System;

class Program
{
    static void Main()
    {
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            presentation.Save("CreatedPresentation.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}