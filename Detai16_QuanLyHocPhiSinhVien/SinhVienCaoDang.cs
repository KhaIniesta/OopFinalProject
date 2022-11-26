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
	class SinhVienCaoDang : SinhVien, IYeuCau
	{
		//field:
		public static int demSinhVienCaoDang = 0;
		private int soTinChilyThuyet;
		private double donGiaMonLyThuyet;
		private int soTinChiMonThucHanh;
		private double donGiaMonThucHanh;

		//Properties:
		public int SoTinChilyThuyet { get => soTinChilyThuyet; set => soTinChilyThuyet = value; }
		public double DonGiaMonLyThuyet { get => donGiaMonLyThuyet; set => donGiaMonLyThuyet = value; }
		public int SoTinChiMonThucHanh { get => soTinChiMonThucHanh; set => soTinChiMonThucHanh = value; }
		public double DonGiaMonThucHanh { get => donGiaMonThucHanh; set => donGiaMonThucHanh = value; }

		//Constructor:
		public SinhVienCaoDang() : base()
		{
			
			demSinhVienCaoDang++;
		}
		public SinhVienCaoDang(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu,
			int soTinChilyThuyet, double donGiaMonLyThuyet, int soTinChiMonThucHanh, double donGiaMonThucHanh)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan, maSoSinhVien, khoaHoc, tienBaoHiem, phuThu)
		{
			demSinhVienCaoDang++;
			this.soTinChilyThuyet = soTinChilyThuyet;
			this.donGiaMonLyThuyet = donGiaMonLyThuyet;
			this.soTinChiMonThucHanh = soTinChiMonThucHanh;
			this.donGiaMonThucHanh = donGiaMonThucHanh;
		}

		//Method:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Nhap so tin chi ly thuyet: "); this.soTinChilyThuyet = XuLiDauvao.laySoNguyenKhongAm();
			Console.Write("Nhap don gia mon ly thuyet: "); this.donGiaMonLyThuyet = XuLiDauvao.LaySoThucKhongAm();
			Console.Write("Nhap so tin chi thuc hanh: "); this.soTinChiMonThucHanh = XuLiDauvao.laySoNguyenKhongAm();
			Console.Write("Nhap don gia mon thuc hanh: "); this.donGiaMonThucHanh = XuLiDauvao.LaySoThucKhongAm();

		}

		public double tinhTienHocPhi()
		{
			return SoTinChilyThuyet * DonGiaMonLyThuyet + SoTinChiMonThucHanh * DonGiaMonThucHanh + PhuThu + TienBaoHiem;
		}

		public override string xuatThongTinDayDu()
		{
			string ans = base.xuatThongTinDayDu() + "\nSo TCLT:".PadRight(15) + SoTinChilyThuyet.ToString() + "\nSo TCTH:".PadRight(15) + SoTinChiMonThucHanh
				+ "\nDon gia LT:".PadRight(15) + DonGiaMonLyThuyet.ToString() + "\nDon gia TH:".PadRight(15) + DonGiaMonThucHanh.ToString()
				+ "\nTong hoc phi:".PadRight(15) + tinhTienHocPhi().ToString();
			return ans;
		}

		public override string xuatThongTinNganGon()
		{
			string ans = base.xuatThongTinNganGon() + "\nSo TCLT:".PadRight(15) + SoTinChilyThuyet.ToString()
				+ "\nSo TCTH:".PadRight(15) + SoTinChiMonThucHanh.ToString()
				+ "\nTong hoc phi:".PadRight(15) + tinhTienHocPhi().ToString();
			return ans;
		}
	}
}
