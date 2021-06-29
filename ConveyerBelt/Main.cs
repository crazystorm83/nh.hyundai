using ConveyerBelt.ConveyerBelt;
using ConveyerBeltCustomControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConveyerBelt
{
    public partial class Main : Form
    {

        private List<ConbeyerBeltBiz.Item> Items = new List<ConbeyerBeltBiz.Item>();

        private SplitContainer activeSplitContainer = null;
        private ConveyerBeltItem activeConveyerBeltItem = null;

        Regex hasItemRegex = new Regex(@"^tab\d+_info1");
        Regex LocationRegex = new Regex(@"^tab\d+_info2");
        Regex BarcodeRegex = new Regex(@"^tab\d+_info3");
        Regex StatusRegex = new Regex(@"^tab\d+_info4");
        Regex ErrorCodeRegex = new Regex(@"^tab\d+_info5");

        public Main()
        {
            InitializeComponent();

            timer1.Interval = 1000; //1초 * 3 = 3초
            timer1.Tick += Timer1_Tick;

            Dictionary<string, List<ConbeyerBeltBiz.Item>> tabs = new Dictionary<string, List<ConbeyerBeltBiz.Item>>();

            this.ChangeTab();
            btnTimerStart_Click(null, null);
        }

        private void ChangeTab ()
        {
            foreach (Control control in ctrlTabs.TabPages[this.ctrlTabs.SelectedIndex].Controls)
            {
                if (control is SplitContainer)
                {
                    this.Items.Clear();
                    this.activeSplitContainer = control as SplitContainer;

                    foreach (Control ctrl in this.activeSplitContainer.Panel1.Controls)
                    {
                        if (ctrl is ConveyerBeltItem)
                        {
                            ctrl.MouseHover += ConveyerBeltItem_MouseHover;
                            ctrl.MouseLeave += ConveyerBeltItem_MouseLeave;
                            ctrl.BackColor = Color.Gray; //최초 색상 값

                            ConbeyerBeltBiz.Item conbeyerBeltItem = new ConbeyerBeltBiz.Item()
                            {
                                LabelInfo = new ConbeyerBeltBiz.LabelInfo()
                                {
                                    Name = ctrl.Name,
                                    BackColor = ctrl.BackColor
                                }
                            };
                            conbeyerBeltItem.ChangeHasItem += Item_ChangeHasItem;
                            conbeyerBeltItem.ChangeBarcode += Item_ChangeDisplay;
                            conbeyerBeltItem.ChangeErrorCode += Item_ChangeDisplay;
                            conbeyerBeltItem.ChangeLocation += Item_ChangeDisplay;
                            conbeyerBeltItem.ChangeStatus += Item_ChangeDisplay;
                            this.Items.Add(conbeyerBeltItem);
                        }
                    }
                }
            }

            UpdateDisplay(null);
        }

        private void Item_ChangeHasItem(string name, bool oldValue, bool newValue)
        {
            Control[] controls = this.activeSplitContainer.Panel1.Controls.Find(name, true);
            ConbeyerBeltBiz.Item item = this.Items.Find((v) =>
            {
                return v.LabelInfo.Name == name;
            });

            if (item != null)
            {
                if (newValue)
                {
                    item.LabelInfo.BackColor = Color.LightGreen; //변경되는 색상 값
                }
                else
                {
                    item.LabelInfo.BackColor = Color.Gray; //최초 색상 값
                }

                foreach (Control control in controls)
                {
                    if (control is ConveyerBeltItem)
                    {
                        control.BackColor = item.LabelInfo.BackColor;
                    }
                }

                if (this.activeConveyerBeltItem != null && this.activeConveyerBeltItem.Name == name)
                {
                    UpdateDisplay(item);
                }
            }
        }

        private void Item_ChangeDisplay(string name, string oldValue, string newValue)
        {
            Control[] controls = this.activeSplitContainer.Panel1.Controls.Find(name, true);
            ConbeyerBeltBiz.Item item = this.Items.Find((v) =>
            {
                return v.LabelInfo.Name == name;
            });

            if (item != null)
            {
                if (this.activeConveyerBeltItem != null && this.activeConveyerBeltItem.Name == name)
                {
                    UpdateDisplay(item);
                }
            }
        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int seedIndex = random.Next(0, this.Items.Count);

            this.Items[seedIndex].HasItem = !this.Items[seedIndex].HasItem;
            this.Items[seedIndex].ErrorCode = this.Items[seedIndex].ErrorCode + "1";
        }

        private void btnTimerEnd_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ConveyerBeltItem_MouseHover(object sender, EventArgs e)
        {
            if (!(sender is ConveyerBeltItem)) return;

            ConveyerBeltItem UIitem = sender as ConveyerBeltItem;
            ConbeyerBeltBiz.Item dataItem = null;

            foreach (ConbeyerBeltBiz.Item item in this.Items)
            {
                if (item.LabelInfo.Name == UIitem.Name)
                {
                    dataItem = item;
                    break;
                }
            }

            if (dataItem == null) return;

            this.activeConveyerBeltItem = UIitem;

            UpdateDisplay(dataItem);
        }

        private void ConveyerBeltItem_MouseLeave(object sender, EventArgs e)
        {
            if (!(sender is ConveyerBeltItem)) return;

            this.activeConveyerBeltItem = null;
            this.UpdateDisplay(null);
        }

        private void UpdateDisplay(ConbeyerBeltBiz.Item item)
        {
            foreach (Control ctrl in this.activeSplitContainer.Panel2.Controls)
            {
                if (ctrl is Label)
                {
                    if (hasItemRegex.IsMatch(ctrl.Name))
                    {
                        ctrl.Text = item == null ? "" : item.HasItem == true ? "있다" : "없다";
                    }
                    if (LocationRegex.IsMatch(ctrl.Name))
                    {
                        ctrl.Text = item == null ? "" : item.Location;
                    }
                    if (BarcodeRegex.IsMatch(ctrl.Name))
                    {
                        ctrl.Text = item == null ? "" : item.Barcode;
                    }
                    if (StatusRegex.IsMatch(ctrl.Name))
                    {
                        ctrl.Text = item == null ? "" : item.Status;
                    }
                    if (ErrorCodeRegex.IsMatch(ctrl.Name))
                    {
                        ctrl.Text = item == null ? "" : item.ErrorCode;
                    }
                }
            }
        }

        private void ctrlTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnTimerEnd_Click(null, null);
            this.ChangeTab();
            this.btnTimerStart_Click(null, null);
        }
    }
}
