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
	abstract class SinhVien : Nguoi
	{
		//Fields:
		public static int demSinhVien = 0;
		private string maSoSinhVien;
		private KhoaHoc khoaHoc;
		private double tienBaoHiem;
		private double phuThu;

		//Properties:
		public string MaSoSinhVien { get => maSoSinhVien; set => maSoSinhVien = value; }
		public double TienBaoHiem { get => tienBaoHiem; set => tienBaoHiem = value; }
		public double PhuThu { get => phuThu; set => phuThu = value; }
		public KhoaHoc KhoaHoc { get => khoaHoc; set => khoaHoc = value; }

		//Constructors:
		public SinhVien() : base()
		{
			demSinhVien++;
			this.maSoSinhVien = "";
			this.khoaHoc = new KhoaHoc("", 0, 0);
			this.tienBaoHiem = 0;
			this.phuThu = 0;
		}

		public SinhVien(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan)
		{
			demSinhVien++;
			this.maSoSinhVien = maSoSinhVien;
			this.khoaHoc = khoaHoc;
			this.tienBaoHiem = tienBaoHiem;
			this.phuThu = phuThu;
		}

		//Methods:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Ma so sinh vien: ");
			this.MaSoSinhVien = Console.ReadLine();
			Console.WriteLine("Nhap Khoa hoc: ");
			Console.Write("\tNhap ten nien khoa: ");
			this.khoaHoc.TenNienKhoa = Console.ReadLine();
			Console.Write("\tNhap nam bat dau khoa hoc: ");
			this.KhoaHoc.NamBatDau = XuLiDauvao.laySoNguyenKhongAm();
			Console.Write("\tNhap nam ket thuc khoa hoc: ");
			this.KhoaHoc.NamKetThuc = XuLiDauvao.laySoNguyenKhongAm();
			Console.Write("Nhap tien bao hiem: ");
			this.TienBaoHiem = XuLiDauvao.LaySoThucKhongAm();
			Console.Write("Nhap tien phu thu: ");
			this.PhuThu = XuLiDauvao.LaySoThucKhongAm();
		}

		public virtual string xuatThongTinNganGon()
		{
			string ans = "Ho va ten:".PadRight(14) + Ten + "\nMSSV:".PadRight(15) + maSoSinhVien
				+ "\nKhoa hoc:".PadRight(15) + KhoaHoc.TenNienKhoa + "\nTien BH:".PadRight(15) + TienBaoHiem.ToString()
				+ "\nPhu thu:".PadRight(15) + phuThu.ToString();
			return ans;
		}

		public virtual string xuatThongTinDayDu()
		{
			string ans = base.toString() + "\nMSSV:".PadRight(15) + maSoSinhVien
				+ "\nKhoa hoc:".PadRight(15) + KhoaHoc.TenNienKhoa + "\nTien BH:".PadRight(15) + TienBaoHiem.ToString()
				+ "\nPhu thu:".PadRight(15) + phuThu.ToString();
			return ans;
		}
	}
}
