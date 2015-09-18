using System;
using System.Threading.Tasks;

namespace Try4Real.Client.Wpf.Business.Dialog
{
    public interface IDialogService
    {
        void AskQuestion(string title, string message, Func<Answers, Task> callback);
        void AskQuestion(string title, string message, Action<Answers> callback);
    }
}