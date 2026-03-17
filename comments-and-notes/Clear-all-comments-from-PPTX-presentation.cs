using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all comment authors and clear their comments
            foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
            {
                author.Comments.Clear();
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}