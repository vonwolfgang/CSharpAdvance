using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_Generics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "Adana");

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }    
    }





    //----------------------------------------------------------------------------------------------------------------------
    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        } 
    }
    // yukarıda bir tane Utilities sınıfı oluşturduk sonra bu sınıfın içerisine bir tane generic metot oluşturduk bu metot
    // bir liste döndürücek ama döndürdüğü listenin tipi belli değil o generic yani ne verirsek o tip de döndürücek listeyi
    // peki listeyi ne ile oluşturucak bizim verdiğimiz T tipindeki items listesi ile oluşturucak o listeyi de 

    //-------------------------------------------------------------------------------------------------

    class Product
    {

    }

    class Customer
    {

    }



    interface IProductDal:IRepository<Product>
    {

    }
    // IRepository verdik ve tipini de Product olarak verdik.

    interface ICustomerDal:IRepository<Customer>
    {

        
    }
    // yukarıda IRepository verdik ve tipini Customer olarak verdik.


    interface IEntity
    {

    }

    interface IRepository<T> where T: class, IEntity, new() // yanda koyduğumuz where sayesinde bu T yerine vereceğimiz değerleri kısıtlıyor yani buraya biz class(class referans tipler verilebilir demek burda) yazınca sadece referans tipleri verebilion.
    // new() yazdığımızda ise bu hem referans tip olmalı hem de new'lenebilen bir şey olmalı demek olmuş oluyor. IEntity'de eklenince bu şu demek T bir referans tip olmalı newlenebilmeli ve IEntity'den inherite edilmiş bir şey olmalı.
    // eğer değer tipleri koymak isteseydik de "T:struct" yazardık.
    {

        List<T> GetAll();
        T Get(int id);
        void Add(T t);
        void Delete(T t);
        void Update(T t);
    }
    // yukarıdaki şeyde bir generic nesne oluşturduk bu sınıf sayesinde tekrar tekrar interface yazmak yerine bu sınıfı ortak interface'lerimize veririz
    // verdiğimiz yerde de onun tipini de veririz. 

    class ProductDal : IProductDal
    {
        public void Add(Product t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product t)
        {
            throw new NotImplementedException();
        }
    }


    class CustomerDal : ICustomerDal
    {
        public void Add(Customer t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
