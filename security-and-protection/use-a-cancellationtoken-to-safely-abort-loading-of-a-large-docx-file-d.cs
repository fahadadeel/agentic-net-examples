using System;
using System.IO;
using System.Threading;
using Aspose.Words;
using Aspose.Words.Loading;

public class LoadingProgressCallback : IDocumentLoadingCallback
{
    private readonly DateTime _loadingStartedAt;
    private readonly CancellationToken _cancellationToken;

    public LoadingProgressCallback(CancellationToken cancellationToken)
    {
        _loadingStartedAt = DateTime.Now;
        _cancellationToken = cancellationToken;
    }

    // This method is called repeatedly during document loading.
    public void Notify(DocumentLoadingArgs args)
    {
        // If the external token requests cancellation, abort loading.
        if (_cancellationToken.IsCancellationRequested)
            throw new OperationCanceledException(
                $"Loading canceled by token. EstimatedProgress = {args.EstimatedProgress}");

        // Optional: also cancel after a certain elapsed time.
        double elapsedSeconds = (DateTime.Now - _loadingStartedAt).TotalSeconds;
        const double maxDuration = 5.0; // seconds
        if (elapsedSeconds > maxDuration)
            throw new OperationCanceledException(
                $"Loading exceeded max duration ({maxDuration}s). EstimatedProgress = {args.EstimatedProgress}");
    }
}

public class DocumentProcessor
{
    public void LoadDocumentWithCancellation(string filePath, CancellationToken cancellationToken)
    {
        // Configure load options to use the custom progress callback.
        LoadOptions loadOptions = new LoadOptions
        {
            ProgressCallback = new LoadingProgressCallback(cancellationToken)
        };

        try
        {
            // Load the document; the callback will monitor progress and may throw.
            Document doc = new Document(filePath, loadOptions);

            // Document loaded successfully – proceed with further processing here.
            Console.WriteLine($"Document loaded. Page count: {doc.PageCount}");
        }
        catch (OperationCanceledException ex)
        {
            // Handle the cancellation gracefully.
            Console.WriteLine($"Document loading was aborted: {ex.Message}");
        }
        // Other exceptions (e.g., FileCorruptedException) can be caught separately if needed.
    }
}

// Example usage:
public static class Program
{
    public static void Main()
    {
        string docPath = @"C:\Docs\LargeDocument.docx";

        // Create a token source that cancels after 3 seconds (as an example).
        using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
        {
            DocumentProcessor processor = new DocumentProcessor();
            processor.LoadDocumentWithCancellation(docPath, cts.Token);
        }
    }
}
