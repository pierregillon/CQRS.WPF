using System;
using System.Windows;
using Try4Real.Client.Wpf.Business.Dialog;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public static class MessageBoxResultExtensions
    {
        public static Answers ToAnswer(this MessageBoxResult result)
        {
            switch (result) {
                case MessageBoxResult.None:
                    return Answers.Unknown;
                case MessageBoxResult.OK:
                    return Answers.Yes;
                case MessageBoxResult.Cancel:
                    return Answers.Cancel;
                case MessageBoxResult.Yes:
                    return Answers.Yes;
                case MessageBoxResult.No:
                    return Answers.No;
                default:
                    throw new ArgumentOutOfRangeException("result");
            }
        }
    }
}