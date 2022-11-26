/*
Nhom 21, chu de 16:
Thanh vien nhom :
	Le Minh Kha - mssv 21110890
	Tran Quy Thuong - mssv 21110672
	Nguyen Dieu Huong - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Detai16_QuanLyHocPhiSinhVien
{
	// Class nay chua nhung phuong thuc tinh xu li cac input tu nguoi dung nhap khong hop le
	public static class XuLiDauvao
	{
		public static int laySoNguyenKhongAm()
		{
			Console.Write("Nhap vao : ");
			while (true)
			{
				string input = Console.ReadLine();
				int ans;
				try
				{
					ans = Int32.Parse(input);
				}
				catch
				{
					Console.Write("Vui long nhap lai: ");
					continue;
				}
				if (ans >= 0) return ans;
				else Console.Write("Vui long nhap lai : ");
			}
		}

		public static double LaySoThucKhongAm()
		{
			Console.Write("Nhap vao : ");
			while (true)
			{
				string input = Console.ReadLine();
				double ans;
				try
				{
					ans = Double.Parse(input);
				}
				catch
				{
					Console.Write("Vui long nhap lai: ");
					continue;
				}
				if (ans >= 0) return ans;
				else Console.Write("Vui long nhap lai : ");
			}
		}

		public static DateTime layNgayHopLe()
		{
			DateTime myDay;
			while (true)
			{
				string input = Console.ReadLine();
				try
				{
					myDay = DateTime.ParseExact(input, "dd/MM/yyyy", null); 
				}
				catch
				{
					Console.Write("Khong hop le, vui long nhap lai!\n");
					Console.Write("Ngay sinh (dd/MM/yyyy): ");
					continue;
				}
				break;
			}
			return myDay;
		}
	}
}
