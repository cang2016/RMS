using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace RMS.UserControls
{
    public sealed partial class MsgBox : Form
    {
        public MessageBoxViewModel DataContext { get; set; }
        private static bool coverAddCancelFlag = false;

        public MsgBox()
        {
            InitializeComponent();
            this.chkShowDetails.Checked = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            SetImage();

            SetMessage();

            SetButtons();

            SetShowDetails();
            if (coverAddCancelFlag)
            {
                this.btnYes.Text = "Overwrite";
                this.btnNo.Text = "Add";
            }
            coverAddCancelFlag = false;
        }

        private void SetImage()
        {
            switch (this.DataContext.Image)
            {
                case CCMessageBoxImage.Information:
                    pictureBox2.Image = Properties.Resources.Info; 
                    break;
                case CCMessageBoxImage.Question:
                    pictureBox2.Image = Properties.Resources.Help;
                    break;
                case CCMessageBoxImage.Error:
                    pictureBox2.Image = Properties.Resources.Error;
                    break;
                case CCMessageBoxImage.OK:
                    pictureBox2.Image = Properties.Resources.OK;
                    break;
                case CCMessageBoxImage.Alert:
                    pictureBox2.Image = Properties.Resources.Alert;
                    break;
                case CCMessageBoxImage.Default:
                    pictureBox2.Image = Properties.Resources.Default;
                    break;
                default:
                    break;
            }
        }

        private void SetMessage()
        {
            this.Text = this.DataContext.Title;
            this.MessageRichTextBox.Text = this.DataContext.Message;
            this.DetailsRichTextBox.Text = this.DataContext.InnerMessageDetails;
        }

        private void SetShowDetails()
        {
            if (string.IsNullOrEmpty(this.DataContext.InnerMessageDetails))
                this.chkShowDetails.Visible = false;
            else
                this.chkShowDetails.Visible = true;
        }

        private void SetButtons()
        {
            this.btnYes.Visible = false;
            this.btnNo.Visible = false;
            this.btnCancel.Visible = false;
            this.btnClose.Visible = false;
            this.btnOK.Visible = false;

            switch (DataContext.ButtonOption)
            {
                case CCMessageBoxButtons.YesNo:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;

                    break;
                case CCMessageBoxButtons.YesNoCancel:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    this.btnCancel.Visible = true;

                    break;
                case CCMessageBoxButtons.OKCancel:
                    this.btnOK.Visible = true;
                    this.btnCancel.Visible = true;

                    break;
                case CCMessageBoxButtons.OKClose:
                    this.btnOK.Visible = true;
                    this.btnClose.Visible = true;

                    break;
                case CCMessageBoxButtons.OK:
                    this.btnOK.Visible = true;

                    break;
                case CCMessageBoxButtons.Close:
                    this.btnClose.Visible = true;

                    break;
            }

            AdjustButtonsLayout();
        }

        private void AdjustButtonsLayout()
        {
            List<Control> controlsRight2Left = new List<Control>();
            foreach (var item in this.panelButtons.Controls)
            {
                controlsRight2Left.Add(item as Control);
            }
            controlsRight2Left.Sort((x, y) => { return 0 - x.Left.CompareTo(y.Left); });

            int rightSpaceWidth = 0;
            int intervalSpace = 10;
            foreach (var item in controlsRight2Left)
            {
                if (item is Button)
                {
                    Button btn = item as Button;
                    if (item.Visible)
                    {
                        btn.Left = this.panelButtons.Width - btn.Width - intervalSpace - rightSpaceWidth;
                        rightSpaceWidth += intervalSpace;
                        rightSpaceWidth += btn.Width;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.panelDetail.Visible = chkShowDetails.Checked;

            if (this.panelDetail.Visible)
                this.Height = 300;
            else
                this.Height = 156;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public static DialogResult Show(string message)
        {
            return Show(string.Empty, message, string.Empty, CCMessageBoxButtons.OK, CCMessageBoxImage.Default);
        }

        public static DialogResult Show(string title, string message)
        {
            return Show(title, message, string.Empty, CCMessageBoxButtons.OK, CCMessageBoxImage.Default);
        }

        public static DialogResult Show(string title, string message, string details)
        {
            return Show(title, message, details, CCMessageBoxButtons.OK, CCMessageBoxImage.Default);
        }

        public static DialogResult Show(string title, string message, CCMessageBoxButtons buttonOption)
        {
            return Show(title, message, string.Empty, buttonOption, CCMessageBoxImage.Default);
        }

        public static DialogResult Show(string title, string message, string details, CCMessageBoxButtons buttonOption)
        {
            return Show(title, message, details, buttonOption, CCMessageBoxImage.Default);
        }

        public static DialogResult Show(string title, string message, CCMessageBoxImage image)
        {
            return Show(title, message, string.Empty, CCMessageBoxButtons.OK, image);
        }

        public static DialogResult Show(string title, string message, string details, CCMessageBoxImage image)
        {
            return Show(title, message, details, CCMessageBoxButtons.OK, image);
        }

        public static DialogResult Show(string title, string message, CCMessageBoxButtons buttonOption, CCMessageBoxImage image)
        {
            return Show(title, message, string.Empty, buttonOption, image);
        }

        public static DialogResult Show(string title, string message, string details, CCMessageBoxButtons buttonOption, CCMessageBoxImage image)
        {
            ___MessageBox = new MsgBox();
            MessageBoxViewModel __ViewModel = new MessageBoxViewModel(___MessageBox, title, message, details, buttonOption, image);
            ___MessageBox.DataContext = __ViewModel;
            ___MessageBox.ShowDialog();
            return ___MessageBox.DialogResult;
        }

        public static DialogResult Show(string title, string message, CCMessageBoxButtons buttonOption, CCMessageBoxImage image, bool coverAddCancel)
        {
            coverAddCancelFlag = coverAddCancel;
            return Show(title, message, string.Empty, buttonOption, image);
        }

        static MsgBox ___MessageBox;

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public enum CCMessageBoxButtons
    {
        YesNo,
        YesNoCancel,
        OKCancel,
        OKClose,
        OK,
        Close
    }

    public enum CCMessageBoxImage
    {
        Information,
        Question,
        Error,
        OK,
        Alert,
        Default
    }

    // Summary:
    //     Specifies the display state of an element.
    public enum Visibility
    {
        // Summary:
        //     Display the element.
        Visible = 0,
        //
        // Summary:
        //     Do not display the element, but reserve space for the element in layout.
        Hidden = 1,
        //
        // Summary:
        //     Do not display the element, and do not reserve space for it in layout.
        Collapsed = 2,
    }

    public class MessageBoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return ___Title; }
            set
            {
                if (___Title != value)
                {
                    ___Title = value;
                    NotifyPropertyChange("Title");
                }
            }
        }

        public CCMessageBoxButtons ButtonOption { get; set; }

        public CCMessageBoxImage Image { get; set; }

        public string Message
        {
            get { return ___Message; }
            set
            {
                if (___Message != value)
                {
                    ___Message = value;
                    NotifyPropertyChange("Message");
                }
            }
        }

        public string InnerMessageDetails
        {
            get { return ___InnerMessageDetails; }
            set
            {
                if (___InnerMessageDetails != value)
                {
                    ___InnerMessageDetails = value;
                    NotifyPropertyChange("InnerMessageDetails");
                }
            }
        }

        //public Visibility YesNoVisibility
        //{
        //    get { return ___YesNoVisibility; }
        //    set
        //    {
        //        if (___YesNoVisibility != value)
        //        {
        //            ___YesNoVisibility = value;
        //            NotifyPropertyChange("YesNoVisibility");
        //        }
        //    }
        //}

        //public Visibility CancelVisibility
        //{
        //    get { return ___CancelVisibility; }
        //    set
        //    {
        //        if (___CancelVisibility != value)
        //        {
        //            ___CancelVisibility = value;
        //            NotifyPropertyChange("CancelVisibility");
        //        }
        //    }
        //}

        //public Visibility OkVisibility
        //{
        //    get { return ___OKVisibility; }
        //    set
        //    {
        //        if (___OKVisibility != value)
        //        {
        //            ___OKVisibility = value;
        //            NotifyPropertyChange("OkVisibility");
        //        }
        //    }
        //}

        //public Visibility CloseVisibility
        //{
        //    get { return ___CloseVisibility; }
        //    set
        //    {
        //        if (___CloseVisibility != value)
        //        {
        //            ___CloseVisibility = value;
        //            NotifyPropertyChange("CloseVisibility");
        //        }
        //    }
        //}

        //public Visibility ShowDetails
        //{
        //    get { return ___ShowDetails; }
        //    set
        //    {
        //        if (___ShowDetails != value)
        //        {
        //            ___ShowDetails = value;
        //            NotifyPropertyChange("ShowDetails");
        //        }
        //    }
        //}


        public MessageBoxViewModel(MsgBox view,
            string title, string message, string innerMessage,
            CCMessageBoxButtons buttonOption, CCMessageBoxImage image)
        {
            Title = title;
            Message = message;
            InnerMessageDetails = innerMessage;
            ButtonOption = buttonOption;
            //SetButtonVisibility(buttonOption);
            //SetImageSource(image);
            Image = image;
        }

        void NotifyPropertyChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        void SetButtonVisibility(CCMessageBoxButtons buttonOption)
        {
            //switch (buttonOption)
            //{
            //    case MessageBoxButtons.YesNo:
            //        OkVisibility = CancelVisibility = CloseVisibility = Visibility.Collapsed;
            //        break;
            //    case MessageBoxButtons.YesNoCancel:
            //        OkVisibility = CloseVisibility = Visibility.Collapsed;
            //        break;
            //    case MessageBoxButtons.OK:
            //        YesNoVisibility = CancelVisibility = CloseVisibility = Visibility.Collapsed;
            //        break;
            //    case MessageBoxButtons.OKClose:
            //        YesNoVisibility = CancelVisibility = Visibility.Collapsed;
            //        break;
            //    default:
            //        OkVisibility = CancelVisibility = YesNoVisibility = Visibility.Collapsed;
            //        break;
            //}

            //if (string.IsNullOrEmpty(InnerMessageDetails))
            //    ShowDetails = Visibility.Collapsed;
            //else
            //    ShowDetails = Visibility.Visible;
        }

        void SetImageSource(CCMessageBoxImage image)
        {
            //string __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Default.png";
            //switch (image)
            //{
            //    case MessageBoxImage.Alert:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Alert.png";
            //        break;
            //    case MessageBoxImage.Error:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Error.png";
            //        break;
            //    case MessageBoxImage.Information:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Info.png";
            //        break;
            //    case MessageBoxImage.OK:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/OK.png";
            //        break;
            //    case MessageBoxImage.Question:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Help.png";
            //        break;
            //    default:
            //        __Source = "pack://application:,,,/BlogsPrajeesh.BlogSpot.WPFControls;component/Images/Default.png";
            //        break;

            //}
            //Uri __ImageUri = new Uri(__Source, UriKind.RelativeOrAbsolute);
            //MessageImageSource = new BitmapImage(__ImageUri);
        }

        string ___Title;
        string ___Message;
        string ___InnerMessageDetails;
    }

    // Summary:
    //     Defines a command.
    [TypeConverter("System.Windows.Input.CommandConverter, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    public interface ICommand
    {
        // Summary:
        //     Occurs when changes occur that affect whether or not the command should execute.
        event EventHandler CanExecuteChanged;

        // Summary:
        //     Defines the method that determines whether the command can execute in its
        //     current state.
        //
        // Parameters:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        //
        // Returns:
        //     true if this command can be executed; otherwise, false.
        bool CanExecute(object parameter);
        //
        // Summary:
        //     Defines the method to be called when the command is invoked.
        //
        // Parameters:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        void Execute(object parameter);
    }
}
