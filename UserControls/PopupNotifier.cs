using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RMS.UserControls
{
    [DefaultEvent("Click")]
    public class PopupNotifierOld : Component
    {
        #region Event & Delegate
        public event ClickEventHandler Click;
        public delegate void ClickEventHandler();
        public event CloseEventHandler Close;
        public delegate void CloseEventHandler();
        #endregion

        #region Filed
        private PopupNotifierForm fPopup;
        private Timer tmAnimation;
        private Timer tmWait;
        private IContainer container;
        private bool bMouseIsOn = false;
        private bool bAppearing = true;
        private int iMaxPosition;
        private double dMaxOpacity;
        #endregion

        public bool bShouldRemainVisible = false;

        #region Properties

        private Color clHeader = SystemColors.ControlDark;
        [Category("Header"), DefaultValue(typeof(Color), "ControlDark")]
        public Color HeaderColor
        {
            get { return clHeader; }

            set { clHeader = value; }
        }

        private Color clBody = SystemColors.Control;
        [Category("Appearance"), DefaultValue(typeof(Color), "Control")]
        public Color BodyColor
        {
            get { return clBody; }

            set { clBody = value; }
        }

        private Color clTitle = Color.Gray;
        [Category("Title"), DefaultValue(typeof(Color), "Gray")]
        public Color TitleColor
        {
            get { return clTitle; }

            set { clTitle = value; }
        }

        private Color clBase = SystemColors.ControlText;
        [Category("Content"), DefaultValue(typeof(Color), "ControlText")]
        public Color ContentColor
        {
            get { return clBase; }

            set { clBase = value; }
        }

        private Color clBorder = SystemColors.WindowFrame;
        [Category("Appearance"), DefaultValue(typeof(Color), "WindowFrame")]
        public Color BorderColor
        {
            get { return clBorder; }

            set { clBorder = value; }
        }

        private Color clCloseBorder = SystemColors.WindowFrame;
        [Category("Buttons"), DefaultValue(typeof(Color), "WindowFrame")]
        public Color ButtonBorderColor
        {
            get { return clCloseBorder; }

            set { clCloseBorder = value; }
        }

        private Color clCloseHover = SystemColors.Highlight;
        [Category("Buttons"), DefaultValue(typeof(Color), "Highlight")]
        public Color ButtonHoverColor
        {
            get { return clCloseHover; }

            set { clCloseHover = value; }
        }

        private Color clLinkHover = SystemColors.HotTrack;
        [Category("Appearance"), DefaultValue(typeof(Color), "HotTrack")]
        public Color LinkHoverColor
        {
            get { return clLinkHover; }

            set { clLinkHover = value; }
        }

        private int iDiffGradient = 50;
        [Category("Appearance"), DefaultValue(50)]
        public int GradientPower
        {
            get { return iDiffGradient; }

            set { iDiffGradient = value; }
        }

        private Font ftBase = SystemFonts.DialogFont;
        [Category("Content")]
        public Font ContentFont
        {
            get { return ftBase; }
            set { ftBase = value; }
        }

        private Font ftTitle = SystemFonts.CaptionFont;
        [Category("Title")]
        public Font TitleFont
        {
            get { return ftTitle; }

            set { ftTitle = value; }
        }

        private Point ptImagePosition = new Point(12, 21);
        [Category("Image")]
        public Point ImagePosition
        {
            get { return ptImagePosition; }

            set { ptImagePosition = value; }
        }

        private Size szImageSize = new Size(0, 0);
        [Category("Image")]
        public Size ImageSize
        {
            get
            {
                if (szImageSize.Width == 0)
                {
                    if ((Image != null))
                    {
                        return Image.Size;
                    }
                    else
                    {
                        return new Size(32, 32);
                    }
                }
                else
                {
                    return szImageSize;
                }
            }

            set { szImageSize = value; }
        }

        private Image imImage = null;
        [Category("Image")]
        public Image Image
        {
            get { return imImage; }

            set { imImage = value; }
        }

        private bool bShowGrip = true;
        [Category("Header"), DefaultValue(true)]
        public bool ShowGrip
        {
            get { return bShowGrip; }

            set { bShowGrip = value; }
        }

        private string sText;
        [Category("Content")]
        public string ContentText
        {
            get { return sText; }

            set { sText = value; }
        }

        private string sTitle;
        [Category("Title")]
        public string TitleText
        {
            get { return sTitle; }

            set { sTitle = value; }
        }

        private Padding pdTextPadding = new Padding(0);
        [Category("Appearance")]
        public Padding TextPadding
        {
            get { return pdTextPadding; }

            set { pdTextPadding = value; }
        }

        private int iHeaderHeight = 9;
        [Category("Header"), DefaultValue(9)]
        public int HeaderHeight
        {
            get { return iHeaderHeight; }

            set { iHeaderHeight = value; }
        }

        private bool bCloseButtonVisible = true;
        [Category("Buttons"), DefaultValue(true)]
        public bool CloseButton
        {
            get { return bCloseButtonVisible; }

            set { bCloseButtonVisible = value; }
        }

        private bool bOptionsButtonVisible = false;
        [Category("Buttons"), DefaultValue(false)]
        public bool OptionsButton
        {
            get { return bOptionsButtonVisible; }

            set { bOptionsButtonVisible = value; }
        }

        private ContextMenuStrip withEventsField_ctContextMenu = null;
        private ContextMenuStrip ctContextMenu
        {
            get { return withEventsField_ctContextMenu; }
            set
            {
                if (withEventsField_ctContextMenu != null)
                {
                    withEventsField_ctContextMenu.Closed -= ctContextMenu_Closed;
                }
                withEventsField_ctContextMenu = value;
                if (withEventsField_ctContextMenu != null)
                {
                    withEventsField_ctContextMenu.Closed += ctContextMenu_Closed;
                }
            }
        }
        [Category("Behavior")]
        public ContextMenuStrip OptionsMenu
        {
            get { return ctContextMenu; }
            set { ctContextMenu = value; }
        }

        private int iShowDelay = 3000;
        [Category("Behavior"), DefaultValue(3000)]
        public int ShowDelay
        {
            get { return iShowDelay; }
            set { iShowDelay = value; }
        }

        private Size szSize = new Size(400, 100);
        [Category("Appearance")]
        public Size Size
        {
            get { return szSize; }
            set { szSize = value; }
        }

        #endregion

        #region Constructor
        public PopupNotifierOld()
        {
            Initialize();
        }

        private void Initialize()
        {
            tmAnimation = container == null ? new Timer() : new Timer(container);
            tmAnimation.Tick += tmAnimation_Tick;
            tmAnimation.Interval = 30;

            tmWait = container == null ? new Timer() : new Timer(container);
            tmWait.Tick += tmWait_Tick;
            tmWait.Interval = ShowDelay;
        }

        public PopupNotifierOld(IContainer container)
        {
            this.container = container;
            Initialize();
        }
        #endregion

        #region Public Method
        public void Popup()
        {
            fPopup = new PopupNotifierForm(this);
            fPopup.TopMost = true;
            fPopup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fPopup.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            fPopup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            fPopup.CloseClick += fPopup_CloseClick;
            fPopup.LinkClick += fPopup_LinkClick;
            fPopup.MouseEnter += fPopup_MouseEnter;
            fPopup.MouseLeave += fPopup_MouseLeave;

            fPopup.Size = Size;
            fPopup.Opacity = 0;
            fPopup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - fPopup.Size.Width - 1, Screen.PrimaryScreen.WorkingArea.Bottom);

            fPopup.Show();

            tmAnimation.Start();
        }
        #endregion

        #region Private Method
        private void fPopup_CloseClick(object sender, EventArgs e)
        {
            if (Close != null)
            {
                Close();
            }
        }
        private void fPopup_LinkClick(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click();
            }
        }
        private double GetOpacityBasedOnPosition()
        {
            int iCentPourcent = fPopup.Height;
            int iCurrentlyShown = Screen.PrimaryScreen.WorkingArea.Height - fPopup.Top;
            double dPourcentOpacity = iCentPourcent / 100 * iCurrentlyShown;
            return (dPourcentOpacity / 100) - 0.05;
        }
        private void tmAnimation_Tick(object sender, System.EventArgs e)
        {
            if (bAppearing)
            {
                fPopup.Top -= 2;
                fPopup.Opacity = GetOpacityBasedOnPosition();
                if (fPopup.Top + fPopup.Height < Screen.PrimaryScreen.WorkingArea.Bottom)
                {
                    tmAnimation.Stop();
                    bAppearing = false;
                    iMaxPosition = fPopup.Top;
                    dMaxOpacity = fPopup.Opacity;
                    tmWait.Start();
                }
            }
            else
            {
                if (bMouseIsOn)
                {
                    fPopup.Top = iMaxPosition;
                    fPopup.Opacity = dMaxOpacity;
                    tmAnimation.Stop();
                    tmWait.Start();
                }
                else
                {
                    fPopup.Top += 2;
                    fPopup.Opacity = GetOpacityBasedOnPosition();
                    if (fPopup.Top > Screen.PrimaryScreen.WorkingArea.Bottom)
                    {
                        tmAnimation.Stop();
                        fPopup.Hide();
                        bAppearing = true;
                    }
                }
            }
        }
        private void tmWait_Tick(object sender, System.EventArgs e)
        {
            tmWait.Stop();
            tmAnimation.Start();
        }
        private void fPopup_MouseEnter(object sender, System.EventArgs e)
        {
            bMouseIsOn = true;
        }
        private void fPopup_MouseLeave(object sender, System.EventArgs e)
        {
            if (!bShouldRemainVisible)
            {
                bMouseIsOn = false;
            }
        }
        private void ctContextMenu_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
        {
            bShouldRemainVisible = false;
            bMouseIsOn = false;
            tmAnimation.Start();
        }
        #endregion
    }

    public class PopupNotifier
    {
        public static string ContentText { get; set; }
        public static Size Size { get; set; }
        public static int ShowDelay { get; set; }

        private static PopupNotifierListForm newPopupForm = null;
        private static List<string> messageList = new List<string>();
        private static List<Size> sizeList = new List<Size>();
        private static List<int> delayList = new List<int>();

        public PopupNotifier()
        {

        }

        public static void Popup()
        {
            if (newPopupForm == null)
            {
                newPopupForm = new PopupNotifierListForm();
                newPopupForm.PopupClose += new PopupNotifierListForm.PopupNotifierCloseHandler(PopupClose);
                newPopupForm.Show();
            }
            else
            {
                messageList.Add(ContentText);
                sizeList.Add(Size);
                delayList.Add(ShowDelay);
            }
        }

        private static void PopupClose()
        {
            if (messageList.Count == 0)
            {
                if (newPopupForm != null)
                {
                    newPopupForm.Close();
                    newPopupForm = null;
                }
            }
            else
            {
                newPopupForm.ResetValue(messageList[0], sizeList[0], delayList[0]);
                messageList.RemoveAt(0);
                sizeList.RemoveAt(0);
                delayList.RemoveAt(0);
            }
        }
    }
}