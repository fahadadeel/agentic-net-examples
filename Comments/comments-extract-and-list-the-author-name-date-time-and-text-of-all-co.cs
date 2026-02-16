using System;
using Aspose.Words;

class ExtractComments
{
    static void Main()
    {
        // Path to the DOCX file.
        string inputPath = "input.docx";

        // Load the document using Aspose.Words.
        Document doc = new Document(inputPath);

        // Retrieve all Comment nodes in the document.
        NodeCollection commentNodes = doc.GetChildNodes(NodeType.Comment, true);

        // Iterate through each comment and output its details.
        foreach (Comment comment in commentNodes)
        {
            // Author of the comment.
            string author = comment.Author;

            // Date and time when the comment was made.
            DateTime dateTime = comment.DateTime;

            // Text content of the comment (trimmed to remove extra whitespace).
            string text = comment.GetText().Trim();

            // Display the comment information.
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"DateTime: {dateTime}");
            Console.WriteLine($"Text: {text}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
