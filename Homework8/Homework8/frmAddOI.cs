using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework11
{
    public partial class frmAddOI : Form
    {
        private OrderItem currentOI;
        public OrderItem CurrentOI { get { return currentOI; }set { currentOI = value; } }
      /*  public List<Goods> shopgoods = new List<Goods> { new Goods("fish", 10),
                                                  new Goods("gun", 100),
                                                  new Goods("wine", 15) };*/
        public frmAddOI()
        {
            InitializeComponent();
        }
        public frmAddOI(OrderItem newOI) :this()
        {
            CurrentOI = newOI;
        }

        private void frmAddOI_Load(object sender, EventArgs e)
        {
            string[] goods = { "fish", "gun", "wine" };
            cboGoodsType.DataSource = goods;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currentOI.Quantity = int.Parse(txtQuantity.Text);               
            }
            catch
            {
                MessageBox.Show("请输入数字!");
            }
        }

        private void cboGoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentOI.Goods = frmMain.shopgoods.Find(x => x.Type == cboGoodsType.SelectedItem.ToString());
            // cboGoodsType.DataBindings.Add("SelectedItem", this, "currentOI.thisgoods");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
