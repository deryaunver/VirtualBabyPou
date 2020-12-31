using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualBabyPou
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Konsole

            Console.Title = "☺☺☺ SANAL BEBEK POU ☺☺☺"; 

            //string[] menuler = { "Enerji", "Açlık", "Uyku", "Hijjen", "Mutluluk" };
            string[] menuler = { "Besle", "Uyut", "Yıka", "Oynat"  };
            Console.ForegroundColor = ConsoleColor.Yellow;
            string tire = " ---------------------------------------------------------\n";
            Console.WriteLine("\t     Oyuna Başlamak için gerekli bilgileri giriniz\t\t\t ".ToUpper());
           KonsolIslemleri. Bekletme(tire);
            Console.Write("\t  Kullanıcı Adınız: ");
            string kullanıcıAdi = Console.ReadLine().ToUpper();
          
            string cumle = "           SANAL BEBEK POU OYUNUNA HOŞGELDİN ";
            Console.Clear();
            Console.WriteLine("\n \n \n \n");
            KonsolIslemleri.Bekletme(tire);
            Console.WriteLine(KonsolIslemleri.Bekletme(cumle) + " " + "\n \n \t \t \t" + "         " + kullanıcıAdi.ToUpper());
            KonsolIslemleri.Bekletme(tire);
            Thread.Sleep(1000);
            Console.Clear();
            #endregion
            BebekPou bebek = new BebekPou();
            KonsolIslemleri.BebekDurumunuYaz(bebek);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(KonsolIslemleri.MenuOlustur(menuler) + "\n");
                Console.WriteLine("\t POU İçin En Doğru Seçimi Yap  ");
                char secim = Console.ReadKey(true).KeyChar;
                switch (secim)
                {
                    case '1':
                        bebek.Besle();
                        break;
                    case '2':
                        bebek.Uyut();
                        break;
                    case '3':
                        bebek.Yıka();
                        break;
                    case '4':
                        bebek.OyunOynat();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" \n\n\n \t \t \t Geçerli bir seçim yapmadınız!!!");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                }
                Thread.Sleep(1000);
                Console.Clear();
                KonsolIslemleri.BebekDurumunuYaz(bebek);
                if (bebek.hayattaMı == false)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\n\n\n\n");
                    Console.WriteLine($"{"\t \t \t \t"+KonsolIslemleri.Bekletme("BEBEK POU ÖLDÜ ! SEN BİR KATİLSİN...")+"\t \t \t \t"}");
                    Thread.Sleep(2000);
                    break;
                }
            }
        }
     
        public class BebekPou
        {
            private Random random = new Random();

            private int enerji=50;
            private int uyku = 50;
            private int aclık = 50;
            private int hijjen = 50;
            private int mutluluk = 50;
            public bool hayattaMı = true;

            public int Uyku
            {
                get
                {
                    return uyku;
                }
                set
                {
                    if (value <= 0)
                    {
                        uyku = 0;
                        hayattaMı = false;
                    }
                    

                    else if (value >= 100)
                    {
                        uyku = 100;
                        hayattaMı = false;
                    }
                    else
                        uyku = value;
                }
            }
            public int Enerji
            {
                get
                {
                    return enerji;
                }
                set
                {
                    if (value <= 0)
                    {
                        enerji = 0;
                        hayattaMı = false;
                    }
                    else if (value >= 100)
                    {
                        enerji = 100;
                        hayattaMı = false;
                    }
                    else
                        enerji = value;
                }
            }

            public int Hijjen
            {
                get
                {
                    return hijjen;
                }
                set
                {
                    if (value <= 0)
                    {
                        hijjen = 0;
                        hayattaMı = false;
                    }
                    else if (value >= 100)
                    {
                        hijjen = 100;
                        hayattaMı = false;
                    }
                    else
                        hijjen = value;
                }
            }

            public int Aclık
            {
                get
                {
                    return aclık;
                }
                set
                {
                    if (value <= 0)
                    {
                        aclık = 0;
                        hayattaMı = false;
                    }
                    else if (value >= 100)
                    {
                        aclık = 100;
                        hayattaMı = false;
                    }
                    else
                        aclık = value;
                }
            }

            public int Mutluluk
            {
                get
                {
                    return mutluluk;
                }
                set
                {
                    if (value <= 0)
                    {
                        mutluluk = 0;
                        hayattaMı = false;
                    }
                    else if (value >= 100)
                    {
                        mutluluk = 100;
                        hayattaMı = false;
                    }
                    else
                        mutluluk = value;
                }
            }
            public void Uyut()
            {
                Uyku -= random.Next(10);
                Enerji += random.Next(10);
                Mutluluk += random.Next(10);
                Aclık += random.Next(10);
                Hijjen -= random.Next(10);
            }

            public void Yıka()
            {
                Hijjen += random.Next(10);
                Uyku += random.Next(10);
                Enerji -= random.Next(10);
                Mutluluk += random.Next(10);
                Aclık += random.Next(10);
            }

            public void Besle()
            {
                Hijjen -= random.Next(20);
                Uyku += random.Next(15);
                Enerji += random.Next(10);
                Aclık += random.Next(10);
                Mutluluk += random.Next(10);
            }

            public void OyunOynat()
            {
                Uyku += random.Next(10);
                Enerji -= random.Next(10);
                Hijjen -= random.Next(10);
                Aclık += random.Next(10);
                Mutluluk += random.Next(10);

            }

        }

        static class KonsolIslemleri
        {
            public static string MenuOlustur(string[] menuler)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                string menu = "\t ☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺\n \n";
                
                for (int i = 0; i < menuler.Length; i++)
                {
                    menu += $"\t {i + 1}-) {menuler[i]}  ";
                }
                menu += "\n\n \t ☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺☺";
                
                return menu;
            }

            public static string Bekletme(string cumle)
            {
                Console.Write("\t");
                string metin = "";
                for (int i = 0; i < cumle.Length; i++)
                {
                    Thread.Sleep(30);
  
                    Console.Write(cumle[i]);
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                }

                return metin;
            }

            public static void BebekDurumunuYaz(BebekPou bebek)
            {
                string tire = " -----------------------------------------------------\n";
                Console.Write(Bekletme(tire));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t \t Uyku:        \t {0}\t{1}",bebek.Uyku,BebekDurumunaBarEkle(bebek.Uyku));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t \t Enerji:\t {0}\t{1}",bebek.Enerji,BebekDurumunaBarEkle(bebek.Enerji));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t \t Açlık:        \t {0}\t{1}",bebek.Aclık,BebekDurumunaBarEkle(bebek.Aclık));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t \t Hijyen:\t {0}\t{1}",bebek.Hijjen,BebekDurumunaBarEkle(bebek.Hijjen));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t \t Mutluluk:\t {0}\t{1}",bebek.Mutluluk,BebekDurumunaBarEkle(bebek.Mutluluk));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t \t POU durumu:\t {(bebek.hayattaMı ? "POU hayatta" : "öLDÜÜÜ.")}");
                Console.Write(Bekletme(tire));
            }

            public static string BebekDurumunaBarEkle(int durumDeger)
            {
                string bar = "";
                durumDeger /= 10;
                for (int i = 0; i < durumDeger; i++)
                    bar += '♥'  ;
                return bar;
            }
        }
       



    }

}


