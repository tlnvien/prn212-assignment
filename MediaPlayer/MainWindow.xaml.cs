using FFmpeg.AutoGen;
using MediaPlayer.Models;
using MediaPlayer.UI;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RecentlyMedia> RecentlyMedias { get; set; } = new ObservableCollection<RecentlyMedia>();

        public ObservableCollection<string> Playlists { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            RecentlyPlayedList.ItemsSource = RecentlyMedias;
            PlaylistListBox.ItemsSource = Playlists;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MusicButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VideoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mkv|Audio Files|*.mp3;*.wav;*.flac|All Files|*.*",
                Multiselect = false
            };

            bool? result = ofd.ShowDialog();
            if (result == true)
            {
                string filePath = ofd.FileName;

                string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
                if (IsVideoFile(fileExtension)) {
                    string coverImage = ExtractRandomFrameFromVideo(filePath);
                    DisplayMedia(filePath, coverImage, MediaType.Video);
                }
                else if (IsAudioFile(fileExtension))
                {
                    string iconPath = @"pack://application:,,,/Images/music-notes-icon.png";
                    DisplayMedia(filePath, iconPath, MediaType.Audio);
                }
            }
        }

        private void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool IsVideoFile(string extension)
        {
            string[] videoExtensions = { ".mp4", ".avi", ".mkv" };
            return videoExtensions.Contains(extension);
        }

        private bool IsAudioFile(string extension)
        {
            string[] audioExtensions = { ".mp3", ".wav", ".flac" };
            return audioExtensions.Contains(extension);
        }

        private string ExtractRandomFrameFromVideo(string filePath)
        {
            string outputImage = $"D:\\cover_image_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

            VideoProcessor.GetRandomFrame(filePath, outputImage);
            return outputImage;
        }

        private void DisplayMedia(string filePath, string cover, MediaType mediaType)
        {
            if (!RecentlyMedias.Any(media => media.FileName.Equals(filePath, StringComparison.OrdinalIgnoreCase)))
            {
                var mediaItem = new RecentlyMedia
                {
                    FileName = filePath,
                    MediaType = mediaType,
                    CoverArt = cover
                };
                RecentlyMedias.Add(mediaItem);
            }

            OpenMediaWindow(filePath, cover, mediaType);
        }

        private void RecentlyPlayedList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecentlyPlayedList.SelectedItem is RecentlyMedia selectedMedia)
            {
                OpenMediaWindow(selectedMedia.FileName, selectedMedia.MediaType == MediaType.Video ? selectedMedia.CoverArt : @"pack://application:,,,/Images/music-notes-icon.png", selectedMedia.MediaType);
            }
        }

        private void OpenMediaWindow(string filePath, string cover, MediaType type)
        {
            MediaWindow mediaWindow = new(filePath, cover, type);
            mediaWindow.Show();
        }
    }
}