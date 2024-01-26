using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class Form1 : Form
    {
        public static NhanVien nhanvien;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            ResetMenu();
            hideSubMenu();
            btCloseChildForm.Visible = false;
        }
        private void ResetMenu()
        {

        }
        private void hideSubMenu()
        {
            pnlSubMenu.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != null)
                {
                    // Đặt màu của nút trên form cũ về trạng thái mặc định
                    currentButton.BackColor = Color.DimGray;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                Color color = SelectThemeColor();
                currentButton = (Button)btnSender;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                pnlTrangChu.BackColor = color;
                pnlLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                ThemeColor.PrimaryColor = color;
                ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                btCloseChildForm.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlDesktop.Controls.Add(childForm);
            this.pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            if (btnSender is Button selectedButton)
            {
                label1.Text = selectedButton.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenu);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenu2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenu3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SP(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NV(), sender);
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KH(), sender);
        }

        private void btnThongKeSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe(), sender);
        }

        private void btnHoSoNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoiMK(), sender);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DangNhap(), sender);
        }

        private void btCloseChildForm_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có một form con đang mở
            if (activeForm != null)
            {
                activeForm.Close();  // Đóng form con đang mở
                ResetInterface();    // Gọi phương thức để khôi phục giao diện
            }
        }

        private void ResetInterface()
        {
            // Đặt lại màu sắc của nút trên form về trạng thái mặc định
            if (currentButton != null)
            {
                label1.Text = "Trang chủ";
                currentButton.BackColor = Color.DimGray;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            // Đặt lại màu sắc của các panel khác về trạng thái mặc định
            pnlTrangChu.BackColor = Color.CadetBlue;
            pnlLogo.BackColor = Color.Black;

            // Đặt lại biến để chọn lại màu mới khi cần thiết
            tempIndex = -1;
            btCloseChildForm.Visible = false;
        }
    }
}
