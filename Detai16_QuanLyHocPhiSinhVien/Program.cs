/*
Nhom 21, chu de 16:
Thanh vien nhom :
	Le Minh Kha - mssv 21110890
	Tran Quy Thuong - mssv 21110672
	Nguyen Dieu Huong - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
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

		public static void XoaSinhVienKhoiDanhSach_2(ref List<IYeuCau> DS_SinhVien)
		{
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Khong co sinh vien nao trong danh sach!");
				return;
			}

			Console.WriteLine("Ban muon xoa sinh vien theo lua chon nao : ");
			Console.WriteLine("1. Xoa sinh vien theo ten");
			Console.WriteLine("2. Xoa sinh vien theo ma so sinh vien");
			Console.WriteLine("3. Xoa sinh vien theo so can cuoc cong dan");
			Console.WriteLine("4. Xoa sinh vien theo so thu tu trong danh sach (stt bat dau tu 1)");

			string luaChon;

			while (true)
			{
				Console.Write("Lua chon : ");
				luaChon = Console.ReadLine();

				if (luaChon == "1")
				{
					Console.Write("Moi ban nhap ten cua sinh vien muon xoa : ");
					string ten = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].Ten == ten)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}

					Console.WriteLine($"Da xoa {dem} sinh vien co ten {ten}");
				}
				else if (luaChon == "2")
				{
					Console.Write("Moi ban nhap ma so sinh vien cua sinh vien muon xoa : ");
					string mssv = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].MaSoSinhVien == mssv)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}

					Console.WriteLine($"Da xoa {dem} sinh vien co ma so sinh vien {mssv}");
				}
				else if(luaChon == "3")
				{
					Console.Write("Moi ban nhap so can cuoc cong dan cua sinh vien muon xoa : ");
					string cccd = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].SoCanCuocCongDan == cccd)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}

					Console.WriteLine($"Da xoa {dem} sinh vien co so can cuoc cong dan {cccd}");
				}
				else if (luaChon == "4")
				{
					int index;

					while (true)
					{
						Console.WriteLine("Moi ban nhap vao stt cua sinh vien muon xoa trong danh sach : ");
						index = XuLiDauvao.laySoNguyenKhongAm();

						if (index == 0 || index > DS_SinhVien.Count)
						{
							Console.WriteLine($"Stt phai nam trong khoang (1 -> {DS_SinhVien.Count})!");
						}
						else
						{
							break;
						}
					}

					DS_SinhVien.RemoveAt(index - 1);
					Console.WriteLine($"Da xoa sinh vien co stt {index} khoi danh sach!");
				}
				else
				{
					Console.WriteLine("Nhap sai, vui long nhap lai!");
					continue;
				}
				break;
			}

		}

		public static void ChinhSuaThongTinSinhVien_3(ref List<IYeuCau> DS_SinhVien)
		{
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Khong co sinh vien vao trong danh sach!");
				Console.Write("Nhan nut bat ki de ve MENU chinh : ");
				Console.ReadKey();
				return;
			}
			int index;
		
			while (true)
			{
				Console.WriteLine("Moi ban nhap vao stt cua sinh vien muon chinh sua thong tin trong danh sach : ");
				index = XuLiDauvao.laySoNguyenKhongAm();

				if (index == 0 || index > DS_SinhVien.Count)
				{
					Console.WriteLine($"Stt phai nam trong khoang (1 -> {DS_SinhVien.Count})!");
				}
				else
				{
					break;
				}
			}

			bool laSinhVienTrungCap = true;
			if (DS_SinhVien[index- 1] is SinhVienTrungCap) 
			{
				Console.WriteLine("Chinh sua thong tin cho sinh vien trung cap : ");
			}
			else
			{
				Console.WriteLine("Chinh sua thong tin cho sinh vien cao dang : ");
				laSinhVienTrungCap = false;
			}

			Console.WriteLine("\t1. Ten");
			Console.WriteLine("\t2. Ngay sinh");
			Console.WriteLine("\t3. Gioi tinh");
			Console.WriteLine("\t4. Quoc tich");
			Console.WriteLine("\t5. Que quan");
			Console.WriteLine("\t6. Dia chi thuong tru");
			Console.WriteLine("\t7. So can cuoc cong dan");
			Console.WriteLine("\t8. Ma so sinh vien");
			Console.WriteLine("\t9. Khoa hoc");
			Console.WriteLine("\t10. Tien bao hiem");
			Console.WriteLine("\t11. Phu thu");
			// Tuy chinh menu cho 2 loai sinh vien
			if (laSinhVienTrungCap == true)
			{
				Console.WriteLine("\t12. Hoc phi hoc ki");

			}
			else
			{
				Console.WriteLine("\t12. So tin chi mon li thuyet");
				Console.WriteLine("\t13. Don gia mon li thuyet");
				Console.WriteLine("\t14. So tin chi thuc hanh");
				Console.WriteLine("\t15. Don gia mon thuc hanh");
			}

			//Thuc hien chinh sua
			int luaChon;
			while (true)
			{
				Console.Write("\n\tMoi chon => ");
				luaChon = XuLiDauvao.laySoNguyenKhongAm();

				if (laSinhVienTrungCap == true)
				{
					if (luaChon == 0 || luaChon > 12)
					{
						Console.WriteLine("\tLua chon phai nam trong khoang (1->12) !");
						continue;
					}
					else
					{
						break;
					}
				}
				// La sinh vien cao dang
				else
				{
					if (luaChon == 0 || luaChon > 15)
					{
						Console.WriteLine("\tLua chon phai nam trong khoang (1->15) ! ");
						continue;
					}
					else
					{
						break;
					}
				}
			}

			// ca hai th deu co the lua chon 12
			if (luaChon == 12)
			{
				if (laSinhVienTrungCap == true)
				{
					SinhVienTrungCap sinhVien = (SinhVienTrungCap)DS_SinhVien[index - 1];
					Console.Write("Hoc phi hoc ki moi : ");
					sinhVien.HocPhiHocKi = XuLiDauvao.LaySoThucKhongAm();
				}
				else
				{
					SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];
					Console.WriteLine();
					Console.Write("So tin chi ly thuyet moi : ");
					sinhVien.SoTinChilyThuyet = XuLiDauvao.laySoNguyenKhongAm();
				}
				Console.WriteLine("Da thay doi thong tin sinh vien!");
				return;
			}

			// Danh cho rieng sinh vien cao dang
			if (luaChon > 12)
			{
				SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];

				if (luaChon == 13)
				{
					Console.WriteLine("Don gia mon ly thuyet moi : ");
					sinhVien.DonGiaMonLyThuyet = XuLiDauvao.LaySoThucKhongAm();
				}
				else if (luaChon == 14)
				{
					Console.WriteLine("So tin chi thuc hanh moi : ");
					sinhVien.SoTinChiMonThucHanh = XuLiDauvao.laySoNguyenKhongAm();
				}
				else if (luaChon == 15)
				{
					Console.WriteLine("Don gia mon ly thuyet moi : ");
					sinhVien.DonGiaMonThucHanh = XuLiDauvao.LaySoThucKhongAm();
				}

				Console.WriteLine("Da thay doi thong tin sinh vien!");
				return;
			}

			//Co the gop ca 2 lai su li cac truong hop chon tu 1-11
			SinhVien sv = (SinhVien)DS_SinhVien[index-1];

			if (luaChon == 1)
			{
				Console.Write("Nhap ten moi: ");
				sv.Ten = Console.ReadLine();
			}
			else if (luaChon == 2)
			{
				Console.Write("Nhap ngay sinh moi(dd/MM/yyyy): ");
				sv.NgaySinh = XuLiDauvao.layNgayHopLe();
			}
			else if (luaChon == 3)
			{
				Console.Write("Nhap gioi tinh moi : ");
				sv.GioiTinh = Console.ReadLine();

			}
			else if (luaChon == 4)
			{
				Console.Write("Nhap quoc tich moi: ");
				sv.QuocTich = Console.ReadLine();

			}
			else if (luaChon == 5)
			{
				Console.WriteLine("Nhap vao que quan moi: ");
				sv.QueQuan.ThayDoiDiaChi();

			}
			else if (luaChon == 6)
			{
				Console.WriteLine("Nhap dia chi thuong tru moi: ");
				sv.DiaChiThuongTru.ThayDoiDiaChi();
			}
			else if (luaChon == 7)
			{
				Console.Write("Nhap so can cuoc cong dan moi: ");
				sv.SoCanCuocCongDan = Console.ReadLine();
			}
			else if (luaChon == 8)
			{
				Console.Write("Nhap ma so sinh vien moi: ");
				sv.MaSoSinhVien = Console.ReadLine();
			}
			else if (luaChon == 9)
			{
				Console.WriteLine("Nhap thong tin khoa hoc moi: ");
				sv.KhoaHoc.ThayDoiKhoaHoc();
			}
			else if (luaChon == 10)
			{
				Console.Write("Nhap tien bao hiem moi: ");
				sv.TienBaoHiem = XuLiDauvao.LaySoThucKhongAm();
			}
			else if (luaChon == 11)
			{
				Console.Write("Nhap phu thu moi: ");
				sv.PhuThu = XuLiDauvao.LaySoThucKhongAm();
			}
			Console.WriteLine("Da thay doi thong tin sinh vien!");
		}

		public static void SapXepDanhSachSinhVien_4()
		{
			//chua code
		}

		public static void XuatDanhSachSV_5(ref List<IYeuCau> DS_SinhVien)
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

		public static void TimKiem_6(List<IYeuCau> DS_SinhVien)
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

		public static void SoLuongCacDoiTuong_7()
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
				Console.WriteLine("\t2. Xoa sinh vien khoi danh sach");
				Console.WriteLine("\t3. Chinh sua thong tin sinh vien");
				Console.WriteLine("\t4. Sap xep danh sach sinh vien");
				Console.WriteLine("\t5. In danh sach sinh vien");
				Console.WriteLine("\t6. Tim kiem");
				Console.WriteLine("\t7. So luong cac doi tuong ");
				Console.WriteLine("\t8. Dung chuong trinh");
				Console.WriteLine("So luong sinh vien trong danh sach: " + DS_SinhVien.Count);

				Console.Write("\nNhap lua chon: "); luaChon = Console.ReadLine();

				if (luaChon == "1")
					ThemSinhVien_1(ref DS_SinhVien);
				else if (luaChon == "2")	
				{
					XoaSinhVienKhoiDanhSach_2(ref DS_SinhVien);
				}
				else if (luaChon == "3")
				{
					ChinhSuaThongTinSinhVien_3(ref DS_SinhVien);
				}
				else if (luaChon == "4")
				{
					Console.WriteLine("Chua code chuc nang nay:>>>");
				}
				else if (luaChon == "5")
					XuatDanhSachSV_5(ref DS_SinhVien);
				else if (luaChon == "6")
					TimKiem_6(DS_SinhVien);
				else if (luaChon == "7")
					SoLuongCacDoiTuong_7();
				else if (luaChon == "8")
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