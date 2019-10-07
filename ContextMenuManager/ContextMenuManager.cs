using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Win32;
using Transitions;


namespace ContextMenuManager
{
    public partial class ContextMenuManager : Form
    {
        RegistryKey key = Registry.ClassesRoot; //tạo biến key chứa path Computer\HKEY_CLASSES_ROOT\
 
        public ContextMenuManager()
        {
            InitializeComponent();
        }
        #region Hàm nạp tất cả key vào listbox khi khởi động
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Biểu thức chính quy chứa kí tự lấy và không lấy
            var regexItem = new Regex(@"^\.");
            var regexNItem = new Regex(@"_");
            #endregion
            if (key.SubKeyCount > 0) {
                foreach (string subKey1 in key.GetSubKeyNames()) {
                    if (regexItem.IsMatch(subKey1) && !regexNItem.IsMatch(subKey1)) {
                        //Thêm vào listbox
                        lbKeys.Items.Add(subKey1);
                    }// Chỉ lấy những đuôi hợp lệ theo regexItem và regexNItem
                }// Duyệt tất cả các tên key trong Computer\HKEY_CLASSES_ROOT\ đưa vào subkey1
            }// Kiểm tra key không rỗng mới làm
             // Cập nhật lại số key hiện tại trong listbox
            lbNum.Text = lbKeys.Items.Count.ToString();
        }
        #endregion

        #region Hàm tìm kiếm trong listbox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.ToLower().Contains('.'))
            {
                string temp = "." + txtSearch.Text;
                for (int num = lbKeys.Items.Count - 1; num >= 0; num--)
                {
                    if (lbKeys.Items[num].ToString().ToLower().Contains(temp.ToLower()))
                    {
                        lbKeys.SetSelected(num, true);
                    }
                }
            }
            else
            {
                for (int num = lbKeys.Items.Count - 1; num >= 0; num--)
                {
                    if (lbKeys.Items[num].ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        lbKeys.SetSelected(num, true);
                    }
                }
            }
        }
        #endregion
        #region Hàm nạp Key theo lựa chọn của RadioButton
        private void rbCheck_CheckedChanged(object sender, EventArgs e)
        {
            #region Biểu thức chính quy chứa kí tự lấy và không lấy
            var regexItem = new Regex(@"^\.");
            var regexNItem = new Regex(@"_");
            #endregion
            if (rbShowall.Checked) { 
                lbKeys.Items.Clear();               
                if (key.SubKeyCount > 0) {
                    foreach (string subKey1 in key.GetSubKeyNames()) {
                        if (regexItem.IsMatch(subKey1) && !regexNItem.IsMatch(subKey1)) {
                            //Thêm vào listbox
                            lbKeys.Items.Add(subKey1);
                        }// Chỉ lấy những đuôi hợp lệ theo regexItem và regexNItem
                    }// Duyệt tất cả các tên key trong Computer\HKEY_CLASSES_ROOT\ đưa vào subkey1
                }// Kiểm tra key không rỗng mới làm
                // Cập nhật lại số key hiện tại trong listbox
                lbNum.Text = lbKeys.Items.Count.ToString();
            }// "Tất cả"
            if (rbActived.Checked) {
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
                btnMod.Enabled = false;
                lbKeys.Items.Clear();
                if (key.SubKeyCount > 0) {
                    foreach (string subKey1 in key.GetSubKeyNames()) {
                        if (regexItem.IsMatch(subKey1) && !regexNItem.IsMatch(subKey1)) {
                            //tạo biến subKey1Open chứa tên key con từ đường dẫn của subKey1[Computer\HKEY_CLASSES_ROOT\]
                            RegistryKey subKey1Open = key.OpenSubKey(subKey1); 
                            foreach (string subKey2 in subKey1Open.GetSubKeyNames()) {
                                if (subKey2 == "ShellNew") {
                                    //Kiểm tra tồn tại value NullFile trong key ShellFile (# null là có null là ko có)
                                    if (!subKey1Open.GetValueNames().Contains("NullFile"))
                                        //thêm subkey1 vào danh sách
                                        lbKeys.Items.Add(subKey1); 
                                }//kiểm tra tồn tại key con ShellNew
                            }// Duyệt tất cả các tên subKey1Open trong Computer\HKEY_CLASSES_ROOT\[subKey1Open] đưa vào subKey2
                        }// Chỉ lấy những đuôi hợp lệ theo regexItem và regexNItem
                    }// Duyệt tất cả các tên key trong Computer\HKEY_CLASSES_ROOT\ đưa vào subkey1 
                }// Kiểm tra key không rỗng mới làm
                // Cập nhật lại số key hiện tại trong listbox
                lbNum.Text = lbKeys.Items.Count.ToString();
            }// "Đã Có"
            if (rbNone.Checked){
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
                btnMod.Enabled = false;
                lbKeys.Items.Clear();                
                if (key.SubKeyCount > 0) {
                    foreach (string subKey1 in key.GetSubKeyNames()) {
                        if (regexItem.IsMatch(subKey1) && !regexNItem.IsMatch(subKey1)) {
                            //Mở tất cả các key subKey1 trong Computer\HKEY_CLASSES_ROOT\[subKey1]\ đưa vào isNullKey
                            RegistryKey isNullKey = key.OpenSubKey(subKey1);
                            //tạo mảng _checkNull chứa tên child key [isNullKey]
                            string[] _checkNull = isNullKey.GetSubKeyNames();
                            if (_checkNull.Length == 0){
                                lbKeys.Items.Add(subKey1);
                            }//Kiểm tra isNullKey. nếu isNullKey không có child key(==0) thì add subKey1 vào listbox
                            else {
                                foreach (string subKey2 in isNullKey.GetSubKeyNames()) {                                    
                                    if (!isNullKey.GetSubKeyNames().Contains("ShellNew")) {
                                        lbKeys.Items.Add(subKey1);
                                        break;
                                    }// Nếu có child key "ShellNew" thì add vào listbox sau đó break để tránh add 2 lần
                                }// Thì duyệt tất cả các tên isNullKey trong Computer\HKEY_CLASSES_ROOT\[isNullKey] đưa vào subKey2
                            }// hoặc isNullKey có child key (!=0) 
                        }// Chỉ lấy những đuôi hợp lệ theo regexItem và regexNItem
                    }// Duyệt tất cả các tên key trong Computer\HKEY_CLASSES_ROOT\ đưa vào subkey1 
                }// Kiểm tra key không rỗng mới làm
                 // Cập nhật lại số key hiện tại trong listbox
                lbNum.Text = lbKeys.Items.Count.ToString();
            }// "Chưa có"            
        }
        #endregion
        
        #region Hàm chứa chức năng của button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemSel = Convert.ToString(lbKeys.SelectedItem);
            
            RegistryKey createKey = key.OpenSubKey(itemSel,true);
            if (lbKeys.SelectedItem != null)
            {
                createKey.CreateSubKey("ShellNew");
                RegistryKey NewValue = createKey.OpenSubKey("ShellNew",true);      
                NewValue.SetValue("NullFile",RegistryValueKind.String);
                foreach (string newName in createKey.GetSubKeyNames())
                {
                    if (newName == "ShellNew")
                    {
                        MessageBox.Show("Đã thêm", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRestart.PerformClick();
                    }
                }                                
            }
        } //Thêm
        private void btnDel_Click(object sender, EventArgs e)
        {
            string itemSel = Convert.ToString(lbKeys.SelectedItem);      
            RegistryKey keyDel = key.OpenSubKey(itemSel, true);
            if (lbKeys.SelectedItem != null) {                           
                foreach (string subKeyDel in keyDel.GetSubKeyNames()) {
                    if (subKeyDel == "ShellNew") {
                        keyDel.DeleteSubKey("ShellNew");                        
                        if(Convert.ToString(keyDel) != "ShellNew") {
                            MessageBox.Show("Đã Xoá", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnRestart.PerformClick();
                        }
                    }
                }
            }            
        } //Xoá
        private void btnMod_Click(object sender, EventArgs e)
        {

        } //Sửa
        #endregion
        #region Hàm nạp lại listbox sau khi chỉnh sửa, xoá, thêm key
        private void btnRestart_Click(object sender, EventArgs e)
        {
            var regexItem = new Regex(@"^\.");
            var regexNItem = new Regex(@"_");
            if (rbActived.Checked)
            {
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
                btnMod.Enabled = false;
                lbKeys.Items.Clear();
                if (key.SubKeyCount > 0)
                {
                    foreach (string subKey1 in key.GetSubKeyNames()) 
                    {
                        if (regexItem.IsMatch(subKey1) && !regexNItem.IsMatch(subKey1)) 
                        {
                            RegistryKey subKey1Open = key.OpenSubKey(subKey1); 
                            foreach (string subKey2 in subKey1Open.GetSubKeyNames()) 
                            {
                                if (subKey2 == "ShellNew") 
                                {
                                    if (!subKey1Open.GetValueNames().Contains("NullFile")) 
                                        lbKeys.Items.Add(subKey1); 
                                }
                            }
                        }
                    }
                }
            }
            if (rbNone.Checked)
            {
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
                btnMod.Enabled = false;
                lbKeys.Items.Clear();
                if (key.SubKeyCount>0)
                {
                    foreach (string subkey1 in key.GetSubKeyNames())
                    {
                        if (regexItem.IsMatch(subkey1) && !regexNItem.IsMatch(subkey1))
                        {
                             RegistryKey isNullKey = key.OpenSubKey(subkey1);                            
                            string[] _checkNull = isNullKey.GetSubKeyNames();
                            if (_checkNull.Length == 0){
                                lbKeys.Items.Add(subkey1);
                            }
                            else {
                                foreach (string subKey2 in isNullKey.GetSubKeyNames()) {                                    
                                    if (!isNullKey.GetSubKeyNames().Contains("ShellNew")) {
                                        lbKeys.Items.Add(subkey1);
                                        break;
                                    }
                                }
                            } 
                        }
                    }
                }
            }
            lbNum.Text = lbKeys.Items.Count.ToString();
        }
        #endregion
        #region Hàm mở khoá button theo RadioButton
        private void lbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbActived.Checked)          
            {
                btnDel.Enabled = true;
                btnMod.Enabled = true;                
            }
            else if (rbNone.Checked)
            {
                btnAdd.Enabled = true;
                btnMod.Enabled = false;
                btnDel.Enabled = false;
            }                          
        }
        #endregion

        #region Hàm hiệu ứng transition
        private void cmdMore_Click(object sender, EventArgs e)
        {
            int iFormWidth;
            iFormWidth = 520;
            Transition.run(this, "Width", iFormWidth, new TransitionType_EaseInEaseOut(100));
        }
        private void cmdLess_Click(object sender, EventArgs e)
        {
            int iFormWidth;
            iFormWidth = 330;
            Transition.run(this, "Width", iFormWidth, new TransitionType_EaseInEaseOut(100));
        }
        #endregion
    }
}