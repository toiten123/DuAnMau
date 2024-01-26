using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO_QLBanHang;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_Thongke : DAL_IThongKe
    {
        public List<DTO_ThongKeNhapHang> ThongKeNhapHang()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                var list = (from n in db.NhanViens
                            select new DTO_ThongKeNhapHang
                            {
                                MaNV = n.MaNV,
                                TenNV = n.TenNV,
                                SoLuongHang = n.Hangs.Count
                            }).ToList();
                return list;
            }
        }

        public List<DTO_ThongKeTonKho> ThongKeTonkho()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                var list = (from h in db.Hangs
                            group h by h.TenHang into g
                            select new DTO_ThongKeTonKho
                            {
                                TenHang = g.Key,
                                SoLuongTon = g.Sum(h => h.SoLuong)
                            }).ToList();
                return list;
            }
        }
    }
}
