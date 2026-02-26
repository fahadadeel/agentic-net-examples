using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add first comment author
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A1");
        // Add a comment on the first slide
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment(
            "First comment",
            presentation.Slides[0],
            new PointF(100, 100),
            DateTime.Now);

        // Add second comment author
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author_2", "A2");
        // Add a reply to the first comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment(
            "Reply to first comment",
            presentation.Slides[0],
            new PointF(120, 120),
            DateTime.Now);
        reply1.ParentComment = comment1;

        // Add a sub-reply to the reply
        Aspose.Slides.IComment subReply = author1.Comments.AddComment(
            "Sub-reply",
            presentation.Slides[0],
            new PointF(140, 140),
            DateTime.Now);
        subReply.ParentComment = reply1;

        // Display the comments hierarchy on the console
        Aspose.Slides.IComment[] comments = presentation.Slides[0].GetSlideComments(null);
        for (int i = 0; i < comments.Length; i++)
        {
            Aspose.Slides.IComment cur = comments[i];
            int indent = 0;
            while (cur.ParentComment != null)
            {
                indent++;
                cur = cur.ParentComment;
            }
            Console.Write(new string('\t', indent));
            Console.WriteLine("{0}: {1}", comments[i].Author.Name, comments[i].Text);
        }

        // Save the presentation before exiting
        presentation.Save("CommentsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}