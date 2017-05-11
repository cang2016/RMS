namespace RMS.UserControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 带水印文本的文本框.
    /// </summary>
    public class WaterMarkTextBox : TextBox
    {
        private bool flag = false;

        private string markText;
        public string MarkText
        {
            get
            {
                return markText;
            }
            set
            {
                markText = value;
                this.Text = value;
            }
        }
        public Control ParentControl
        {
            get;
            set;
        }
        public bool IsShowWaterText
        {
            get;
            set;
        }

        public bool StartSearch
        {
            get;
            set;
        }

        public WaterMarkTextBox(string MarkText)
        {
            StartSearch = false;
            IsShowWaterText = true;
            this.LostFocus += new EventHandler(TextBox_LostFocus);
            this.GotFocus += new EventHandler(TextBox_GotFocus);
            this.MarkText = MarkText;
            ShowWaterText();
        }

        public WaterMarkTextBox()
        {
            this.MarkText = "Type water text in here";
            InitMarkText(this.MarkText);
            flag = true;
        }

        public void InitMarkText(string MarkText)
        {
            if(!flag)
            {
                StartSearch = false;
                IsShowWaterText = true;
                this.LostFocus += new EventHandler(TextBox_LostFocus);
                this.GotFocus += new EventHandler(TextBox_GotFocus);
                this.MarkText = MarkText;
                ShowWaterText();
            }
            this.MarkText = MarkText;
            this.IsShowWaterText = true;
        }

        void TextBox_GotFocus(object sender, EventArgs e)
        {
            if(IsShowWaterText)
            {
                IsShowWaterText = false;
                StartSearch = true;
                RemoveWaterText();
            }
        }

        public void TextBox_LostFocus(object sender, EventArgs e)
        {
            StartSearch = false;
            if(this.Text.Length == 0)
            {
                IsShowWaterText = true;
                ShowWaterText();
            }
            else
            {
                IsShowWaterText = false;
            }
        }

        private void ShowWaterText()
        {
            this.Text = MarkText;
            this.ForeColor = Color.DarkSalmon;
        }

        private void RemoveWaterText()
        {
            this.Text = string.Empty;
            this.ForeColor = Color.Black;
        }
    }
}
