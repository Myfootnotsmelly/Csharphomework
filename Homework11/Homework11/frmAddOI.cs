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
        public List<Goods> shopgoods = new List<Goods> { new Goods(goodstype.fish, 10),
                                                  new Goods(goodstype.gun, 100),
                                                  new Goods(goodstype.wine, 15) };
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
            goodstype[] goods = { goodstype.fish, goodstype.gun, goodstype.wine };
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
            currentOI.thisgoods = shopgoods.Find(x => x.type == (goodstype)cboGoodsType.SelectedItem);
            // cboGoodsType.DataBindings.Add("SelectedItem", this, "currentOI.thisgoods");
        }
    }
}
