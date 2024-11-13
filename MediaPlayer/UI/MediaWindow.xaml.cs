using MediaPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MediaPlayer.UI
{
    /// <summary>
    /// Interaction logic for MediaWindow.xaml
    /// </summary>
    public partial class MediaWindow : Window
    {
        private bool _isPlaying = false;

        private bool _isSeeking = false;

        private bool _isFullScreen = false;

        private double _lastPosition = 0;

        private DateTime _lastSeek = DateTime.MinValue;

        private DispatcherTimer _timer = new DispatcherTimer();

        public string HoveredTime { get; set; }

        public MediaWindow(string filePath, string cover, MediaType type)
        {
            InitializeComponent();
            PlayMedia(filePath, cover, type);
            Element.Volume = VolumeSlider.Value;
            InitTimer();
            DataContext = this;
        }

        private void InitTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_isSeeking && Element.NaturalDuration.HasTimeSpan)
            {
                ProgressBar.Value = Element.Position.TotalSeconds;
                var currentPosition = Element.Position;
                CurrentTimeTextBlock.Text = $"{currentPosition.Hours:D2}:{currentPosition.Minutes:D2}:{currentPosition.Seconds:D2}";
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isPlaying)
            {
                Element.Pause();
                PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/play.png"));
                _isPlaying = false;
                _timer.Stop();
            }
            else
            {
                Element.Play();
                PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/pause.png"));
                _isPlaying = true;
                _timer.Start();
            }
            
        }

        private void Element_MediaEnded(object sender, RoutedEventArgs e)
        {
            PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/play.png"));
            Element.Position = TimeSpan.Zero;
            ProgressBar.Value = 0;
            _isPlaying = false;
            _timer.Stop();
            Element.Pause();
        }

        private void Element_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/play.png"));
            _isPlaying = false;
            _timer.Stop();
        }

        private void PlayMedia(string filePath, string cover, MediaType mediaType)
        {
            if (mediaType == MediaType.Video)
            {
                Element.Visibility = Visibility.Visible;
                CoverImage.Visibility = Visibility.Collapsed;
                Element.Source = new Uri(filePath);
            }
            else if (mediaType == MediaType.Audio) 
            {
                Element.Visibility = Visibility.Collapsed;
                CoverImage.Visibility = Visibility.Visible;
                CoverImage.Source = new BitmapImage(new Uri(cover));
                Element.Source = new Uri(filePath);
            }
            Element.Play();
            PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/pause.png"));
            _isPlaying = true;
        }

        private void Element_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue != e.OldValue)
            {
                Element.Volume = e.NewValue / 100;
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Element != null )
            {
                Element.Position = TimeSpan.FromSeconds(ProgressBar.Value);
            }
        }

        private void Element_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Element.NaturalDuration.HasTimeSpan)
            {
                ProgressBar.Maximum = Element.NaturalDuration.TimeSpan.TotalSeconds;
                var totalDuration = Element.NaturalDuration.TimeSpan;
                CurrentTimeTextBlock.Text = $"{totalDuration.Hours:D2}:{totalDuration.Minutes:D2}:{totalDuration.Seconds:D2}";
                MaxTimeTextBlock.Text = Element.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");

                _isSeeking = false;
            }
            else
            {
                MaxTimeTextBlock.Text = "00:00:00";
                ProgressBar.Maximum = 0;
            }
            _timer.Start();

        }

        private void ProgressBar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isSeeking = true;
            System.Windows.Point clickPosition = e.GetPosition(ProgressBar);
            double newValue = (clickPosition.X / ProgressBar.ActualWidth) * ProgressBar.Maximum;
            ProgressBar.Value = newValue;
            Element.Position = TimeSpan.FromSeconds(newValue);
            _timer.Stop();
            Element.Pause();
        }

        private void ProgressBar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isSeeking)
            {
                Element.Position = TimeSpan.FromSeconds(ProgressBar.Value);
                Element.Play();
                PlayButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/pause.png"));

                _isPlaying = true;
                _isSeeking = false;
                _timer.Start();
                
            }
        }

        private void FullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isFullScreen)
            {
                ExitFullScreenMode();
            }
            else
            {
                EnterFullScreenMode();
            }
        }

        private void EnterFullScreenMode()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Normal;
            this.WindowState = WindowState.Maximized;
            this.Topmost = true;

            this.ShowInTaskbar = false;

            _isFullScreen = true;
            FullScreenButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/minimize.png"));
        }

        private void ExitFullScreenMode()
        {
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.WindowState = WindowState.Normal;
            this.Topmost = false;

            this.ShowInTaskbar = true;

            _isFullScreen = false;
            FullScreenButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/expand.png"));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized && !_isFullScreen)
            {
                FullScreenButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/expand.png"));
            }
            else if (this.WindowState == WindowState.Normal && _isFullScreen)
            {
                FullScreenButtonImage.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/expand.png"));
            }
        }

        private void VolumeSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point clickPosition = e.GetPosition(VolumeSlider);

            double newValue = (clickPosition.X / VolumeSlider.ActualWidth) * (VolumeSlider.Maximum - VolumeSlider.Minimum) + VolumeSlider.Minimum;

            VolumeSlider.Value = newValue;
            Element.Volume = newValue / 100;
        }

        private void ProgressBar_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isSeeking && Element.NaturalDuration.HasTimeSpan)
            {
                System.Windows.Point mousePosition = e.GetPosition(ProgressBar);
                double newValue = (mousePosition.X / ProgressBar.ActualWidth) * ProgressBar.Maximum;

                ProgressBar.Value = newValue;

                TimeSpan hoveredTime = TimeSpan.FromSeconds(newValue);
                HoveredTime = $"{hoveredTime.Hours:D2}:{hoveredTime.Minutes:D2}:{hoveredTime.Seconds:D2}";

                ToolTipService.SetToolTip(ProgressBar, HoveredTime);
            }

        }
    }
}
