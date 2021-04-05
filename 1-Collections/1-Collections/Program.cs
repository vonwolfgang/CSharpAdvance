using System;
using System.Collections;
using System.Collections.Generic;

namespace _1_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            // burda dictionary tanımladık içine verdiğimiz tip ile kilidin tipini ve o kilidi açan anahtarın tipini belirledik.

            dictionary.Add("book", "kitap");
            dictionary.Add("table", "masa");
            dictionary.Add("computer", "bilgisayar");
            // içine eleman ekledik.

            Console.WriteLine(dictionary["table"]);
            // bu sayede kilidi verip anahtarı çekebiliyoruz.

            dictionary.ContainsKey("table");
            // bu senin içinde table isminde bir kilit var mı diye bakıp ona göre true false döndürüyor.




        }

        private static void List()
        {
            List<String> cities = new List<String>();
            // sadece String tipinde veri alabilen bir liste oluşturduk tip güvenli olmuş oldu.

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "anonymous" });
            customers.Add(new Customer { Id = 2, Name = "hello" });
            // burda ise customers tipinde veri alan bir liste oluşturup içine kendi oluşturduğumuz customers class'ından nesne verdik içine

            Customer customer1 = new Customer() { Id = 5, Name = "Friend" };
            // bir tane customer1 objesi oluşturduk

            customers.Add(customer1);
            // add ile ekledik.

            var count = customers.Count;
            // eleman sayısını verir

            customers.AddRange(new Customer[2] {

            new Customer{Id=3, Name= "Ali" },
            new Customer{Id=4, Name= "Veli" }

            });
            // AddRange ise içerisine bir liste alabiliyor.

            //customers.Clear();
            // tüm elemanları temizler.

            Console.WriteLine(customers.Contains(new Customer { Id = 1, Name = "anonymous" }));
            // bu fonksiyon içerisinde böyle bir eleman var mı yok mu diye bakar varsa true yoksa false döner bu yukarıda arattığımız şey false
            // dönücek çünkü biz bunu şimdi burda new'ledik ve new'leyince yeniden oluştu yani eskisinin referansını tutmuyor artık.

            var index = customers.IndexOf(customer1);
            // içine verdiğimiz elemanın index nosunu verir.

            var index1 = customers.LastIndexOf(customer1);
            // bu ise aramaya sondan başlayarak arar ve index nosunu verir.

            customers.Insert(0, customer1);
            // bu ise istediğin indexe değer ekleyebilion

            customers.Remove(customer1);
            // bu metot içine yazdığımız elemanı arar ilk bulduğunu siler.

            //customers.RemoveAll(c=>c, Name == "anonymous");
            // yukarıda yaptığımız şey listeden ismi anonymous olanları bul hepsini sil dedik.
            // buna predikit mı öle bişe deniomuş ileride öğreticek burda bende nedense hata verdi anlamadım.


            foreach (var x in customers)
            {
                Console.WriteLine(x.Name);
            }
        }

        private static void ArrayList()
        {
            ArrayList cities = new ArrayList();
            // array list tanımladık. Buna istediğimiz kadar eleman ekleyebiliriz.
            
            cities.Add("anonymous");
            cities.Add(1);
            // bu Add metodu içine obje tipinde bişe istio obje tipi tüm tiplerin ana base'idir.
            
            Console.WriteLine(cities.Contains("Ali"));
            // bu arattığımız yerin içinde var mı yok mu diye bakıyor varsa True dönüyor yoksa false.

            foreach (var x in cities)
            {

                Console.WriteLine(x);

            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // class oluşturup içine o classın taşıyacağı özellikleri verdik ve getter ve setter yazdık.
    }



}
