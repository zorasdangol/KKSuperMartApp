using KKSuperMart.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPageVM viewModel { get; set; }
        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FeedbackPageVM();
            messageEditor.Text = "Write Your Message here ..."; //initialize the Editor.Text and TextColor on the XAML file or on the constructor on the code behind with the PlaceHolder or whatever you want.
            messageEditor.TextColor = Color.Gray;

        }
        private void MyEditor_Focused(object sender, FocusEventArgs e) //triggered when the user taps on the Editor to interact with it
        {
            try
            {
                if (messageEditor.Text.Equals("Write Your Message here ...")) //if you have the placeholder showing, erase it and set the text color to black
                {
                    messageEditor.Text = "";
                    messageEditor.TextColor = Color.Black;
                    viewModel.Feedback.MESSAGE = messageEditor.Text;
                }
                else
                    viewModel.Feedback.MESSAGE = messageEditor.Text;
            }
            catch { }
        }

        private void MyEditor_Unfocused(object sender, FocusEventArgs e) //triggered when the user taps "Done" or outside of the Editor to finish the editing
        {
            try
            {
                if (messageEditor.Text.Equals("")) //if there is text there, leave it, if the user erased everything, put the placeholder Text back and set the TextColor to gray
                {
                    messageEditor.Text = "Write Your Message here ...";
                    messageEditor.TextColor = Color.Gray;
                    viewModel.Feedback.MESSAGE = messageEditor.Text;
                }
                else if (messageEditor.Text.Equals("Write Your Message here ..."))
                {
                    viewModel.Feedback.MESSAGE = "";
                }
                else
                    viewModel.Feedback.MESSAGE = messageEditor.Text;
            }
            catch { }
        }
    }
}
