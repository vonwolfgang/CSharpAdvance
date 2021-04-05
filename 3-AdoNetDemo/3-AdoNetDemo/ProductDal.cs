using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=ETrade; integrated security=true");
        // bu bağlantımızı oluşturacak olan sınıfımızdan nesne oluşturduk
        // başına @ koymamızın sebebi tüm yazdıklarımızı string olarak algıla demek için koyduk. initial catalog ise hangi
        // veri tabanını kullanacağımızı belirtmek için verdik. integrated security ise windows autentication key ile bağlan demek.
        // server da zaten hangi serverda ki mssql şeyine bağlandığımızı verdik parametre olarak.
        // biz bu nesneyi metotların dışında tanımladığımız için alt çizgi isimlendirme kuralını uyguladık.
        public List<Product> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", _connection);
            // Sql komutlarını yollamak için bu sınıfı kullanıyoruz. burdan bir obje oluşturduk objenin içine ise Sql'den tüm ürünleri 
            // çeken komutu girdik. yanına connection yazmamızın sebebi ise bu bağlantıyı oraya göndereceğimizi verdik. 

            SqlDataReader reader = command.ExecuteReader();
            // burda bir tablo sonucu çekeceğimizi için komutumuzu ExecuteReader metodu ile açtık. Başka komutlarda başka metotlar ile yaparız.
            // bunu reader'a eşitlememizin sebebi ise bu command.ExecuteReader bi SqlDataReader tipinde bir şey döndürüyor
            // bunu da bir değişkene atadık biz.

            List<Product> products = new List<Product>();

            while (reader.Read())
            // reader.Read() tüm satırları okuyor okunabilecek şey olduğu sürece True dönüyor böylece while döngüsü satırlar bitene kadar dolanıyor.
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    // değeri int döndürmek için Convert.ToInt32 kullandık.
                    Name = reader["Name"].ToString(),
                    // değeri string döndürebilmek için ToString kullandık.
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    // aynı şekilde int tipine çevirdik.
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                    // bunu da decimal tipine çevirdik.
                };
                // Product sınıfı oluşturmuştuk oluşturduğumuz product sınıfına veri tabanından çektiğimiz ürün tablosunu bağladık 
                products.Add(product);
                // her bir ürünü products listemize ekledik.
            }

            _connection.Close();
            return products;
            // bundan sonra ise reader'ımızı kapattık connection'umuzu da kapattık. 
            // en son ise dataTable'ımızı döndürdük.

        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                // bağlantımızı açtık 
            }
            // bunu bir if döngüsü içine aldık çünkü eğer bağlantı açıkken tekrar açmaya çalışırsak hata vericektir. If in içine
            // eğer bağlantı kapalıysa aç bu satırı uygula dedik.
        }

        public void Add(Product product)
        {
            ConnectionControl();
            // bağlantı kontrolü yaptık.
            SqlCommand command = new SqlCommand("Insert into Products values(@name, @unitPrice,@stockAmount)", _connection);
            // SqlComman sınıfından comman objesi ile komutumuzu oluşturduk ve nereye gönderceğini söyledik.
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            // yukarıda parameters diyerek değerleri atadık yani dedik ki yukarıdaki @name değerine product'dan gelen Name değerini ata dedik.
            // hepsini böle yaptık. Bunu böyle değilde string birleştirerek yaparsak ise sql injections denen bir saldırıya mağruz kalabiliriz.
            command.ExecuteNonQuery();
            // bunla komutumuzu göndermiş bulunuyoruz.

            _connection.Close();
            // bağlantımızı kapattık.
        }

        public void Update(Product product)
        {
            ConnectionControl();
            // bağlantı kontrolü yaptık.
            SqlCommand command = new SqlCommand("Update Products set Name=@name, UnitPrice=@unitPrice, StockAmount=@stockAmount where ID=@id", _connection);
            // SqlComman sınıfından comman objesi ile komutumuzu oluşturduk ve nereye gönderceğini söyledik.
            // bu komut ile ürünümüzü güncellemiş oluyoruz bu bir sql komutu where dememizin sebebi ise hangi yere göre güncelleme yapacağını söyledik
            // bunu da id üzerinden yap dedik bu id'i de kullanıcıdan parametre olarka alıcaz.
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            // yukarıda parameters diyerek değerleri atadık yani dedik ki yukarıdaki @name değerine product'dan gelen Name değerini ata dedik.
            // hepsini böle yaptık. Bunu böyle değilde string birleştirerek yaparsak ise sql injections denen bir saldırıya mağruz kalabiliriz.
            command.ExecuteNonQuery();
            // bunla komutumuzu göndermiş bulunuyoruz.

            _connection.Close();
            // bağlantımızı kapattık.
        }

        public void Delete(int id)
        {
            ConnectionControl();
            // bağlantı kontrolü yaptık.
           
            SqlCommand command = new SqlCommand("Delete from Products where Id=@id", _connection);
            // parametre ile gönderilen id'deki ürünü Products 'dan sil dedik.

            command.Parameters.AddWithValue("@id", id);
            // parametre ile gelen id'yi sql komutundaki id'e eşitledik.

            command.ExecuteNonQuery();
            // bunla komutumuzu göndermiş bulunuyoruz.

            _connection.Close();
            // bağlantımızı kapattık.
        }








        // Data table ile çalışmak hem maliyetli hem de seriliği bozuyor bu yüzden bu pek tercih edilmez bunun yerine yukarıda yaptığımız şey tercih edilir.
        public DataTable GetAll2()
        {

            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", _connection);
            // Sql komutlarını yollamak için bu sınıfı kullanıyoruz. burdan bir obje oluşturduk objenin içine ise Sql'den tüm ürünleri 
            // çeken komutu girdik. yanına connection yazmamızın sebebi ise bu bağlantıyı oraya göndereceğimizi verdik. 

            SqlDataReader reader = command.ExecuteReader();
            // burda bir tablo sonucu çekeceğimizi için komutumuzu ExecuteReader metodu ile açtık. Başka komutlarda başka metotlar ile yaparız.
            // bunu reader'a eşitlememizin sebebi ise bu command.ExecuteReader bi SqlDataReader tipinde bir şey döndürüyor
            // bunu da bir değişkene atadık biz.

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            // dataTable şeyine oluşturduğumuz nesnemizi yükledik.

            reader.Close();
            _connection.Close();
            return dataTable;
            // bundan sonra ise reader'ımızı kapattık connection'umuzu da kapattık. 
            // en son ise dataTable'ımızı döndürdük.

        }

    }
}

// insert update delete operasyonlarının bulunduğu bölüm.