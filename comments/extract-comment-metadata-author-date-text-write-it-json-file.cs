using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Words;

namespace CommentMetadataExtractor
{
    // Simple DTO to hold comment information.
    public class CommentInfo
    {
        public string Author { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source Word document.
            string docPath = "InputDocument.docx";

            // Path where the JSON file will be written.
            string jsonPath = "CommentsMetadata.json";

            // Load the document.
            Document doc = new Document(docPath);

            // Retrieve all comment nodes (including replies).
            NodeCollection commentNodes = doc.GetChildNodes(NodeType.Comment, true);

            // Prepare a list to hold extracted metadata.
            List<CommentInfo> comments = new List<CommentInfo>();

            foreach (Comment comment in commentNodes)
            {
                // Extract author, date/time, and the full text of the comment.
                CommentInfo info = new CommentInfo
                {
                    Author = comment.Author,
                    DateTime = comment.DateTime,
                    Text = comment.GetText().Trim()
                };

                comments.Add(info);
            }

            // Serialize the list to JSON with indentation for readability.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(comments, options);

            // Write JSON to the output file.
            File.WriteAllText(jsonPath, json);

            Console.WriteLine($"Extracted {comments.Count} comment(s) to '{jsonPath}'.");
        }
    }
}
