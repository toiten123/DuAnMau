using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_ThongKeNhapHang
    {
        public string MaNV {  get; set; }
        public string TenNV { get; set; }
        public int SoLuongHang { get; set; }
    }
    public class DTO_ThongKeTonKho
    {
        public string TenHang { get; set; }
        public int SoLuongTon { get; set; }
    }
}
