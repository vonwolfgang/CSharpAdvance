using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string message) : base(message)
        {

        }
        // yukarıda bir constructor oluşturduk bu constructor base class'daki message'ı alıyor ve parametre olarak vermemizi sağladı
        // kendi hata şeyimize.
    }
}

// kendi hata sınıfımızı yazdık. Exception classını inheritance ettik ve bu onun hata sınıfı olmasını sağladı.


