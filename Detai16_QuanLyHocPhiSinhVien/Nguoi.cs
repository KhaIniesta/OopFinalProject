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
	abstract class Nguoi
	{
		//Fields:
		public static int demNguoi = 0;
		private string ten;
		private DateTime ngaySinh;
		private string gioiTinh;
		private string quocTich;
		private DiaChi queQuan;
		private DiaChi diaChiThuongTru;
		private string soCanCuocCongDan;

		//Properties:
		public string Ten { get => ten; set => ten = value; }
		public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
		public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
		public string QuocTich { get => quocTich; set => quocTich = value; }
		public string SoCanCuocCongDan { get => soCanCuocCongDan; set => soCanCuocCongDan = value; }
		public DiaChi QueQuan { get => queQuan; set => queQuan = value; }
		public DiaChi DiaChiThuongTru { get => diaChiThuongTru; set => diaChiThuongTru = value; }

		//Constructors:
		public Nguoi(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan)
		{
			demNguoi++;
			this.ten = ten;
			this.ngaySinh = ngaySinh;
			this.gioiTinh = gioiTinh;
			this.quocTich = quocTich;
			this.queQuan = queQuan;
			this.DiaChiThuongTru = diaChiThuongTru;
			this.soCanCuocCongDan = soCanCuocCongDan;
		}

		public Nguoi()
		{
			demNguoi++;
			this.ten = "";
			this.ngaySinh = new DateTime(1,1,1);
			this.gioiTinh = "nam";
			this.quocTich = "Viet Nam";
			this.queQuan = new DiaChi("", "", "");
			this.DiaChiThuongTru = new DiaChi("", "", "");
			this.soCanCuocCongDan = "";
		}


		//Methods:
		public virtual string toString()
		{
			string ans = "Ho va ten:".PadRight(15) + Ten + "\nNgay sinh:".PadRight(15) + NgaySinh.ToString("dd/MM/yyyy")
				+ "\nGioi tinh:".PadRight(15) + GioiTinh + "\nQuoc tich:".PadRight(15) + QuocTich
				+ "\nQue quan".PadRight(15) + queQuan.toString() + "\nDC thuong tru:".PadRight(15) + diaChiThuongTru.toString()
				+ "\nSo CCCD:".PadRight(15) + soCanCuocCongDan;
			return ans;
		}



		public virtual void nhapThongTin()
		{
			Console.Write("Nhap ho va ten: ");
			this.Ten = Console.ReadLine();
			Console.Write("Nhap ngay sinh(dd/MM/yyyy): ");
			this.NgaySinh = XuLiDauvao.layNgayHopLe();
			Console.Write("Nhap gioi tinh : ");
			this.GioiTinh = Console.ReadLine();
			Console.Write("Nhap quoc tich : ");
			this.QuocTich = Console.ReadLine();
			Console.WriteLine("Nhap que quan : ");
			string str1, str2, str3;
			Console.Write("\tTinh/TP: "); str1 = Console.ReadLine();
			Console.Write("\tHuyen/Quan/TP : "); str2 = Console.ReadLine();
			Console.Write("\tXa/Phuong: "); str3 = Console.ReadLine();
			this.QueQuan = new DiaChi(str1, str2, str3);

			Console.WriteLine("Nhap dia chi thuong tru: ");
			Console.Write("\tTinh/TP: "); str1 = Console.ReadLine();
			Console.Write("\tHuyen/Quan/TP : "); str2 = Console.ReadLine();
			Console.Write("\tXa/Phuong: "); str3 = Console.ReadLine();
			this.DiaChiThuongTru = new DiaChi(str1, str2, str3);

			Console.Write("Nhap so can cuoc cong dan : ");
			this.SoCanCuocCongDan = Console.ReadLine();

		}
	}
}
