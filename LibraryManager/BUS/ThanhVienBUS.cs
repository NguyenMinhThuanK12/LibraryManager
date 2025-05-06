using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAO;
using LibraryManager.DTO;



namespace LibraryManager.BUS
{
    public class ThanhVienBUS
    {
        private ThanhVienDAO thanhVienDAO;

        public ThanhVienBUS()
        {
            thanhVienDAO  = new ThanhVienDAO();

        }
        public List<ThanhVienDTO> GetAllThanhVien()
        {
            return thanhVienDAO.GetAllThanhVien();
        }
        public void UpdateThanhVien(ThanhVienDTO tv)
        {
            thanhVienDAO.UpdateThanhVien(tv);
        }
        public void DeleteThanhVien(int maThanhVien)
        {
            thanhVienDAO.DeleteThanhVien(maThanhVien);
        }

        public void DeleteNhieuThanhVien(List<int> danhSachMaThanhVien)
        {
            if (danhSachMaThanhVien == null || danhSachMaThanhVien.Count == 0)
                return;

            thanhVienDAO.DeleteNhieuThanhVien(danhSachMaThanhVien);
        }

        public List<ThanhVienDTO> SearchThanhVienByName(string keyword)
        {
            return thanhVienDAO.SearchThanhVienByName(keyword);
        }
        public void ThemThanhVien(ThanhVienDTO thanhVien)
        {
            thanhVienDAO.ThemThanhVien(thanhVien);
        }






    }
}
