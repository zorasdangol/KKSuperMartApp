using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using KKSuperMart.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class InquiryPage : ContentPage
    {
		public InquiryPageVM viewModel { get; set; }
        public InquiryPage()
        {
            try
            {
                BindingContext = viewModel = new InquiryPageVM();
                InitializeComponent();
                messageEditor.Text = "Write Your Message here ..."; //initialize the Editor.Text and TextColor on the XAML file or on the constructor on the code behind with the PlaceHolder or whatever you want.
                messageEditor.TextColor = Color.Gray;
                NavigationPage.SetBackButtonTitle(this, "");
            }
            catch { }
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Error", "This is not supported in your device", "OK");
                    return;
                }

                var mediaOptions = new PickMediaOptions() { PhotoSize = PhotoSize.Medium };
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile == null)
                {
                    await DisplayAlert("Error", "This was error trying to get image", "OK");
                    return;
                }

                selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                Helpers.Data.Data.QueryImage = selectedImageFile;
            }
            catch { }
         
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
            catch
            { }
        }   
    }
}
