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
	class SinhVienTrungCap : SinhVien, IYeuCau
	{
		//fields:
		public static int demSinhVienTrungCap = 0;
		private double hocPhiHocKi;

		//Properties:
		public double HocPhiHocKi { get => hocPhiHocKi; set => hocPhiHocKi = value; }

		//Constructor:
		public SinhVienTrungCap() : base()
		{
			demSinhVienTrungCap++;
		}
		public SinhVienTrungCap(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu, double hocPhiHocKi)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan, maSoSinhVien, khoaHoc, tienBaoHiem, phuThu)
		{
			demSinhVienTrungCap++;
			this.hocPhiHocKi = hocPhiHocKi;
		}

		//Method:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Nhap hoc phi moi hoc ki: ");
			this.HocPhiHocKi = XuLiDauvao.LaySoThucKhongAm();
		}


		public double tinhTienHocPhi()
		{
			return HocPhiHocKi + TienBaoHiem + PhuThu;
		}

		public override string xuatThongTinDayDu()
		{
			string ans = base.xuatThongTinDayDu() + "\nHoc phi HK:".PadRight(15) + HocPhiHocKi.ToString()
				 + "\nTong hoc phi:".PadRight(15) + tinhTienHocPhi().ToString();
			return ans;
		}
		public override string xuatThongTinNganGon()
		{
			string ans = base.xuatThongTinNganGon() + "\nHoc phi HK:".PadRight(15) + HocPhiHocKi.ToString()
				+ "\nTong hoc phi:".PadRight(15) + tinhTienHocPhi().ToString();
			return ans;
		}
	}
}
