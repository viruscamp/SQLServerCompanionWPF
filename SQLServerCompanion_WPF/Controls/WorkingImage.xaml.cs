using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SQLServerCompanion.Controls
{
    /// <summary>
    /// Interaction logic for WorkingImage.xaml
    /// </summary>
    public partial class WorkingImage : UserControl
    {
        public WorkingImage()
        {
            InitializeComponent();
        }

        public double ImageSize
        {
            get { return this.LayoutRoot.Width; }
            set
            {
                this.LayoutRoot.Width = value;
                this.LayoutRoot.Height = value;
            }
        }

        public Brush ImageBrush
        {
            get { return this.Ellipse0.Fill; }
            set
            {
                this.Ellipse0.Fill = value;
                this.Ellipse1.Fill = value;
                this.Ellipse2.Fill = value;
                this.Ellipse3.Fill = value;
                this.Ellipse4.Fill = value;
                this.Ellipse5.Fill = value;
                this.Ellipse6.Fill = value;
                this.Ellipse7.Fill = value;
            }
        }

        public Visibility ImageVisibility
        {
            get { return this.LayoutRoot.Visibility; }
            set { this.LayoutRoot.Visibility = value; }
        }

        public string ImageMessageText
        {
            get { return this.Message.Text; }
            set
            {
                this.Message.Text = value;

                if (value == string.Empty)
                    this.Message.Visibility = Visibility.Collapsed;
                else
                    this.Message.Visibility = Visibility.Visible;
            }
        }

        public Visibility ImageMessageVisibility
        {
            get { return this.Message.Visibility; }
            set { this.Message.Visibility = value; }
        }

        public FontFamily ImageMessageFontFamily
        {
            get { return this.Message.FontFamily; }
            set { this.Message.FontFamily = value; }
        }

        public double ImageMessageFontSize
        {
            get { return this.Message.FontSize; }
            set { this.Message.FontSize = value; }
        }

        public FontWeight ImageMessageFontWeight
        {
            get { return this.Message.FontWeight; }
            set { this.Message.FontWeight = value; }
        }

        public FontStyle ImageMessageFontStyle
        {
            get { return this.Message.FontStyle; }
            set { this.Message.FontStyle = value; }
        }

        public String ImageDockPosition
        {
            get { return this.LayoutRoot.Tag.ToString(); }
            set { this.LayoutRoot.Tag = value; }
        }

        public String ImageMessageDockPosition
        {
            get { return this.Message.Tag.ToString(); }
            set
            {
                this.Message.Tag = value;

                switch (value.ToLower())
                {
                    case "left":
                        {
                            this.LayoutRoot.Tag = "right";
                            break;
                        }
                    case "right":
                        {
                            this.LayoutRoot.Tag = "left";
                            break;
                        }
                    case "top":
                        {
                            this.LayoutRoot.Tag = "bottom";
                            break;
                        }
                    case "bottom":
                        {
                            this.LayoutRoot.Tag = "top";
                            break;
                        }
                    default:
                        this.Message.Tag = "bottom";
                        this.LayoutRoot.Tag = "top";
                        break;
                }
            }
        }
    }
}
