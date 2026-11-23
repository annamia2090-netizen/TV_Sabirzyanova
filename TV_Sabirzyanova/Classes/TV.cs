using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TV_Sabirzyanova;

namespace TV_Sabirzyanova.Classes
{
    public class TV
    {
        private int activeChannel;
        private int activeVolume;
        public int ActiveChannel
        {
            get
            {
                return activeChannel;
            }
            set
            {
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;
            }
        }
        public List<Channel> Channels = new List<Channel>();
        public TV()
        { 
            Channels.Add(new Channel()
        { 
            Name = "шапка.mp4",
            Src = "Video/шапка.mp4"
            });
            Channels.Add(new Channel()
        {
            Name = "китя.mp4",
            Src = "Video/китя.mp4"
            });
            Channels.Add(new Channel()
        {
            Name = "китя2.mp4",
            Src = "Video/китя2.mp4"
            });
    }
        public void SwapChanell(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src, UriKind.Relative);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content = this.Channels[this.ActiveChannel].Name;
        }

        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            if (!isTurnedOn) return;
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            if (!isTurnedOn) return; 
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void UpSound()
        {
        }
        public void DownSound()
        {
        }
        private bool isTurnedOn = true;
        public bool IsTurnedOn
        {
            get { return isTurnedOn; }
            set { isTurnedOn = value; }
        }
        public void SelectChannelByIndex(int index, System.Windows.Controls.MediaElement VideoPlayer, System.Windows.Controls.Label NameCHannel)
        {
            if (isTurnedOn && index >= 0 && index < Channels.Count)
            {
                ActiveChannel = index;
                SwapChanell(VideoPlayer, NameCHannel);
            }
        }
    }
}
