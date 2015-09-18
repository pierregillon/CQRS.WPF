using System;
using System.Threading.Tasks;
using System.Windows;
using Try4Real.Client.Wpf.Business.Dialog;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogService : IDialogService
    {
        public async void AskQuestion(string title, string message, Func<Answers, Task> callback)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            await callback(result.ToAnswer());
        }

        public void AskQuestion(string title, string message, Action<Answers> callback)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            callback(result.ToAnswer());
        }
    }
}
