using ExcelDna.Integration;

namespace DNA
{
    public class Class1
    {
        [ExcelFunction(Description = "My first .NET function")]
        public static string HelloDna(string name)
        {
            return "Hello " + name;
        }

        [ExcelFunction(Description = "My second .NET function")]
        public static object[,] myVéletlen(int sorok, int oszlopok)
        {
            var tömb = new object[sorok, oszlopok];

            Random rnd = new Random();
            for(int s = 0; s<sorok; s++)
            {
                for(int o = 0; o<oszlopok; o++)
                {
                    tömb[s, o] = rnd.Next(1, 7);
                }
            }

            return tömb;
        }

        [ExcelFunction(Description = "My third .NET function")]
        public static object[,] Adatbázis(int sorok, int oszlopok)
        {   BikestoreModels.SeBikestoreContext context = new BikestoreModels.SeBikestoreContext();
            var biciklik = context.Products.ToList();
            var tömb =new object[biciklik.Count,3];

            for(int i = 0; i<biciklik.Count; i++)
            {
                tömb[i, 0] = biciklik[i].Brand;
                tömb[i, 1] = biciklik[i].ProductName;
                tömb[i, 2] = biciklik[i].ListPrice;
            }
            return tömb;
        }
    }
}
