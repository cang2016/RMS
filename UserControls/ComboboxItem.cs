using System;

namespace RMS.UserControls
{
	/// <summary>
	/// ComboboxItem ��ժҪ˵����
	/// </summary>
	public class ComboboxItem
	{
		public ComboboxItem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private string m_userName = string.Empty; 
		private string m_Id = string.Empty; 
		private string m_logName = string.Empty; 
		private string m_search = string.Empty; 
		private string m_depId = string.Empty; 

		public  string Text 
		{ 
			get 
			{ 
				return m_userName; 
			} 
			set 
			{ 
				m_userName = value; 
			} 
		} 

		public string Value 
		{ 
			get 
			{ 
				return m_Id; 
			} 
			set 
			{ 
				m_Id = value; 
			} 
		} 

		public string Code 
		{ 
			get 
			{ 
				return m_logName;
			} 
			set 
			{ 
				m_logName = value; 
			} 
		} 

		public string SearchWord 
		{ 
			get 
			{ 
				return m_search;
			} 
			set 
			{ 
				m_search = value;
			} 
		} 

		public string Tag 
		{ 
			get 
			{ 
				return m_depId; 
			} 
			set 
			{ 
				m_depId = value; 
			} 
		}

		public override string ToString() 
		{ 
			return m_userName; 
		} 
	}
}
