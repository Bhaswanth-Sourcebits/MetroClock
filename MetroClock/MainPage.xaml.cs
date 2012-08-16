using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MetroClock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void SetAndStartClock(object sender, RoutedEventArgs e)
        {

            // The current date and time.
            System.DateTime currentDate = DateTime.Now;

            // Find the appropriate angle (in degrees) for the hour hand
            // based on the current time.
            double hourangle = (((float)currentDate.Hour) / 12) * 360 + currentDate.Minute / 2;


            // The same as for the minute angle.
            double minangle = (((float)currentDate.Minute) / 60) * 360;

            // The same for the second angle.
            double secangle = (((float)currentDate.Second) / 60) * 360;

            // Set the beginning of the animation (From property) to the angle 
            // corresponging to the current time.
            hourAnimation.From = hourangle;

            // Set the end of the animation (To property)to the angle 
            // corresponding to the current time PLUS 360 degrees. Thus, the
            // animation will end after the clock hand moves around the clock 
            // once. Note: The RepeatBehavior property of the animation is set
            // to "Forever" so the animation will begin again as soon as it completes.
            hourAnimation.To = hourangle + 360;

            // Same as with the hour animation.
            minuteAnimation.From = minangle;
            minuteAnimation.To = minangle + 360;

            // Same as with the hour animation.
            secondAnimation.From = secangle;
            secondAnimation.To = secangle + 360;

            // Start the storyboard.
            clockStoryboard.Begin();
        }
    }
}
