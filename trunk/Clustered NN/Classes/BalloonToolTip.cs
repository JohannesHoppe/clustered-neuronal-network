using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

/*
 * BalloonToolTip 
 * 
 * A Custom BalloonToolTip for .Net v1.1
 * http://www.codeproject.com/KB/miscctrl/ballontooltip.aspx
 */
namespace Clustered_NN.Classes
{

	[ProvideProperty("BalloonText", typeof(Control))]
	public class BalloonToolTip : System.ComponentModel.Component , IExtenderProvider
	{
		[DllImport("user32.dll")]
		private static extern IntPtr CreateWindowEx(int exstyle, string classname, string windowtitle, int style, int x, int y, int width, int height, IntPtr parent, int menu,
			int nullvalue, int nullptr);

		[DllImport("user32.dll")]
		private static extern int DestroyWindow(IntPtr hwnd);

		[DllImport("User32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        #pragma warning disable
        private struct toolinfo
		{
			public int size;
			public int flag;
			public IntPtr parent;

            public int id;

            public Rectangle rect;
			public int nullvalue;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string text;
			public int param;
        }
        #pragma warning restore

        // Used by some constants values, not by the code.
		private const int WM_USER = 0x0400;
		
		private const int TTM_ADDTOOL				= WM_USER + 50;		
		private const int TTM_DELTOOL				= WM_USER + 51;		
		private const int TTM_ACTIVATE				= WM_USER + 1;		
		private const int TTM_SETMAXTIPWIDTH		= WM_USER + 24;	
		private const int TTM_SETTITLE				= WM_USER + 33;
		private const int TTM_SETDELAYTIME			= WM_USER + 3;
		private const int TTM_UPDATETIPTEXT			= WM_USER + 57;
		private const int TTM_SETTIPBKCOLOR			= WM_USER + 19;
		private const int TTM_SETTIPTEXTCOLOR		= WM_USER + 20;
		private const int TTM_GETTOOLINFO			= WM_USER + 53;
		private const int TTM_SETTOOLINFO			= WM_USER + 54;

		private const int TTS_ALWAYSTIP				= 0x01;
		private const int TTS_NOPREFIX				= 0x02;
		private const int TTS_BALLOON				= 0x40;

		private const int TTF_SUBCLASS				= 0x0010;
		private const int TTF_TRANSPARENT			= 0x0100;

		private const int SWP_NOSIZE				= 0x0001;
		private const int SWP_NOMOVE				= 0x0002;
		private const int SWP_NOACTIVATE			= 0x0010;
		
		private const int TTDT_AUTOPOP		       = 2;
		private const int TTDT_INITIAL		       = 3;
		
		private const int WS_POPUP					= unchecked((int)0x80000000);
		private const int CW_USEDEFAULT				= unchecked((int)0x80000000);
		
		private IntPtr TOPMOST						= new IntPtr(-1);

		
		public enum BalloonIcons: int
		{
			None	= 0,
			Info	= 1,
			Warning	= 2,
			Error	= 3
		}

		private int max;
		private int autopop;
		private int initial;
		private bool enabled;
		private string title;
		private toolinfo tf;
		private System.Collections.Hashtable tooltexts;
		private BalloonIcons icon;
		private IntPtr toolwindow;
		private IntPtr tempptr;
		private Color bgcolor;
		private Color fgcolor;

		public BalloonToolTip()
		{
			// Private members initial values.
			max			= 200;
			autopop		= 5000;
			initial		= 500;
			title		= string.Empty;
			bgcolor		= Color.FromKnownColor(KnownColor.Info);
			fgcolor		= Color.FromKnownColor(KnownColor.InfoText);
			tooltexts	= new System.Collections.Hashtable();
			enabled		= true;
			icon		= BalloonIcons.None;

			// Creating the tooltip control.
			toolwindow = CreateWindowEx(0, "tooltips_class32", string.Empty, WS_POPUP | TTS_BALLOON | TTS_NOPREFIX | TTS_ALWAYSTIP, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, IntPtr.Zero, 0, 0, 0);
			SetWindowPos(toolwindow, TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
			SendMessage(toolwindow, TTM_SETMAXTIPWIDTH, 0, new IntPtr(max));
			
			// Creating the toolinfo structure to be used later.
			tf = new toolinfo();
			tf.flag = TTF_SUBCLASS | TTF_TRANSPARENT;
			tf.size = Marshal.SizeOf(typeof(toolinfo));
		}


		~BalloonToolTip()
		{
			Dispose(false);
		}


        /// <summary>
        /// Extend any control except itself and the form, this function get called for use automatically by the designer.
        /// </summary>
		public bool CanExtend(object extendee)
		{
			if( extendee is Control && !(extendee is BalloonToolTip) && !(extendee is Form))
			{
				return true;
			}

			return false;
		}


        /// <summary>
        /// This is not a regular function, its our extender property separated as two functions for get and set.
        /// </summary>
		public string GetBalloonText(Control parent)
		{
			if(tooltexts.Contains(parent))
			{
				return tooltexts[parent].ToString();
			}
			else
			{
				return null;
			}
		}


        /// <summary>
        /// This is where the tool text validated and updated for the controls.
        /// </summary>
		public void SetBalloonText(Control parent, string value)
		{
			if(value == null)
			{
				value = string.Empty;
			}
			// If the tool text have been cleared, remove the control from our service list.
			if(value == string.Empty)
			{
				tooltexts.Remove(parent);

				tf.parent = parent.Handle;

				tempptr = Marshal.AllocHGlobal(tf.size);
				Marshal.StructureToPtr(tf, tempptr, false);
				SendMessage(toolwindow, TTM_DELTOOL, 0, tempptr);
				Marshal.FreeHGlobal(tempptr);
				parent.Resize -= new EventHandler(Control_Resize);

			}
			else
			{
				tf.parent = parent.Handle;
				tf.rect = parent.ClientRectangle;
				tf.text = value;
				tempptr = Marshal.AllocHGlobal(tf.size);
				Marshal.StructureToPtr(tf, tempptr, false);
				
				if(tooltexts.Contains(parent))
				{
					tooltexts[parent] = value;
					SendMessage(toolwindow, TTM_UPDATETIPTEXT, 0, tempptr);
				}
				else
				{
					tooltexts.Add(parent, value);
					SendMessage(toolwindow, TTM_ADDTOOL, 0, tempptr);
					parent.Resize += new EventHandler(Control_Resize);
				}
				
				Marshal.FreeHGlobal(tempptr);

			}
		}


		[DefaultValue(BalloonIcons.None)]
		public BalloonIcons Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value;
				Title = title;
			}
		}
		

		[DefaultValue(200)]
		public int MaximumWidth
		{
			get
			{
				return max;
			}
			set
			{
				// Refuse any strange values, (feel free to modify).
				if(max >= 100 && max <= 2000)
				{
					max = value;
					SendMessage(toolwindow, TTM_SETMAXTIPWIDTH, 0, new IntPtr(max));
				}
			}
		}


		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = value;
				SendMessage(toolwindow, TTM_ACTIVATE, Convert.ToInt32(enabled), new IntPtr(0));
			}
		}


		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
				tempptr = Marshal.StringToHGlobalUni(title);
				SendMessage(toolwindow, TTM_SETTITLE, (int) icon, tempptr);
				Marshal.FreeHGlobal(tempptr);
			}
		}


		// This property is by seconds.
		[DefaultValue(5)]
		public int AutoPop
		{
			get
			{
				return autopop / 1000;
			}
			set
			{
				// Refuse any strange values, (feel free to modify).
				if(value >= 1 && value < 120)
				{
					autopop = value * 1000;
					SendMessage(toolwindow, TTM_SETDELAYTIME, TTDT_AUTOPOP, new IntPtr(autopop));
				}
			}
		}


		// This property is by milliseconds ( 1 second = 1000 millisecond ).
		[DefaultValue(500)]
		public int Initial
		{
			get
			{
				return initial ;
			}
			set
			{
				// Refuse any strange values, (feel free to modify).
				if(value >= 100 && value <= 2000)
				{
					initial = value ;
					SendMessage(toolwindow, TTM_SETDELAYTIME, TTDT_INITIAL, new IntPtr(initial));
				}
			}
		}


		public Color BackColor
		{
			get
			{
				return bgcolor;
			}
			set
			{
				bgcolor = value;
				SendMessage(toolwindow, TTM_SETTIPBKCOLOR, System.Drawing.ColorTranslator.ToWin32(value), new IntPtr(0));
			}
		}
		

        public Color ForeColor
		{
			get
			{
				return fgcolor;
			}
			set
			{
				fgcolor = value;
				SendMessage(toolwindow, TTM_SETTIPTEXTCOLOR, System.Drawing.ColorTranslator.ToWin32(value), new IntPtr(0));
			}
		}


        /// <summary>
        /// Overriding Dispose is a must to free our window handle we created at the constructor.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				tooltexts.Clear();
				tooltexts = null;
			}
			DestroyWindow(toolwindow);		// Free the window handle obtained by CreateWindowEx.
			base.Dispose (disposing);

		}


		private void Control_Resize(object sender, EventArgs e)
		{
			tf.parent =((Control)sender).Handle;

			tempptr = Marshal.AllocHGlobal(tf.size);
			Marshal.StructureToPtr(tf, tempptr, false);

			SendMessage(toolwindow, TTM_GETTOOLINFO, 0, tempptr);

			tf = (toolinfo) Marshal.PtrToStructure(tempptr, typeof(toolinfo));
			tf.rect = ((Control)sender).ClientRectangle;

			Marshal.StructureToPtr(tf, tempptr, false);

			SendMessage(toolwindow, TTM_SETTOOLINFO, 0, tempptr);
            
			Marshal.FreeHGlobal(tempptr);
        }


        #region hack

        private const int TTS_CLOSE = 0x80;
        private const int TTF_IDISHWND = 0x0001;
        private const int TTF_CENTERTIP = 0x0002;
        private const int TTF_RTLREADING = 0x0004;
        private const int TTF_TRACK = 0x0020;
        private const int TTF_ABSOLUTE = 0x0080;
        private const int TTF_PARSELINKS = 0x1000;
        private const int TTF_DI_SETITEM = 0x8000;
        private const int TTM_TRACKACTIVATE = 0x0400 + 17;
        private const int TTM_TRACKPOSITION = 0x0400 + 18;
        private const int TTM_POPUP = 0x0400 + 34;
        private const int TTM_SETWINDOWTHEME = 0x2000 + 0xb;


        private static short LOWORD(int dw)
        {
            short loWord = 0;
            ushort andResult = (ushort)(dw & 0x00007FFF);
            ushort mask = 0x8000;
            if ((dw & 0x8000) != 0)
            {
                loWord = (short)(mask | andResult);
            }
            else
            {
                loWord = (short)andResult;
            }
            return loWord;
        } 
        
        private static int MAKELONG(int wLow, int wHigh)
        {
            int low = (int)LOWORD(wLow);
            short high = LOWORD(wHigh);
            int product = 0x00010000 * (int)high;
            int makeLong = (int)(low | product);
            return makeLong;
        }


        /// <summary>
        /// show the balloon tooltip,
        /// to make it visible without the user have to hover over the control
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="location">The location.</param>
        public void Show(Control sender, Point location)
        {
            tf.parent = ((Control)sender).Handle;

            tempptr = Marshal.AllocHGlobal(tf.size);
            Marshal.StructureToPtr(tf, tempptr, false);

            SendMessage(toolwindow, TTM_GETTOOLINFO, 0, tempptr);
            tf = (toolinfo)Marshal.PtrToStructure(tempptr, typeof(toolinfo));

            tf.flag = TTF_IDISHWND | TTF_ABSOLUTE | TTF_TRACK;
            //tf.size = Marshal.SizeOf(typeof(toolinfo));
            //tf.text="test";
            Marshal.StructureToPtr(tf, tempptr, false);
            SendMessage(toolwindow, TTM_SETTOOLINFO, 0, tempptr);

            SendMessage(toolwindow, TTM_TRACKPOSITION, 0, (IntPtr)MAKELONG(location.X, location.Y));
            SendMessage(toolwindow, TTM_TRACKACTIVATE, 1, tempptr);
            Marshal.FreeHGlobal(tempptr);


        }


        /// <summary>
        /// Hides the balloon tooltip
        /// </summary>
        /// <param name="sender">The sender.</param>
        public void Hide(Control sender)
        {
            tf.parent = ((Control)sender).Handle;

            tempptr = Marshal.AllocHGlobal(tf.size);
            Marshal.StructureToPtr(tf, tempptr, false);

            SendMessage(toolwindow, TTM_GETTOOLINFO, 0, tempptr);
            tf = (toolinfo)Marshal.PtrToStructure(tempptr, typeof(toolinfo));

            tf.flag = TTF_IDISHWND | TTF_ABSOLUTE | TTF_TRACK;
            //tf.size = Marshal.SizeOf(typeof(toolinfo));
            Marshal.StructureToPtr(tf, tempptr, false);
            SendMessage(toolwindow, TTM_SETTOOLINFO, 0, tempptr);

            SendMessage(toolwindow, TTM_TRACKPOSITION, 0, IntPtr.Zero);
            SendMessage(toolwindow, TTM_TRACKACTIVATE, 0, tempptr);
            Marshal.FreeHGlobal(tempptr);

        }

        #endregion
    }

}
