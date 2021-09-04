namespace Try4Real.Client.Wpf.Business.Dialog
{
    public interface IDialogService
    {
        Answers AskQuestion(string title, string message);
    }
}