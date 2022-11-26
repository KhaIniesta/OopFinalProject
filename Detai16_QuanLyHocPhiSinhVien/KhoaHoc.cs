/*
Nhom 21, chu de 16:
Thanh vien nhom :
	Le Minh Kha - mssv 21110890
	Tran Quy Thuong - mssv 21110672
	Nguyen Dieu Huong - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detai16_QuanLyHocPhiSinhVien
{
	class KhoaHoc
	{
		//Fields:
		public static int demKhoaHoc = 0;
		private string tenNienKhoa;
		private int namBatDau;
		private int namKetThuc;

		//Properties:
		public string TenNienKhoa { get => tenNienKhoa; set => tenNienKhoa = value; }
		public int NamBatDau { get => namBatDau; set => namBatDau = value; }
		public int NamKetThuc { get => namKetThuc; set => namKetThuc = value; }

		//Constructor:
		public KhoaHoc(string tenNienKhoa, int namBatDau, int namKetThuc)
		{
			demKhoaHoc++;
			this.tenNienKhoa = tenNienKhoa;
			this.namBatDau = namBatDau;
			this.namKetThuc = namKetThuc;
		}

		//Method:
		public string toString()
		{
			return "\tTen nien hoc:".PadRight(15) + tenNienKhoa + "\n\tNam bat dau:".PadRight(15) + namBatDau + "\n\tNam ket thuc:".PadRight(15) + namKetThuc; 
		}
	}
}
