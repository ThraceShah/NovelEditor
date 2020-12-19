using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Novel.Models;
using muxc = Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.AccessCache;
using System.Diagnostics;
using FileLoad.Model;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace NovelEditor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 写作页 : Page
    {
        public List<VolumeChapter> chapterVolume;
        public 写作页()
        {
            this.InitializeComponent();
            chapterVolume = VolumeManager.GetVolume();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri uri = new Uri("ms-appx:///Assets/1/第四卷 巫与神/sample.txt");
            StorageFile sampleFile = await StorageFile.GetFileFromApplicationUriAsync(uri);
            //StorageFile sampleFile = await StorageFile.GetFileFromPathAsync(@"M:\Thrace_Code\UWPFile\Assets\1\第四卷 巫与神\sam.rtf");
            if (sampleFile != null)
            {
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Load the file into the Document property of the RichEditBox.
                    editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
            }
        }


        private void NavView_BackRequested(muxc.NavigationView sender, muxc.NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }
        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }
        private bool On_BackRequested()
        {
            if (!Frame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == muxc.NavigationViewDisplayMode.Compact ||
                 NavView.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
                return false;

            Frame.GoBack();
            return true;
        }

        private void NavView_ItemInvoked(muxc.NavigationView sender, muxc.NavigationViewItemInvokedEventArgs args)
        {

        }
    }
}
