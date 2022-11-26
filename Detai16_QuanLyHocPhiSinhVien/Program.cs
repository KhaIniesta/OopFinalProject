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
			Console.Write("Nhập số lượng sinh viên cần thêm: "); soLuongSVthemvao = XuLiDauvao.laySoNguyenKhongAm();
			while (soLuongSVthemvao != 0)
			{

				IYeuCau SinhVien_Tam;
				string loaiSinhVien;
				Console.WriteLine("---");
				Console.Write("Chọn loại sinh viên(1.Sinh viên trung cấp, 2.Sinh viên cao đẳng): "); loaiSinhVien = Console.ReadLine();
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
					Console.Write("Chọn không hợp lệ, vui lòng chọn lại!");
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
				Console.WriteLine("Không có sinh viên nào trong danh sách!");
				return;
			}

			Console.WriteLine("Bạn muốn xoá sinh viên theo lựa chọn nào: ");
			Console.WriteLine("1. Xoá sinh viên theo tên");
			Console.WriteLine("2. Xoá sinh viên theo mã số sinh viên");
			Console.WriteLine("3. Xoá sinh viên theo số căn cước công dân");
			Console.WriteLine("4. Xoá sinh viên theo số thứ tự trong danh sách (stt bắt đầu từ 1)");

			string luaChon;

			while (true)
			{
				Console.Write("Lựa chọn : ");
				luaChon = Console.ReadLine();

				if (luaChon == "1")
				{
					Console.Write("Nhập tên của sinh viên muốn xoá: ");
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

					Console.WriteLine($"Đã xóa {dem} sinh viên có tên {ten}");
					Console.ReadKey();
				}
				else if (luaChon == "2")
				{
					Console.Write("Nhập mã số sinh viên của sinh viên muốn xoá: ");
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

					Console.WriteLine($"Đã xóa {dem} sinh viên có mã số sinh viên {mssv}");
					Console.ReadKey();
				}
				else if(luaChon == "3")
				{
					Console.Write("Nhập số căn cước công dân của sinh viên muốn xoá: ");
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

					Console.WriteLine($"Đã xoá {dem} sinh viên có số căn cước công dân {cccd}");
					Console.ReadKey();
				}
				else if (luaChon == "4")
				{
					int index;

					while (true)
					{
						Console.WriteLine("Nhập vào STT của sinh viên muốn xoá trong danh sách: ");
						index = XuLiDauvao.laySoNguyenKhongAm();

						if (index == 0 || index > DS_SinhVien.Count)
						{
							Console.WriteLine($"STT phải nằm trong khoảng (1 -> {DS_SinhVien.Count})!");
						}
						else
						{
							break;
						}
					}

					DS_SinhVien.RemoveAt(index - 1);
					Console.WriteLine($"Đã xóa sinh viên có STT {index} khỏi danh sách!");
					Console.ReadKey();
				}
				else
				{
					Console.WriteLine("Nhập sai, vui lòng nhập lại!");
					continue;
				}
				break;
			}

		}

		public static void ChinhSuaThongTinSinhVien_3(ref List<IYeuCau> DS_SinhVien)
		{
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Không có sinh viên nào trong danh sách!");
				Console.Write("Nhấn nút bất kì để về MENU chính: ");
				Console.ReadKey();
				return;
			}
			int index;
		
			while (true)
			{
				Console.WriteLine("Nhập vào STT của sinh viên muốn chỉnh sửa thông tin trong danh sách : ");
				index = XuLiDauvao.laySoNguyenKhongAm();

				if (index == 0 || index > DS_SinhVien.Count)
				{
					Console.WriteLine($"STT phải nằm trong khoảng (1 -> {DS_SinhVien.Count})!");
				}
				else
				{
					break;
				}
			}

			bool laSinhVienTrungCap = true;
			if (DS_SinhVien[index- 1] is SinhVienTrungCap) 
			{
				Console.WriteLine("Chỉnh sửa thông tin cho sinh viên trung cấp: ");
			}
			else
			{
				Console.WriteLine("Chỉnh sửa thông tin cho sinh vien cao đẳng: ");
				laSinhVienTrungCap = false;
			}

			Console.WriteLine("\t1. Tên");
			Console.WriteLine("\t2. Ngày sinh");
			Console.WriteLine("\t3. Giới tính");
			Console.WriteLine("\t4. Quốc tịch");
			Console.WriteLine("\t5. Quê quán");
			Console.WriteLine("\t6. Địa chỉ thường trú");
			Console.WriteLine("\t7. Số căn cước công dân");
			Console.WriteLine("\t8. Mã số sinh viên");
			Console.WriteLine("\t9. Khoá học");
			Console.WriteLine("\t10. Tiền bảo hiểm");
			Console.WriteLine("\t11. Phụ thu");
			// Tuy chinh menu cho 2 loai sinh vien
			if (laSinhVienTrungCap == true)
			{
				Console.WriteLine("\t12. Học phí học kì");

			}
			else
			{
				Console.WriteLine("\t12. Số tín chỉ môn lý thuyết");
				Console.WriteLine("\t13. Đơn giá môn lý thuyet");
				Console.WriteLine("\t14. Số tín chỉ thực hành");
				Console.WriteLine("\t15. Đơn giá môn thực hành");
			}

			//Thuc hien chinh sua
			int luaChon;
			while (true)
			{
				Console.Write("\n\tMời chọn => ");
				luaChon = XuLiDauvao.laySoNguyenKhongAm();

				if (laSinhVienTrungCap == true)
				{
					if (luaChon == 0 || luaChon > 12)
					{
						Console.WriteLine("\tLựa chọn phải nằm trong khoảng (1->12) !");
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
						Console.WriteLine("\tLựa chọn phải nằm trong khoảng (1->15) ! ");
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
					Console.Write("Học phí học kì mới: ");
					sinhVien.HocPhiHocKi = XuLiDauvao.LaySoThucKhongAm();
				}
				else
				{
					SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];
					Console.WriteLine();
					Console.Write("Số tín chỉ lý thuyết mới: ");
					sinhVien.SoTinChilyThuyet = XuLiDauvao.laySoNguyenKhongAm();
				}
				Console.WriteLine("Đã thay đổi thông tin sinh viên!");
				return;
			}

			// Danh cho rieng sinh vien cao dang
			if (luaChon > 12)
			{
				SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];

				if (luaChon == 13)
				{
					Console.WriteLine("Đơn giá môn lý thuyết mới : ");
					sinhVien.DonGiaMonLyThuyet = XuLiDauvao.LaySoThucKhongAm();
				}
				else if (luaChon == 14)
				{
					Console.WriteLine("Số tín chỉ thực hành mới : ");
					sinhVien.SoTinChiMonThucHanh = XuLiDauvao.laySoNguyenKhongAm();
				}
				else if (luaChon == 15)
				{
					Console.WriteLine("Đơn giá môn lý thuyết mới: ");
					sinhVien.DonGiaMonThucHanh = XuLiDauvao.LaySoThucKhongAm();
				}

				Console.WriteLine("Đã thay đổi thông tin sinh viên!");
				return;
			}

			//Co the gop ca 2 lai su li cac truong hop chon tu 1-11
			SinhVien sv = (SinhVien)DS_SinhVien[index-1];

			if (luaChon == 1)
			{
				Console.Write("Nhập tên mới: ");
				sv.Ten = Console.ReadLine();
			}
			else if (luaChon == 2)
			{
				Console.Write("Nhập ngày sinh mới(dd/MM/yyyy): ");
				sv.NgaySinh = XuLiDauvao.layNgayHopLe();
			}
			else if (luaChon == 3)
			{
				Console.Write("Nhập giới tính mới : ");
				sv.GioiTinh = Console.ReadLine();

			}
			else if (luaChon == 4)
			{
				Console.Write("Nhập quốc tịch mới: ");
				sv.QuocTich = Console.ReadLine();

			}
			else if (luaChon == 5)
			{
				Console.WriteLine("Nhập vào quê quán mới: ");
				sv.QueQuan.ThayDoiDiaChi();

			}
			else if (luaChon == 6)
			{
				Console.WriteLine("Nhập địa chỉ thường trú mới: ");
				sv.DiaChiThuongTru.ThayDoiDiaChi();
			}
			else if (luaChon == 7)
			{
				Console.Write("Nhập số căn cước công dân mới: ");
				sv.SoCanCuocCongDan = Console.ReadLine();
			}
			else if (luaChon == 8)
			{
				Console.Write("Nhập mã số sinh viên mới: ");
				sv.MaSoSinhVien = Console.ReadLine();
			}
			else if (luaChon == 9)
			{
				Console.WriteLine("Nhập thông tin khóa học mới: ");
				sv.KhoaHoc.ThayDoiKhoaHoc();
			}
			else if (luaChon == 10)
			{
				Console.Write("Nhập tiền bảo hiểm mới: ");
				sv.TienBaoHiem = XuLiDauvao.LaySoThucKhongAm();
			}
			else if (luaChon == 11)
			{
				Console.Write("Nhập phụ thu mới: ");
				sv.PhuThu = XuLiDauvao.LaySoThucKhongAm();
			}
			Console.WriteLine("Đã thay đổi thông tin sinh viên!");
		}

		public static void SapXepDanhSachSinhVien_4()
		{
			//chua code
		}

		public static void XuatDanhSachSV_5(ref List<IYeuCau> DS_SinhVien)
		{
			string First_Line = "|Họ và tên".PadRight(20) + "|Giới tính".PadRight(11) + "|Ngày sinh".PadRight(12) + "|MSSV".PadRight(10)
				+ "|Niên khoá".PadRight(10) + "|Quê quán(tỉnh)".PadRight(20) + "|Tổng học phí".PadRight(15) + "|";
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
			Console.Write("An một nút bất kì để tiếp tục! ");
			Console.ReadKey();
		}

		public static void TimKiem_6(List<IYeuCau> DS_SinhVien)
		{
			Console.Clear();
			Console.WriteLine("Chon điều kiện muốn tìm kiếm: ");
			Console.WriteLine("\t1. Tìm kiếm theo tên");
			Console.WriteLine("\t2. Tìm kiếm theo mã số sinh viên");
			Console.WriteLine("\t3. Tìm kiếm theo quê quán");
			Console.WriteLine("\t4. Tìm kiếm theo số căn cước công dân");

			while (true)
			{
				Console.Write("Chọn: ");
				string input = Console.ReadLine();
				if (input == "1")
				{
					Console.Write("Nhập tên cần tìm: ");
					input = Console.ReadLine();
					// xu ly string
					input = XuLiDauvao.chuyenTiengVietKhongDau(input);
					input = input.Trim();
					input = input.ToLower();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (XuLiDauvao.chuyenTiengVietKhongDau(SV.Ten).ToLower().Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "2")
				{
					Console.Write("Nhap MSSV cần tìm: ");
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
					Console.Write("Nhập quê quán: ");
					input = Console.ReadLine();
					input = XuLiDauvao.chuyenTiengVietKhongDau(input);
					input = input.Trim();
					input = input.ToLower();
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (XuLiDauvao.chuyenTiengVietKhongDau(SV.QueQuan.toString()).ToLower().Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "4")
				{
					Console.Write("Nhập số căn cước công dân cần tìm: ");
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
					Console.WriteLine("Chọn không hợp lệ!");
					continue;
				}
			}
			Console.Write("Tìm kiếm hoàn tất, vui lòng nhấn phím bất kì để về MENU chính! ");
			Console.ReadKey();
		}

		public static void SoLuongCacDoiTuong_7()
		{
			Console.WriteLine("Đếm số lượng các đối tượng cùng loại:\n");
			Console.WriteLine($"Địa Chỉ: {DiaChi.DemDiaChi}");
			Console.WriteLine($"Người: {Nguoi.demNguoi}");
			Console.WriteLine($"Khóa học: {KhoaHoc.demKhoaHoc}");
			Console.WriteLine($"Sinh viên: {SinhVien.demSinhVien}");
			Console.WriteLine($"Sinh viên trung cấp: {SinhVienTrungCap.demSinhVienTrungCap}");
			Console.WriteLine($"Sinh viên cao đẳng: {SinhVienCaoDang.demSinhVienCaoDang}");
			Console.Write("Nhấn nút bất kì để về MENU chính! ");
			Console.ReadKey();
		}


		static void Main(string[] args)
		{
			//This is the test comment
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			Console.InputEncoding = System.Text.Encoding.Unicode;
			List<IYeuCau> DS_SinhVien = new List<IYeuCau>();
			string luaChon;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("\tCHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN CỦA TRƯỜNG ĐẠI HỌC");

				Console.WriteLine("\n\t\t1. Thêm sinh viên vào danh sách");
				Console.WriteLine("\t\t2. Xóa sinh viên khỏi danh sách");
				Console.WriteLine("\t\t3. Chỉnh sửa thông tin sinh viên");
				Console.WriteLine("\t\t4. Sắp xếp danh sách sinh viên");
				Console.WriteLine("\t\t5. In danh sách sinh viên");
				Console.WriteLine("\t\t6. Tìm kiếm sinh viên");
				Console.WriteLine("\t\t7. Số lượng các đối tượng");
				Console.WriteLine("\t\t8. Dừng chương trình");
				Console.WriteLine("\nSố lượng sinh viên trong danh sách: " + DS_SinhVien.Count);

				Console.Write("\nNhập lựa chọn: "); luaChon = Console.ReadLine();

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