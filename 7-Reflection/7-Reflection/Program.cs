using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            //DortIslem dortIslem = new DortIslem(2,3);
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());
            // yukarıdaki komut satırı içine almamızın sebebi aşağıda aynı işlemi yaptık o yüzden tekrar yapmaya ihtiyaç yok

            //var tip = typeof(DortIslem); // yanda DortIslem'in tipini aldık.
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip, 5,7); // burda ise gelen tipe göre newleme işlemi gerçekleştiriliyor.
            //// ama bu newleme işlemi program çalıştırılırken gerçekleştiriliyor bu da reflection işlemi olmuş oluyor. Activator'un başına 
            //// (DortIslem) yazmamızın sebebi Activator bir obje döndürüyor ama biz onu tipi DortIslem olan bir şeye atamaya çalıştığımız için tip dönüşümü gibi bişe.
            //// yukarıda tip, 5,7 yazmamızın sebebi biz sınıfımıza constructor da eklemiştik o değerleri koyduk
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var tip = typeof(DortIslem); // bunun tipini aldık.
            var instance = Activator.CreateInstance(tip, 4, 6); // tipini aldığı nesneyi yarattırdık. 
            Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance,null)); // sonra burda o nesnenin parametresiz methodunu çağırdık. Invoke ile o methodu çalıştırdık
            // parametremiz olmadığı için null verdik ve ne için çalıştıracağını söylemek için instance yazdık. Çünkü instance.GetType().GetMethod() diyerek sadece 
            // method info elde etmiş olduk.

            Console.WriteLine("-----------------------------------------------------");

            var methods = tip.GetMethods();
            // yukarıdaki şey ile tipini çektiğimiz şeyin tüm methodlarını bir liste döndüren GetMethods'u ile çekebiliriz.

            foreach (var info in methods) 
            {
                Console.WriteLine("Method Name : {0}", info.Name); // yanda ise tüm method isimlerini çağırdık.

                Console.WriteLine("----------------------------------------------------");
                
                foreach (var parameterInfo in info.GetParameters())    // yanda ise şöyle bir şey yaptık tüm parametreleri çağırdık parametreye sahip olanların tabiki.
                {
                    Console.WriteLine("Method Parameter Name : {0}", parameterInfo.Name);
                }

                // GetCustomAttributes nedense hata veriyor NEDEN OLDUĞUNU BİLMİYORUM !!!!!
                foreach (var attribute in info.GetCustomAttributes()) // yanda ise attribute sahip olanların attribute'lerini çağırdık.
                {
                    Console.WriteLine("Attribute Name : {0}", attribute.GetType().Name);
                }




            }

            
            








            Console.ReadLine();
        }
    }

    class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {

        }
        // yukarıdaki şeyler constroctor.

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        // yukarıda yazdığımız Topla ve Carp metotları parametrelerini Constructordan değil de kullanıcıdan alıyor.

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
        // yukarıdaki Topla2 ve Carp2 metotları ise class'da yazdığımız constructor'dan parametrelerini alıyor.


    }


    public class MethodNameAttribute : Attribute 
    {
        public MethodNameAttribute(string name)
        {

        }

    }






}
