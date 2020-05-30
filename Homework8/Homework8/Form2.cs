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
    public partial class frmAddOrder : Form
    {
        private Order currentOrder;
        public Order CurrentOrder { get{ return currentOrder; }set { currentOrder = value; } }
        public string txtContent
        {
            // get { return CurrentOrder.Customer.Name; }
            // set { CurrentOrder.Customer.Name=value; }
            get;set;
        }

        public frmAddOrder()
        {
            InitializeComponent();
        }
        public frmAddOrder(Order currentOrder,bool ifNewOrder) :this()
        {
            CurrentOrder = currentOrder;
            OrderAddingbindingSource.DataSource = currentOrder.orderItemList;
            /*foreach (int x in new int[] { 0, 2, 3 })                        //只可修改数量   
                dgvOIofAddingOrder.Columns[x].ReadOnly = true;*/
            txtCname.DataBindings.Add("Text", this, "txtContent");
            if(ifNewOrder)                                                  //是新建订单，初始化订单号
            {
                do
                {
                    Random random = new Random();
                    currentOrder.OrderId = random.Next(0, 10000);
                } while (frmMain_parameter.orderlist.Exists(x => x.OrderId == currentOrder.OrderId));
            }
            else                                                             //是待修改订单
            {
                txtCname.ReadOnly = true;
            }
        }

        private void btnAddOI_Click(object sender, EventArgs e)
        {
            frmAddOI form3 = new frmAddOI(new OrderItem());
            if (form3.ShowDialog() == DialogResult.OK)
            {
                form3.CurrentOI.OrderId = CurrentOrder.OrderId;
                form3.CurrentOI.GoodsId = form3.CurrentOI.Goods.ID;
                currentOrder.addOrderItem(form3.CurrentOI);
                OrderAddingbindingSource.DataSource = currentOrder.orderItemList;
                OrderAddingbindingSource.ResetBindings(false);
            }
        }

  /*
        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            do
            {
                Random random = new Random();
                currentOrder.id = random.Next(0, 10000);
            } while (frmMain_parameter.orderlist.Exists(x => x.Id == currentOrder.id));
        }
        */
        private void btnDelOI_Click(object sender, EventArgs e)
        {
            OrderItem ClickedOrderItem =dgvOIofAddingOrder.CurrentRow.DataBoundItem as OrderItem;
            currentOrder.deleteOrderItem(ClickedOrderItem);
            OrderAddingbindingSource.DataSource = currentOrder.orderItemList;
            OrderAddingbindingSource.ResetBindings(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Customer temp = new Customer(txtContent);
                if (!CustomerService.Contain(temp))
                    CurrentOrder.Customer = temp;
                else
                    CurrentOrder.Customer = CustomerService.GetCustomerByName(txtContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CurrentOrder.CustomerId = CurrentOrder.Customer.Id;
            }

        }
    }
}
