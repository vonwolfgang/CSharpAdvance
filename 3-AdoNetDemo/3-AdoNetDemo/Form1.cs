using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_AdoNetDemo
{
    public partial class Form1 : Form
    {

        ProductDal _productDal = new ProductDal();
        // productDal 'ı tekrar tekrar new'lememek için bunu buraya yazdık ve başına tek çizgi koyduk.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
            // dgwProducts bizim oluşturduğumuz tablomuzun ismi mi öle bir şey burdan DataSource metodu gibi bişeyi bizim oluşturduğumuz productDal objesindeki
            // GetAll metoduna erişmek için kullandık.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {

                Name = tbxName.Text,
                StockAmount=Convert.ToInt32(tbxStockAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text)

            });
            // yazdığımız add fonksiyonunu burda çağırdık ve içerisine bir Product nesnesi verdik bu product nesnesi içerisine parametrelerini
            // kullanıcıdan girerek aldığı için ordan çağırdık.
            LoadProducts();
            MessageBox.Show("Product added!");
            // kullanıcıya bu mesajı gösterdik en son.

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
            // bu metot bir event metodu. Bu metot mouse ile dgw'ye tıkladığımız da gerçekleşecek olan olayı yapıcak
            // bizde şunu yaptık dedik ki ordaki update bölümündeki name bölümüne dgw'deki name'i unit price bölümüne unitprice tek tek ata dedik.

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // bu ise bizim update eventimiz olucak

            Product product = new Product { 
            
            Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            Name = tbxNameUpdate.Text.ToString(),
            StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
            UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
        };
            // kullanıcıdan aldığımız bilgilerle bir tane product nesnesi oluşturduk
            _productDal.Update(product);
            // metodumuzu çağırdık
            LoadProducts();
            MessageBox.Show("Products updated!");

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            // id çektik
            _productDal.Delete(id);
            // metodumuzu çağırdık
            LoadProducts();
            MessageBox.Show("Your product deleted!");
        }
    }
}
