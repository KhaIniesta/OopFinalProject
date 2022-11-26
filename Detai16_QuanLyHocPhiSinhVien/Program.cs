/*
Nhom 21, chu de 16:
Thanh vien nhom :
	Le Minh Kha - mssv 21110890
	Tran Quy Thuong - mssv 21110672
	Nguyen Dieu Huong - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Detai16_QuanLyHocPhiSinhVien
{
	internal class Program
	{
		public static void ThemSinhVien_1(ref List<IYeuCau> DS_SinhVien)
		{
			int soLuongSVthemvao = 0;
			Console.Write("Nhap so luong sinh vien can them: "); soLuongSVthemvao = XuLiDauvao.laySoNguyenKhongAm();
			while (soLuongSVthemvao != 0)
			{

				IYeuCau SinhVien_Tam;
				string loaiSinhVien;
				Console.WriteLine("---");
				Console.Write("Chon loai sinh vien(1.Sinh vien trung cap, 2.Sinh vien cao dang): "); loaiSinhVien = Console.ReadLine();
				loaiSinhVien = loaiSinhVien.Trim();
				if (loaiSinhVien == "1")
				{
					SinhVien_Tam = new SinhVienTrungCap();
					SinhVien_Tam.nhapThongTin();
				}
				else if (loaiSinhVien == "2")
				{
					SinhVien_Tam = new SinhVienCaoDang();
					SinhVien_Tam.nhapThongTin();
				}
				else
				{
					Console.Write("Chon khong hop le, vui long chon lai!");
					Console.ReadKey();
					Console.WriteLine();
					continue;
				}
				DS_SinhVien.Add(SinhVien_Tam);
				soLuongSVthemvao--;
			}
		}
		public static void XuatDanhSachSV_2(ref List<IYeuCau> DS_SinhVien)
		{
			string First_Line = "|Ho va ten".PadRight(20) + "|Gioi tinh".PadRight(11) + "|Ngay sinh".PadRight(12) + "|MSSV".PadRight(10)
				+ "|Nien khoa".PadRight(10) + "|Que quan(tinh)".PadRight(20) + "|Tong hoc phi".PadRight(15) + "|";
			string Second_Line = "+-------------------+----------+-----------+---------+---------+-------------------+--------------+";
			string Record_Line;

			Console.WriteLine();
			Console.WriteLine(First_Line);
			Console.WriteLine(Second_Line);
			foreach (IYeuCau SV in DS_SinhVien)
			{
				Record_Line = "|" + SV.Ten.PadRight(19) + "|" + SV.GioiTinh.PadRight(10) + "|" + SV.NgaySinh.ToString("dd/MM/yyyy").PadRight(11) + "|" + SV.MaSoSinhVien.PadRight(9)
					+ "|" + SV.KhoaHoc.TenNienKhoa.PadRight(9) + "|" + SV.QueQuan.Tinh.PadRight(19) + "|" + SV.tinhTienHocPhi().ToString().PadRight(14) + "|";
				Console.WriteLine(Record_Line);
			}
			Console.Write("An mot nut bat ki de tiep tuc! ");
			Console.ReadKey();
		}
		public static void TimKiem_3(List<IYeuCau> DS_SinhVien)
		{
			Console.Clear();
			Console.WriteLine("Chon dieu kien muon tim kiem: ");
			Console.WriteLine("\t1. Tim kiem theo ten");
			Console.WriteLine("\t2. Tim kiem theo ma so sinh vien");
			Console.WriteLine("\t3. Tim kiem theo que quan");
			Console.WriteLine("\t4. Tim kiem theo so can cuoc cong dan");

			while (true)
			{
				Console.Write("Chon: ");
				string input = Console.ReadLine();
				if (input == "1")
				{
					Console.Write("Nhap ten can tim: ");
					input = Console.ReadLine();
					input = input.Trim();
					input = input.ToLower();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.Ten.ToLower().Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "2")
				{
					Console.Write("Nhap MSSV can tim: ");
					input = Console.ReadLine();
					input.Trim();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.MaSoSinhVien.Trim() == input)
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "3")
				{
					Console.Write("Nhap que quan: ");
					input = Console.ReadLine();
					input = input.Trim();
					input = input.ToLower();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.QueQuan.toString().ToLower().Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "4")
				{
					Console.Write("Nhap so cccd can tim: ");
					input = Console.ReadLine();
					input.Trim();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.SoCanCuocCongDan.Trim() == input)
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else
				{
					Console.WriteLine("Chon khong hop le!");
					continue;
				}
			}
			Console.Write("Tim kiem hoan tat, vui long nhan phim bat ki de ve MENU chinh! ");
			Console.ReadKey();
		}

		public static void SoLuongCacDoiTuong()
		{
			Console.WriteLine("Dem so luong cac doi tuong cung loai:\n");
			Console.WriteLine($"Dia chi : {DiaChi.DemDiaChi}");
			Console.WriteLine($"Nguoi : {Nguoi.demNguoi}");
			Console.WriteLine($"Khoa hoc : {KhoaHoc.demKhoaHoc}");
			Console.WriteLine($"Sinh vien : {SinhVien.demSinhVien}");
			Console.WriteLine($"Sinh vien trung cap : {SinhVienTrungCap.demSinhVienTrungCap}");
			Console.WriteLine($"Sinh vien cao dang : {SinhVienCaoDang.demSinhVienCaoDang}");
			Console.Write("Nhan nut bat ki de ve MENU chinh! ");
			Console.ReadKey();
		}
		static void Main(string[] args)
		{
			//This is the test comment
			List<IYeuCau> DS_SinhVien = new List<IYeuCau>();
			string luaChon;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("\t\tCHUONG TRINH QUAN LY SINH VIEN CUA TRUONG DAI HOC");

				Console.WriteLine("\n\t1. Them sinh vien vao danh sach");
				Console.WriteLine("\t2. In danh sach sinh vien");
				Console.WriteLine("\t3. Tim kiem");
				Console.WriteLine("\t4. So luong cac doi tuong");
				Console.WriteLine("\t5. Dung chuong trinh");
				Console.WriteLine("So luong sinh vien trong danh sach: " + DS_SinhVien.Count);

				Console.Write("\nNhap lua chon: "); luaChon = Console.ReadLine();

				if (luaChon == "1")
					ThemSinhVien_1(ref DS_SinhVien);
				else if (luaChon == "2")
					XuatDanhSachSV_2(ref DS_SinhVien);
				else if (luaChon == "3")
					TimKiem_3(DS_SinhVien);
				else if (luaChon == "4")
					SoLuongCacDoiTuong();
				else if (luaChon == "5")
				{
					Console.WriteLine("Da dung chuong trinh.");
					return;
				}
				else
				{
					Console.WriteLine("Vui long chon 1 so trong danh sach!");
					Console.Write("Nhan mot phim bat ki de tiep tuc : ");
					Console.ReadKey();
					continue;
				}
			}
		}
	}
}