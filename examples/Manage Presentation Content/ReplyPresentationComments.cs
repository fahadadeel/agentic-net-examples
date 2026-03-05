using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add comment authors
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A1");
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B2");

        // Define a position for comments
        System.Drawing.PointF position = new System.Drawing.PointF(10f, 10f);

        // Add a comment on the first slide
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment("First comment", presentation.Slides[0], position, DateTime.Now);

        // Add a reply to the first comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment("Reply to first comment", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;

        // Add another reply to the first comment
        Aspose.Slides.IComment reply2 = author2.Comments.AddComment("Second reply", presentation.Slides[0], position, DateTime.Now);
        reply2.ParentComment = comment1;

        // Add a sub-reply to the second reply
        Aspose.Slides.IComment subReply = author1.Comments.AddComment("Sub-reply to second reply", presentation.Slides[0], position, DateTime.Now);
        subReply.ParentComment = reply2;

        // Display the comment hierarchy on the console
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
        for (int i = 0; i < comments.Length; i++)
        {
            Aspose.Slides.IComment current = comments[i];
            // Indent based on parent hierarchy
            while (current.ParentComment != null)
            {
                Console.Write("\t");
                current = current.ParentComment;
            }
            Console.WriteLine("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        }

        // Save the presentation with comments
        presentation.Save("CommentsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Remove the first comment and all its replies
        comment1.Remove();

        // Save the presentation after removal
        presentation.Save("CommentsDemo_Removed.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}