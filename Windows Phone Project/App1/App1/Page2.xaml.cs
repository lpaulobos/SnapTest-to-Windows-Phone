using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
            Start_Capture_Preview();
        }
        Windows.Media.Capture.MediaCapture captureManager;
        async private void Start_Capture_Preview()
        {
            captureManager = new MediaCapture();    //Define MediaCapture object  
            await captureManager.InitializeAsync();   //Initialize MediaCapture and   
            captureManager.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
            capturePreview.Source = captureManager;   //Start preiving on CaptureElement 
            await captureManager.StartPreviewAsync();  //Start camera capturing   
        }
        async private void Stop_Capture_Preview_Click(object sender, RoutedEventArgs e)
        {
            await captureManager.StopPreviewAsync();  //stop camera capturing  
        }
        async private void Capture_Photo_Click(object sender, RoutedEventArgs e)
        {
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.ReplaceExisting);
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
            imagePreview.Source = bmpImage;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
