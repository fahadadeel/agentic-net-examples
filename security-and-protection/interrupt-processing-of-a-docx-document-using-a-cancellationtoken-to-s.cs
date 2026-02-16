using System;
using System.IO;
using System.Threading;
using Aspose.Words;
using Aspose.Words.Loading;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Path to the document that may take a long time to load.
        string docPath = @"C:\Docs\BigDocument.docx";

        // Create a CancellationTokenSource that will cancel after 1 second.
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
        CancellationToken token = cts.Token;

        // Configure load options with a custom loading callback that checks the token.
        var loadOptions = new LoadOptions
        {
            ProgressCallback = new LoadingProgressCallback(token)
        };

        try
        {
            // Load the document. If the token is cancelled, an OperationCanceledException will be thrown.
            Document doc = new Document(docPath, loadOptions);
            Console.WriteLine("Document loaded successfully.");

            // Example processing could go here...

            // Configure save options with a custom saving callback that also checks the token.
            var saveOptions = new PdfSaveOptions
            {
                ProgressCallback = new SavingProgressCallback(token)
            };

            // Attempt to save the document. Cancellation will abort the save operation.
            doc.Save(@"C:\Docs\Output.pdf", saveOptions);
            Console.WriteLine("Document saved successfully.");
        }
        catch (OperationCanceledException ex)
        {
            // Handle the cancellation.
            Console.WriteLine($"Operation was cancelled: {ex.Message}");
        }
    }

    // Callback for document loading that respects a CancellationToken.
    private class LoadingProgressCallback : IDocumentLoadingCallback
    {
        private readonly CancellationToken _token;
        private readonly DateTime _startedAt;

        public LoadingProgressCallback(CancellationToken token)
        {
            _token = token;
            _startedAt = DateTime.Now;
        }

        public void Notify(DocumentLoadingArgs args)
        {
            // Cancel if the token has been triggered.
            if (_token.IsCancellationRequested)
                throw new OperationCanceledException($"Loading cancelled at {DateTime.Now}, progress={args.EstimatedProgress}");

            // Optional safety: also cancel after a fixed time limit.
            if ((DateTime.Now - _startedAt).TotalSeconds > 5)
                throw new OperationCanceledException($"Loading exceeded time limit, progress={args.EstimatedProgress}");
        }
    }

    // Callback for document saving that respects a CancellationToken.
    private class SavingProgressCallback : IDocumentSavingCallback
    {
        private readonly CancellationToken _token;
        private readonly DateTime _startedAt;

        public SavingProgressCallback(CancellationToken token)
        {
            _token = token;
            _startedAt = DateTime.Now;
        }

        public void Notify(DocumentSavingArgs args)
        {
            // Cancel if the token has been triggered.
            if (_token.IsCancellationRequested)
                throw new OperationCanceledException($"Saving cancelled at {DateTime.Now}, progress={args.EstimatedProgress}");

            // Optional safety: also cancel after a fixed time limit.
            if ((DateTime.Now - _startedAt).TotalSeconds > 5)
                throw new OperationCanceledException($"Saving exceeded time limit, progress={args.EstimatedProgress}");
        }
    }
}
