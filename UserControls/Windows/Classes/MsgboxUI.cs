using System;
using System.Windows.Forms;

namespace RMS.UserControls
{
	public static class MsgboxUI
	{
		static string defaultTitle = "";

		private static MsgboxResult ToMsgboxResult(DialogResult result)
		{
			switch (result)
			{
				case DialogResult.OK: return MsgboxResult.OK;
				case DialogResult.Cancel: return MsgboxResult.Cancel;
				case DialogResult.Yes: return MsgboxResult.Yes;
				case DialogResult.No: return MsgboxResult.No;
				default: return MsgboxResult.None;
			}
		}

		public static string DefaultTitle
		{
			get { return defaultTitle; }
			set { defaultTitle = value; }
		}

		public static MsgboxResult Show(string title, string message, MsgboxButtonStyle buttonStyle, MsgboxIconStyle iconStyle)
		{
			frmMsgBox frm = new frmMsgBox(title, message, buttonStyle, iconStyle);
			return ToMsgboxResult(frm.ShowDialog());
		}

		public static MsgboxResult Show(string message, MsgboxButtonStyle buttonStyle, MsgboxIconStyle iconStyle)
		{
			return Show(defaultTitle, message, buttonStyle, iconStyle);
		}

		//==================================================

		public static MsgboxResult OKCancelQuestion(string message)
		{
			return OKCancelQuestion(defaultTitle, message);
		}

		public static MsgboxResult OKCancelQuestion(string title, string message)
		{
			return Show(title, message, MsgboxButtonStyle.OKCancel, MsgboxIconStyle.Question);
		}

		//==================================================

		public static MsgboxResult YesNoQuestion(string message)
		{
			return YesNoQuestion(defaultTitle, message);
		}

		public static MsgboxResult YesNoQuestion(string title, string message)
		{
			return Show(title, message, MsgboxButtonStyle.YesNo, MsgboxIconStyle.Question);
		}

		//==================================================

		public static MsgboxResult YesNoCancel(string message)
		{
			return YesNoCancel(defaultTitle, message);
		}

		public static MsgboxResult YesNoCancel(string title, string message)
		{
			return Show(title, message, MsgboxButtonStyle.YesNoCancel, MsgboxIconStyle.Question);
		}

		//==================================================

		public static MsgboxResult Information(string title, string message)
		{
			return Show(title, message, MsgboxButtonStyle.OK, MsgboxIconStyle.Information);
		}

		public static MsgboxResult Information(string message)
		{
			return Information(defaultTitle, message);
		}

		//==================================================

		public static MsgboxResult Exlamation(string title, string message)
		{
			return Show(title, message, MsgboxButtonStyle.OK, MsgboxIconStyle.Exlamation);
		}

		public static MsgboxResult Exlamation(string message)
		{
			return Exlamation(defaultTitle, message);
		}

		//==================================================
	}
}
