using System.Linq;

namespace InsertGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {

            var activeDocument = await VS.Documents.GetActiveDocumentViewAsync();

            var textViewSelection = activeDocument.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (textViewSelection != null) 
            {
                activeDocument.TextBuffer.Replace(textViewSelection, Guid.NewGuid().ToString());
            }

        }
    }
}
