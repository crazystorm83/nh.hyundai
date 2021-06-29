using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConveyerBelt.ConveyerBelt
{
    public partial class ConveyerBeltSetting : Form
    {
        public ConveyerBeltSetting()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
        }

        private bool Validation()
        {
            string strRowCount = this.txtRowCount.Text.Trim();
            string strColumnCount = this.txtColumnCount.Text.Trim();

            int iRowCount = 0;
            int iColumnCount = 0;
            int.TryParse(strRowCount, out iRowCount);
            int.TryParse(strColumnCount, out iColumnCount);

            if (strRowCount == "")
            {
                MessageBox.Show("행을 입력해주세요.");
                return false;
            }
            else if (iRowCount == 0)
            {
                MessageBox.Show("0 보다 큰 행을 입력해주세요.");
                return false;
            }

            if (strColumnCount == "")
            {
                MessageBox.Show("열을 입력해주세요.");
                return false;
            }
            else if (iColumnCount == 0)
            {
                MessageBox.Show("0 보다 큰 열을 입력해주세요.");
                return false;
            }

            return true;
        }

        private void txtRowCount_KeyDown(object sender, KeyEventArgs e)
        {
            string prevRowCount = this.txtRowCount.Text;

            if (!this.OnlyNumber(e))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                this.txtRowCount.Text = prevRowCount;
            }
        }

        private void txtColumnCount_KeyDown(object sender, KeyEventArgs e)
        {
            string prevRowCount = this.txtColumnCount.Text;

            if (!this.OnlyNumber(e))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                this.txtRowCount.Text = prevRowCount;
            }
        }

        private bool OnlyNumber(KeyEventArgs e)
        {

            return (e.KeyValue >= 48 && e.KeyValue <= 59) //숫자
                || (e.KeyValue >= 37 && e.KeyValue <= 40) //방향키
                || (e.KeyValue == 8 || e.KeyValue == 46); //backspace or delete
        }

        private void LoadSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Controls.Count > 0) {
                if (MessageBox.Show("기존 설정 정보가 저장되지 않고 불러옵니다. 계속 하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.ClearControls();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;

            }
        }

        private void newSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Controls.Count > 0)
            {
                if (MessageBox.Show("설정을 초기화 하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.ClearControls();
                }
            }
        }

        private void ClearControls()
        {
            for (int i = this.Controls.Count - 1; i > -1; i--)
            {
                Control ctrl = this.Controls[i];

                if (ctrl is MenuStrip) {}
                else if (ctrl is OpenFileDialog) {}
                else
                {
                    this.Controls.Remove(ctrl);
                }
            }
        }
    }
}
