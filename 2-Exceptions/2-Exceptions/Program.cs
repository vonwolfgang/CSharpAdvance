using System;
using System.Collections.Generic;

namespace _2_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exception();

            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {

                Console.WriteLine(exception.Message);
            }
            // burda ise hatamızı yönettik ele aldık.

            HandleException(()=> {

                Find();
            
            });
            // HandleException'ı bir method olarak hayal et method ların içine parametre olarak method vermek için ise delege denen şeyleri
            // kullanıyoruz bunlar c#'a özgü çoğu dilde yok bu delege yukarıdaki gibi yazılıyor ve bu şu demek
            // ben sana bir tane parametresiz metod göndericem => bunun karşılığı da kod kümesi demek.



        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
                // bu içine parametre olarak verdiğimizi metodumuzu burda çalıştır demek.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };
            // bi string listesi oluşturduk

            if (!students.Contains("ahmet"))
            {
                throw new RecordNotFoundException ("Record not found");
                // burda ise parametre olarak kendi messagımızı verdik.
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
            // sonrasında if else bloğuna aldık ve eğer students listesinde ahmet yoksa kendi yazdığımız hatayı fırlat dedik eğer bulunursa 
            // record found yaz dedik.
        
        }

        private static void Exception()
        {
            try
            {
                string[] students = new string[3] { "engin", "ahmet", "salih" };
                students[3] = "ali";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
                // böyle hataya özel şeylerde yapabiliyoruz
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                // bu exception.Message'ı son kullanıcıya göstermek tehlikeli çünkü herhangi bir hatada bunu gösterirsek 
                // son kullanıcı sistem hakkında baya bilgi edinmiş olur.

                Console.WriteLine(exception.InnerException);
                // bu ınnerexception ise hatamız ile ilgili daha ayrıntılı bilgi varsa onu gösterir.

                // bunları sisteme loglamak için kullanırız.
            }
        }
    }
}
