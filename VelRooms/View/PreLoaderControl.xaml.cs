using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace PreLoader.CustomControls
{
    /// <summary>
    /// Interaction logic for PreLoaderControl.xaml
    /// </summary>
    public partial class PreLoaderControl : UserControl
    {
        private bool Animation1RuningForward = true;
        private bool Animation2RuningForward = true;
        private bool Animation3RuningForward = true;
        private bool Animation4RuningForward = true;
        private double blockWidth = 16;

        public PreLoaderControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Double blockSplitWidth = this.Width / 100;
            if (blockSplitWidth > 0.50)
                blockSplitWidth = 0.50;
            blockWidth = (this.Width / 2) - (blockSplitWidth * 4);
            double blockHeight = (this.Height / 2) - (blockSplitWidth * 4);
            gridBlock1.Width = blockWidth;
            gridBlock2.Width = blockWidth;
            gridBlock3.Width = blockWidth;
            gridBlock4.Width = blockWidth;
            gridBlock1.Height = blockHeight;
            gridBlock2.Height = blockHeight;
            gridBlock3.Height = blockHeight;
            gridBlock4.Height = blockHeight;
            StartAnimation("ProgressAnimation1", Animation1RuningForward);
        }

        private void ProgressAnimation1_Completed(object sender, EventArgs e)
        {
            Animation1RuningForward = !Animation1RuningForward;
            StartAnimation("ProgressAnimation2", Animation2RuningForward);
        }

        private void ProgressAnimation2_Completed(object sender, EventArgs e)
        {
            Animation2RuningForward = !Animation2RuningForward;
            StartAnimation("ProgressAnimation3", Animation3RuningForward);
        }

        private void ProgressAnimation3_Completed(object sender, EventArgs e)
        {
            Animation3RuningForward = !Animation3RuningForward;
            StartAnimation("ProgressAnimation4", Animation4RuningForward);
        }

        private void ProgressAnimation4_Completed(object sender, EventArgs e)
        {
            Animation4RuningForward = !Animation4RuningForward;
            StartAnimation("ProgressAnimation1", Animation1RuningForward);
        }

        private void StartAnimation(String storyboardResourceName, bool RunForward)
        {
            double widthFrom = blockWidth;
            double widthTo = 0;
            if (RunForward)
            {
                widthFrom = blockWidth;
                widthTo = 0;
            }
            else
            {
                widthFrom = 0;
                widthTo = blockWidth;
            }
            Storyboard storyboard = this.FindResource(storyboardResourceName) as Storyboard;
            DoubleAnimation doubleanimation = storyboard.Children[0] as DoubleAnimation;
            doubleanimation.From = widthFrom;
            doubleanimation.To = widthTo;
            storyboard.Begin();
        }
    }
}
