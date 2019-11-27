using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemCash;


namespace CashLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //aval az harchizi man baraye cash kardan yek fil bayad ketebkhuneye cash ro farakhuni konam.
            CashLibrary cash = new CashLibrary("FILECASH","DIRECTORY");
            //bad gharare tamam mohtaviate cash ro bekhuni ta beduni az ghabl cashi hast ke bala biad ya na.
            //cash.ReadFile();
            //az tarafi midunam har khundani ye entesabi kenaresh dare.yani har chio mikhunam bayad tu ye jayi zakhirash konam.tabiatan inja ye file string bayad bashe.
            string textFromCash = cash.ReadFile();
            //az oonja ke mohtaviate cashe man alan be surate listi az member hast bayad ye list dorost konam.
            List<CshClss> ListOfMember;
            //EBTEDA BAYAD CHEK KONAM AZ GHABL CASH DASHTAM YA NA YA BE EBARATE BEHTAR LISTE MEMBER HAM ESTEFADE SHODE YA NA
            if (string.IsNullOrEmpty(textFromCash))
            {
                //KHALIE?YEDUNE BESAZ
                ListOfMember = new List<CshClss>;
            }
            else
            {
                //KHALI NIST?PAS HARCHI GEREFTI BEHESH EZAFE KON
                ListOfMember = JsonConvert.DeserializeObject<List<CshClss>>(textFromCash);
            }
            //HALA BARNAMEYE ASLI RO SHORO MIKONAM
            Console.WriteLine($"Tedade Sabtenam Shode Ha : {ListOfMember.Count}");
            Console.Write("Ezafe Kardan Afrade Jadid ===> Enter ");
            Console.ReadLine();
            Console.Write("Tedade Moteghazian : ");
            int Tedad = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<Tedad; i++)
            {
                CshClss Memberdtails = new CshClss();
                Console.Write("Member ID : ");
                Memberdtails._ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Member Name : ");
                Memberdtails._Name = Console.ReadLine();
                ListOfMember.Add(Memberdtails);
            }
            //HALA LE HAME MEMBERA ADD SHODAN MIKHAM MORATAB NAMAYESHESHUN BEDAAM
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTE SABTENAM SHODEGHAN");
            Console.WriteLine("Member Number            Member ID                  Member Name");         
            for (int i = 0; i < ListOfMember.Count; i++)
            {
                Console.WriteLine(i + 1);
                Console.WriteLine($"                          { ListOfMember[i]._ID}");
                                                              
                Console.WriteLine($"                                                     { ListOfMember[i]._Name}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            //hala harchi etelaat darm ro mikhaym cash konim.
            int kod = cash(ListOfMember);
            switch (kod)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();


        }
        public static int SaveCash(List<CshClss> TOCASH)
        {
            string JsonSerialized = JsonConvert.SerializeObject(TOCASH);
            CashLibrary saveCash = new CashLibrary("FILECASH", "DIRECTORY");
            int res = 0;
            try
            {
                res = saveCash.Write_ToFile(JsonSerialized, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            int i = 0;
            int j = 0;
            return res;
        }
    }
}
