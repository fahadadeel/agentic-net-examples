using System;
using System.Collections.Generic;
using Aspose.Words;

public class CommentExtractor
{
    /// <summary>
    /// Extracts comment texts from a DOCX file.
    /// If <paramref name="author"/> is null or empty, all comments are returned.
    /// Otherwise only comments authored by the specified person are returned.
    /// </summary>
    /// <param name="filePath">Path to the DOCX file.</param>
    /// <param name="author">Optional author name to filter comments.</param>
    /// <returns>List of comment texts.</returns>
    public static List<string> ExtractComments(string filePath, string? author = null)
    {
        // Load the document from the specified file.
        Document doc = new Document(filePath);

        // Retrieve all comment nodes in the document.
        NodeCollection commentNodes = doc.GetChildNodes(NodeType.Comment, true);

        List<string> result = new List<string>();

        foreach (Comment comment in commentNodes)
        {
            // If an author filter is provided, skip comments that don't match.
            if (!string.IsNullOrEmpty(author) &&
                !string.Equals(comment.Author, author, StringComparison.OrdinalIgnoreCase))
                continue;

            // The comment text is the concatenation of all paragraphs in the comment story.
            result.Add(comment.GetText().Trim());
        }

        return result;
    }

    // Example usage.
    public static void Main()
    {
        string docPath = @"C:\Docs\Sample.docx";

        // Extract all comments.
        List<string> allComments = ExtractComments(docPath);
        Console.WriteLine("All comments:");
        foreach (string txt in allComments)
            Console.WriteLine("- " + txt);

        // Extract comments made by a specific author.
        string targetAuthor = "John Doe";
        List<string> authorComments = ExtractComments(docPath, targetAuthor);
        Console.WriteLine($"\nComments by '{targetAuthor}':");
        foreach (string txt in authorComments)
            Console.WriteLine("- " + txt);
    }
}
