using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, FirstName = "Engin", LastName = "Demirog", Age = 11 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();

        }
    }

    // aşağıda da class'a bir özellik ekledik attribute sayesinde. Attribute'lere parametre de ekleyebiliyoruz aşağıdaki gibi.
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
        // yukarıda FirstName, LastName ve Age şeylerine birer attribute ekledik.
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add Method")] // yandaki şey hazır bir attribute uyarmak için kullanılabilir böyle içine not da düşülebiliyor böyle.
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }


    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)] //yandaki şey ile bir attribute'a da attribute ekledik bu eklediğimiz şey sayesinde bu attribute'muz sadece nesnelere eklenebiliyor.
    // eğer AttributeTargets.Class felan deseydik sadece class'lar için eğer .All deseydik hepsi için olurdu. AllowMultiple = true demekde bu attribute'i aynı şeyin üzerine birden fazla kez koyabilirsin demek.
    class RequiredPropertyAttribute : Attribute
    {

    }
    // Attribute'ları nesnelerimize özellik eklemek için felan kullanırız. 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] // böyle aynı anda bir kaç tanesine izin de verilebilir.
    class ToTableAttribute : Attribute
    {
        private string _TableName;
        public ToTableAttribute(string TableName)
        {
            _TableName = TableName;
        }
    }


}
