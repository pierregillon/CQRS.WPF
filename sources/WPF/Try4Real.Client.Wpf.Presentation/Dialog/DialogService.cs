using System.Windows;
using Try4Real.Client.Wpf.Business.Dialog;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogService : IDialogService
    {
        public Answers AskQuestion(string title, string message)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            return result.ToAnswer();
        }
    }
}