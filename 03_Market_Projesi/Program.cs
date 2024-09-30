namespace _03_Market_Projesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear(); 
                Console.WriteLine("Market Yönetim Sistemi");
                Market.KategoriListele();

                Console.WriteLine("Kategori Seçiniz:");
                int kategoriNo = Convert.ToInt32(Console.ReadLine());

                Console.Clear(); 
                Console.WriteLine("1-Ürün Listele\n2-Ürün Satın Al\n3-Admin Panel");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.Clear(); 
                    Market.UrunListele(kategoriNo);
                }
                else if (secim == "2")
                {
                    Console.Clear(); 
                    Market.UrunSatinAl(kategoriNo);
                }
                else if (secim == "3")
                {
                    Console.Clear(); 
                    Market.AdminPanel(kategoriNo);
                }
                else
                {
                    Console.Clear(); 
                    Console.WriteLine("Hatalı Tuşlama!");
                }

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey(); // Kullanıcıdan bir tuşa basmasını bekle
            }   
    }
}

internal static class Market
{
    internal static string[] gida = { "Et", "Peynir", "Süt" };
    internal static double[] gidaFiyat = { 200, 150, 60 };
    internal static double gidaKdv = 0.20;

    internal static string[] giyim = { "Gömlek", "TShirt", "Etek" };
    internal static double[] giyimFiyat = { 180, 120, 150 };
    internal static double giyimKdv = 0.18;

    internal static string[] bijuteri = { "Ruj", "Toka", "Kolye" };
    internal static double[] bijuteriFiyat = { 75, 40, 100 };
    internal static double bijuteriKdv = 0.10;

    internal static double balance = 0;

    internal static void KategoriListele()
    {
        Console.WriteLine("Kategoriler:");
        Console.WriteLine("1- Gıda");
        Console.WriteLine("2- Giyim");
        Console.WriteLine("3- Bijuteri");
    }

    internal static void UrunListele(int kategoriNo)
    {
        if (kategoriNo == 1)
        {
            for (int i = 0; i < gida.Length; i++)
            {
                Console.WriteLine($"{i}-{gida[i]}: {gidaFiyat[i]} TL (KDV: %{gidaKdv * 100})");
            }
        }
        else if (kategoriNo == 2)
        {
            for (int i = 0; i < giyim.Length; i++)
            {
                Console.WriteLine($"{i}-{giyim[i]}: {giyimFiyat[i]} TL (KDV: %{giyimKdv * 100})");
            }
        }
        else if (kategoriNo == 3)
        {
            for (int i = 0; i < bijuteri.Length; i++)
            {
                Console.WriteLine($"{i}-{bijuteri[i]}: {bijuteriFiyat[i]} TL (KDV: %{bijuteriKdv * 100})");
            }
        }
        else
        {
            Console.WriteLine("Hatalı kategori numarası!");
        }
    }

    internal static void UrunSatinAl(int kategoriNo)
    {
        UrunListele(kategoriNo);

        Console.WriteLine("Seçilen Ürün No:");
        int urunNo = Convert.ToInt32(Console.ReadLine());

        double urunFiyat = 0;
        double kdvOrani = 0;
        string urunAdi = "";

        if (kategoriNo == 1)
        {
            if (urunNo >= 0 && urunNo < gida.Length)
            {
                urunFiyat = gidaFiyat[urunNo];
                kdvOrani = gidaKdv;
                urunAdi = gida[urunNo];
            }
        }
        else if (kategoriNo == 2)
        {
            if (urunNo >= 0 && urunNo < giyim.Length)
            {
                urunFiyat = giyimFiyat[urunNo];
                kdvOrani = giyimKdv;
                urunAdi = giyim[urunNo];
            }
        }
        else if (kategoriNo == 3)
        {
            if (urunNo >= 0 && urunNo < bijuteri.Length)
            {
                urunFiyat = bijuteriFiyat[urunNo];
                kdvOrani = bijuteriKdv;
                urunAdi = bijuteri[urunNo];
            }
        }

        double toplamFiyat = urunFiyat * (1 + kdvOrani);
        Console.Clear(); 
        Console.WriteLine($"Seçilen Ürün: {urunAdi}, Fiyat: {urunFiyat} TL, KDV'li Fiyat: {toplamFiyat} TL");

        while (true)
        {
            Console.WriteLine("Para Giriniz:");
            balance += Convert.ToDouble(Console.ReadLine());

            if (balance >= toplamFiyat)
            {
                Console.Clear(); 
                Console.WriteLine($"Satın Alma Başarılı! Para Üstü: {balance - toplamFiyat} TL");
                balance = 0;
                break;
            }
            else
            {
                Console.WriteLine("Yetersiz Bakiye! 1-Para Ekle\n2-Çıkış");
                string secim = Console.ReadLine();
                if (secim != "1")
                {
                    Console.Clear(); 
                    balance = 0;
                    break;
                }
            }
        }
    }

    internal static void AdminPanel(int kategoriNo)
    {
        Console.WriteLine("Admin Paneli:");
        Console.WriteLine("1-Ürün Ekle\n2-Ürün Güncelle\n3-Ürün Sil");
        string secim = Console.ReadLine();

        if (secim == "1")
        {
            UrunEkle(kategoriNo);
        }
        else if (secim == "2")
        {
            UrunGuncelle(kategoriNo);
        }
        else if (secim == "3")
        {
            UrunSil(kategoriNo);
        }
        else
        {
            Console.Clear(); 
            Console.WriteLine("Hatalı Tuşlama!");
        }
    }

    internal static void UrunEkle(int kategoriNo)
    {
        Console.Clear(); 
        Console.WriteLine("Yeni Ürün Adı:");
        string urunAdi = Console.ReadLine();

        Console.WriteLine("Yeni Ürün Fiyatı:");
        double fiyat = Convert.ToDouble(Console.ReadLine());

        if (kategoriNo == 1)
        {
            Array.Resize(ref gida, gida.Length + 1);
            Array.Resize(ref gidaFiyat, gidaFiyat.Length + 1);
            gida[gida.Length - 1] = urunAdi;
            gidaFiyat[gidaFiyat.Length - 1] = fiyat;
        }
        else if (kategoriNo == 2)
        {
            Array.Resize(ref giyim, giyim.Length + 1);
            Array.Resize(ref giyimFiyat, giyimFiyat.Length + 1);
            giyim[giyim.Length - 1] = urunAdi;
            giyimFiyat[giyimFiyat.Length - 1] = fiyat;
        }
        else if (kategoriNo == 3)
        {
            Array.Resize(ref bijuteri, bijuteri.Length + 1);
            Array.Resize(ref bijuteriFiyat, bijuteriFiyat.Length + 1);
            bijuteri[bijuteri.Length - 1] = urunAdi;
            bijuteriFiyat[bijuteriFiyat.Length - 1] = fiyat;
        }

        Console.Clear(); 
        Console.WriteLine("Ürün Eklendi.");
    }

    internal static void UrunGuncelle(int kategoriNo)
    {
        UrunListele(kategoriNo);

        Console.WriteLine("Güncellenecek Ürün No:");
        int urunNo = Convert.ToInt32(Console.ReadLine());

        if (kategoriNo == 1)
        {
            if (urunNo >= 0 && urunNo < gida.Length)
            {
                Console.WriteLine("Yeni Ürün Adı:");
                string yeniUrunAdi = Console.ReadLine();
                Console.WriteLine("Yeni Ürün Fiyatı:");
                double yeniFiyat = Convert.ToDouble(Console.ReadLine());

                gida[urunNo] = yeniUrunAdi;
                gidaFiyat[urunNo] = yeniFiyat;

                Console.Clear(); 
                Console.WriteLine("Ürün Güncellendi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
        else if (kategoriNo == 2)
        {
            if (urunNo >= 0 && urunNo < giyim.Length)
            {
                Console.WriteLine("Yeni Ürün Adı:");
                string yeniUrunAdi = Console.ReadLine();
                Console.WriteLine("Yeni Ürün Fiyatı:");
                double yeniFiyat = Convert.ToDouble(Console.ReadLine());

                giyim[urunNo] = yeniUrunAdi;
                giyimFiyat[urunNo] = yeniFiyat;

                Console.Clear(); 
                Console.WriteLine("Ürün Güncellendi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
        else if (kategoriNo == 3)
        {
            if (urunNo >= 0 && urunNo < bijuteri.Length)
            {
                Console.WriteLine("Yeni Ürün Adı:");
                string yeniUrunAdi = Console.ReadLine();
                Console.WriteLine("Yeni Ürün Fiyatı:");
                double yeniFiyat = Convert.ToDouble(Console.ReadLine());

                bijuteri[urunNo] = yeniUrunAdi;
                bijuteriFiyat[urunNo] = yeniFiyat;

                Console.Clear(); 
                Console.WriteLine("Ürün Güncellendi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
    }

    internal static void UrunSil(int kategoriNo)
    {
        UrunListele(kategoriNo);

        Console.WriteLine("Silinecek Ürün No:");
        int urunNo = Convert.ToInt32(Console.ReadLine());

        if (kategoriNo == 1)
        {
            if (urunNo >= 0 && urunNo < gida.Length)
            {
                for (int i = urunNo; i < gida.Length - 1; i++)
                {
                    gida[i] = gida[i + 1];
                    gidaFiyat[i] = gidaFiyat[i + 1];
                }
                Array.Resize(ref gida, gida.Length - 1);
                Array.Resize(ref gidaFiyat, gidaFiyat.Length - 1);

                Console.Clear(); 
                Console.WriteLine("Ürün Silindi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
        else if (kategoriNo == 2)
        {
            if (urunNo >= 0 && urunNo < giyim.Length)
            {
                for (int i = urunNo; i < giyim.Length - 1; i++)
                {
                    giyim[i] = giyim[i + 1];
                    giyimFiyat[i] = giyimFiyat[i + 1];
                }
                Array.Resize(ref giyim, giyim.Length - 1);
                Array.Resize(ref giyimFiyat, giyimFiyat.Length - 1);

                Console.Clear(); 
                Console.WriteLine("Ürün Silindi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
        else if (kategoriNo == 3)
        {
            if (urunNo >= 0 && urunNo < bijuteri.Length)
            {
                for (int i = urunNo; i < bijuteri.Length - 1; i++)
                {
                    bijuteri[i] = bijuteri[i + 1];
                    bijuteriFiyat[i] = bijuteriFiyat[i + 1];
                }
                Array.Resize(ref bijuteri, bijuteri.Length - 1);
                Array.Resize(ref bijuteriFiyat, bijuteriFiyat.Length - 1);

                Console.Clear(); 
                Console.WriteLine("Ürün Silindi.");
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Hatalı Ürün Numarası!");
            }
        }
    }
}
}
