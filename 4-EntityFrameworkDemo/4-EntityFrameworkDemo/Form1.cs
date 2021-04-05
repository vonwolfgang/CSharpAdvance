using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        // sınıfımızı newledik.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            // yazdığımız metodu burda çağırdık.

        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(String key)
        {
            // var result = _productDal.GetAll().Where(p=>p.Name.ToLower.Contains(key.ToLower)).ToList();
            // Bu yöntemde ToLower dememizin sebebi burda çekilen listeden filtreleme yapılıyor ve C# büyük küçük harf duyarlı olduğu için sıkıntı olabiliyor.
            // bu yüzden hem ismi küçük harf hem key'imizi küçük harf çevirdik. böyle sıkıntı olmuyacaktır. 
            // direk veri tabanından çekmek için bunu komut satırı içine aldık.

            var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
            // yukarıda şey dedik where komutu ile listele deidk sonra gene garip şey kullandık ve dedikki her bir p elemanı için
            // p'nin ismi textbox'da ki şeyleri içermeli dedik. Bu ise sorguyu veri tabanından listelenmiş olan listeye atıyor.
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text)
            });
            // yukarıda ekleme işlemini yaptık 
            LoadProducts();
            MessageBox.Show("your product added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product {

                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Your product Updated!");
            // yukarıda ise şey yaptık update operasyonunu verdik. Id'e göre update edeceği için id'i de verdik
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
            // tıklandığında seçen bir cell click event yaptık
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product {
            
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Your product Deleted");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);
        }
    }
}
