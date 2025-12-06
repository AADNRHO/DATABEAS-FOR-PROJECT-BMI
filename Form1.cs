using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }
        
        private void LoadRecords()
        {
            try
            {
                // تأكد أن الجدول موجود
                if (dataGridRecords == null)
                {
                    MessageBox.Show("DataGridView غير موجود في الفورم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

             //   using (var db = new AppDbContext())
                {
                 //   var records = db.Measurements
                                 //   .OrderByDescending(r => r.Date)
                                 //   .ToList();

                    dataGridRecords.AutoGenerateColumns = true;
                    dataGridRecords.DataSource = null;
                //    dataGridRecords.DataSource = records;

                    // حماية من الأخطاء
                    if (dataGridRecords.Columns.Count > 0)
                    {
                        HideColumnIfExists("Id");
                        RenameColumnIfExists("UserName", "الاسم");
                        RenameColumnIfExists("Date", "التاريخ");
                        RenameColumnIfExists("Height", "الطول (سم)");
                        RenameColumnIfExists("Weight", "الوزن (كجم)");
                        RenameColumnIfExists("BMIValue", "BMI");
                        RenameColumnIfExists("BMICategory", "الحالة الصحية");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("تفاصيل الخطأ:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------
        // دوال أمان للأعمدة
        // ----------------------------------------
        private void HideColumnIfExists(string columnName)
        {
            if (dataGridRecords.Columns.Contains(columnName))
                dataGridRecords.Columns[columnName].Visible = false;
        }

        private void RenameColumnIfExists(string columnName, string newName)
        {
            if (dataGridRecords.Columns.Contains(columnName))
                dataGridRecords.Columns[columnName].HeaderText = newName;
        }
    }
}


   
