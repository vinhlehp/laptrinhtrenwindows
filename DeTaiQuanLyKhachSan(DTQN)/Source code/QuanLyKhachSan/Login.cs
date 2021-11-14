using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class Login : Form
    {
        #region Hàm khởi tạo, các biến và event.
        // Load chương trình
        public bool isExit = true;    
        public Login()
        {
            InitializeComponent();
        }
        #endregion
        #region Đóng form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FormClose();
            }
            else
            {
                return;
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClose();
        }
        void FormClose()
        {
            if (isExit)
            {
                isExit = false;
                Application.Exit();
            }
        }
        #endregion


        #region Đăng Nhập

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=" + QuanLyKhachSan.Container.severName + ";Initial Catalog=QUANLYKHACHSAN;Integrated Security=True");         

            String sqlSelect = "SELECT * FROM DANGNHAP WHERE User_Name ='" + txtuser.Text + "' and Pass_Word ='" + txtpass.Text + "'";

            SqlCommand comd = new SqlCommand(sqlSelect, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read() == true)
            {
                MessageBox.Show("Đăng Nhập Thành Công!");
                Menu frmMenu = new Menu();
                this.Hide();  // ẩn form đăng nhập
                frmMenu.Show();
            }
            else
            {
                MessageBox.Show("Tài Khoản Mật Khẩu Sai!");
            }
            sqlConnection.Close();

        }

        #endregion

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
