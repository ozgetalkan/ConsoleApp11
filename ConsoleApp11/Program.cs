namespace ConsoleApp11
{
    internal class Program
    {
        static List<string> isimler = new() { "Ali", "Veli", "Selami", "Ayşe", "Fatma" };
        static List<string> bolumler = new() { "IK", "Satis", "Pazarlama", "Arge", "Satin Alma" };
        static List<Personel> personelListesi = new();
        static List<Musteri> musteriListesi = new();
        static void Main(string[] args)
        {
            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                personelListesi.Add(new() { AdSoyad = isimler[random.Next(isimler.Count)], Departman = bolumler[random.Next(bolumler.Count)] });
            }
            for (int i = 0; i < 10; i++)
            {
                musteriListesi.Add(new() { AdSoyad = isimler[random.Next(isimler.Count)] });
            }
            List<Object> piknikTayfasi = new(); //piknikTayfası boş listesi oluşturduk ve aşağıda içine iki liste attık.
            piknikTayfasi.AddRange(musteriListesi); //önce musteriListesi sonra personel listesi eklenir
            piknikTayfasi.AddRange(personelListesi);
            Yazdir(piknikTayfasi);
        }
        static void Yazdir(List<Object> tayfa)
        {
            foreach (var item in tayfa)
            {
                var x = item as Personel;
                if (x != null)
                {
                    Console.WriteLine(x.AdSoyad);
                }
                else
                {
                    var y = item as Musteri;
                    Console.WriteLine(y.AdSoyad);
                }
            }
            //ya da
            //foreach (var item in tayfa)
            //{
            //    if (item is Personel)
            //    {
            //        Personel personel = (Personel)item;
            //        Console.WriteLine(personel.AdSoyad);
            //    }
            //    else
            //    {
            //        Musteri musteri = (Musteri)item;
            //        Console.WriteLine(musteri.AdSoyad);
            //    }
            //}
        }
        static void MarkajListesiYazdır()
        {
            var markajListesi = musteriListesi.Zip(personelListesi); //Fermuar. musteri ve personel listesini personel gibi birbirine eşler
            foreach (var item in markajListesi)
            {
                Console.WriteLine("{0} - {1}", item.First.AdSoyad, item.Second.AdSoyad);//first ilk liste, second ikinci liste
                Tuple<Personel, Musteri> t; //iki classı birleştirir.
            }
        }
        static void Yazdir2()
        {
            var YeniList = personelListesi.Select(x=> new { AdSoyad = x.AdSoyad, SeksekOynarmı = true }); //newden sonra tipi verilemdiği için anonim tiptedir. class tanımlamadan hızlı şekilde kulllanım sağlar.
            var YeniList2 = personelListesi.Select(x => new PiknikTip { AdSoyad = x.AdSoyad, Seksekoynarmı = true });
            personelListesi.Where(x=>x.Departman=="IK").OrderBy(x=>x.AdSoyad).ToList();
            Console.WriteLine(DateTime.Now.GunSalla(20));
        }
    }
    public static class MyExt
    {
        public static DateTime GunSalla(this DateTime tarih, int MaxGun) //Extension denir. 
        {
            Random r = new();
            return tarih.AddDays(r.Next(MaxGun));
        }
    }
    class YoneticiPersonel //Compperable
    {
        Personel PersonelInfo { get; set; }
        public int ElementSayisi { get; set; }
    }
    class YoneticiPersonel2 : Personel //Inheritance
    {
        public int ElemanSayisi { get; set; }
    }
    class PiknikTip //YeniList2 de Piknik tipinde bir liste oluşturulması için önce piknik tip classı gerekir. 
    {
        public string AdSoyad { get; set; }
        public bool Seksekoynarmı { get; set; }
    }
    class Birlesme //composition = iki classı bir classta birleştirme
    {
        public Personel personel { get; set; }
        public Musteri musteri { get; set; }
    }
    public class Personel
    {
        public string AdSoyad { get; set; }
        public string Departman { get; set; }
    }
    class Musteri
    {
        public string AdSoyad { get; set; }
    }
}