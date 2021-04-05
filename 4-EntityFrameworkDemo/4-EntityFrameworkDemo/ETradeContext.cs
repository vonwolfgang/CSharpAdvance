using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_EntityFrameworkDemo
{
    class ETradeContext:DbContext 
    {
        public DbSet<Product> Products { get; set; }
        // bunun ne olduğunu anlamadım DbSet diye bir şey varmış onu Product türünde bir şeylerle doldurucaz dedik
        // ismini de Products verdik. Bu şimdi bizim veri tabanımıza gidicek ve bakıcak Products isminde bir tablo var mı diye
        // böyle bir tablo olduğu içinde sorun olmayacak.
    }
}
