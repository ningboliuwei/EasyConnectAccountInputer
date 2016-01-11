using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EasyConnectAccountInputer
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
		private static extern void SetForegroundWindow(IntPtr hwnd);

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			const uint BM_CLICK = 0xF5; //鼠标点击的消息，对于各种消息的数值，大家还是得去API手册

			IntPtr hwndCalc = FindWindow(null, "计算器"); //查找计算器的句柄

			if (hwndCalc != IntPtr.Zero)
			{
				IntPtr hwndThree = FindWindowEx(hwndCalc, 0, null, "3"); //获取按钮3 的句柄

				IntPtr hwndPlus = FindWindowEx(hwndCalc, 0, null, "+");  //获取按钮 + 的句柄
				IntPtr hwndTwo = FindWindowEx(hwndCalc, 0, null, "2");  //获取按钮2 的句柄
				IntPtr hwndEqual = FindWindowEx(hwndCalc, 0, null, "="); //获取按钮= 的句柄
				SetForegroundWindow(hwndCalc);    //将计算器设为当前活动窗口
				System.Threading.Thread.Sleep(2000);   //暂停2秒让你看到效果
				SendMessage(hwndThree, BM_CLICK, 0, 0);
				System.Threading.Thread.Sleep(2000);   //暂停2秒让你看到效果
				SendMessage(hwndPlus, BM_CLICK, 0, 0);
				System.Threading.Thread.Sleep(2000);   //暂停2秒让你看到效果
				SendMessage(hwndTwo, BM_CLICK, 0, 0);
				System.Threading.Thread.Sleep(2000);   //暂停2秒让你看到效果
				SendMessage(hwndEqual, BM_CLICK, 0, 0);

				System.Threading.Thread.Sleep(2000);
				MessageBox.Show("你看到结果了吗？");
			}
			else
			{
				MessageBox.Show("没有启动 [计算器]");
			}
		}
	}
}
