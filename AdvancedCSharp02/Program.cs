
// Koleksion yapısından devam edelim
// ArrayList

using AdvancedCSharp02;
using System.Collections;
using System.Data.SqlTypes;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Program {
  public static void Main(string[] args)
  {
    #region ObjectType
    // ObjectType();
    #endregion

    #region Collections
    // ArrayListSample();
    // DictionaryType();
    // HashSet();
    #endregion

    #region RecordType
    RecordSample();
    #endregion
  }

  public static void ObjectType()
  {
    int a = 5;
    int b = 10;

    a = b;
    b = 15;


    Sample s = new Sample();
    s.Name = "Örnek-1";

    int h1 = s.GetHashCode();
    Type t1 = s.GetType();

    Sample s1 = new Sample();
    s1.Name = "Örnek-1";
    Type t2 = s1.GetType();

    // bir referans type c# da başka bir referans type eşitlersek
    // her iki referance type ramde aynı noktayı point edecektir. Bu sebeple referans değişimlerin 2 objede bu değişdem etkilenecektir. 
    s = s1;
    s.Name = "Örnek5";

    var s3 = s.getClone(); // bir sınıfın clone aldık ama referanslarını kopararak bu işlemi yapmış.
    s3.Name = "Örnek3";

    // aşağıdaki 3 ifade de referans type bakar.
    bool valueEqual = s1.Equals(s);
    bool refValueEqual = Object.ReferenceEquals(s1, s); // s1 ile s referans olarak birbirine eşit mi (statik sınıf olduğu için 2 farklı sınıf instance referans olarak kontrol ettik.)

    bool valueEqual2 = Object.Equals(s1, s);

    int h2 = s1.GetHashCode();
    int h3 = s.GetHashCode();
  }

  // Net 2.0 beri kullanılıyor
  public static void ArrayListSample()
  {
    object a = 1;
    object b = 1.5; // float, double yada decimal
    object c = "Ali";
    object d = 'f';
    object e = new Sample();
    object f = true;
    object g = new List<Sample>();
    object h = new Sample[5];

    // farklı tipde değerleri bir kolleksiyon içinde tutmak için kullanılır

    // Dizi mantıklı kullandığımız bir koleksiyon tipi
    // heterojen olması, farklı tipde değerleri saklayabilir.
    // ArrayList içerisindeki item değerleri object tipinde yazılmış.

    // HahsSet, Dictionary, List gibi tiplerin atası olarak düşünebiliriz.

    ArrayList alist = new ArrayList(5);
    alist.Add(a);
    alist.Add(g);
    alist.Add(h);

    alist.Clear();
    int count = alist.Count;
    alist.RemoveAt(1);
    alist.Remove(a);

    foreach (var item in alist)
    {

    }

  }

  public static void DictionaryType()
  {
    // key value pair çalışan bir tip

    Dictionary<int, string> dlist = new Dictionary<int, string>();
    dlist.Add(0, "Sıfır");
    dlist.Add(1, "Bir");

    Dictionary<string, string> dlist2 = new Dictionary<string, string>();
    dlist2.Add("hello", "merhaba");

    IDictionary<string, int> dlist3 = new Dictionary<string, int>();
    dlist3.Add("ali", 90);
    dlist3.Add("mustafa", 50);


    IDictionary<string, Sample>  ss = new Dictionary<string, Sample>();
    ss.Add("s1", new Sample());

    // key unique olmak zorunda

    //dlist3.Add("ali", 67);

    string[] keys = dlist3.Keys.ToArray();
    int[] values = dlist3.Values.ToArray();

    bool isExist = dlist3.ContainsKey("ali");

    dlist3.Remove("mustafa"); // keyden remove , value dan değer silme işlemleri yok.

    // içinde keyValuePair olarak bir kayıt var mı?
    dlist3.Contains(new KeyValuePair<string, int>("ali", 2));

  }

  public static void HashSet()
  {

    // Generic List Foreach blogu
    var l = new List<Sample>();

    // JS deki callback
    l.ForEach(a =>
    {
      int c = 0;

      if(a.Name == "Ali")
      {
        c++;
      }

    });

    // Yaygın kullanımı olan bir collection
    // Hashte atılan nesne'nin değerleri unique olmalıdır. Aynı nesneyi bu tip içerisinde tutamayız.

    HashSet<Sample> hList = new HashSet<Sample>();
    var s = new Sample { Name = "Örnek-1" };
    hList.Add(s); // Generic List gibi çalışan bir tip
    hList.Add(s); // aynı nesnenin liste içerisinde girişini engeller.

    // EF new HashSet<Product>();

    hList.Remove(s);
    hList.Any(x => x.Name == "Örnek-1");

  }

  // C# 9.0 ile hayatımıza girdi. Record Type class vari kullanımlar benzer bir yapıya sahip en büyük fark. Record Value Type Object değerler için çıkarılmış bir tip. 
  // record Type
  // Entity Id sahip olmak zorunda ve Database tarafında verilerin program tarafına çekilmesi ile ilgiliniyor. Class Mutable bir type
  // Record Type Immutable => Immutable Type contructor aşamasında değer alır bir daha da bu değerleri değiştirilemez. Bu sebeple Record tipi Immutable olarak çıkmıştır. Record nesneleri Id alanı içermez. Record nesnelerinde referans eşitliğine bakılmaz. Sadece Değer eşitliğine bakılır. 

  public record Location
  {
    public Location(string latitude, string longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }

    public string Latitude { get; init; } // Enlem
    public string Longitude { get; init; } // Boylam

  }

  public class LocationClass
  {
    public LocationClass(string latitude, string longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }

    public string Latitude { get; init; } // Enlem
    public string Longitude { get; init; } // Boylam
  }

  public class Cart
  {
    public string Currency { get; set; }
    public decimal Price { get; set; }

    
    public Money money { get; set; } // Sepetteki Para Nesnesi
    // class içinde record kullanılır, fakat record içinde class kullanmıyoruz.

  }

  // DTO olarak da kullanılabilir. DTO to Entity Mapping, AutoMapper
  public record Money
  {
    public string Currency { get; init; }
    public decimal Amount { get; init; }
    public override string ToString()
    {
      return $"{Amount} {Currency}";
    }
  }

  public static void RecordSample()
  {
    var l1 = new Location("10.15", "25.51"); // Immutable yaptık
    var l2 = new Location("15.3", "23.4");
    var l3 = new Location("15.3", "23.4");

    var equal = l1.Equals(l2); // bu kıyaslama latitude ve longitude değerlerinin ikisinde eşitliğine bakacak

    var equal2 = l3.Equals(l2);

    var money1 = new Money { Currency = "TL", Amount = 10 };
    var money2 = new Money { Currency = "$", Amount = 10 };

    string m1 =  money2.ToString();


    // DDD Domain Güdümle Uygulama Geliştirme

    //var l4 = new LocationClass("10.1","15.4");
    //var l5 = new LocationClass("10.1", "15.4");

    //if(l4.Latitude == l5.Latitude && l4.Longitude == l5.Longitude)
    //{

    //}

    //var equals3 = l4.Equals(l5);

  }

  // c# 7.0 ile birlikte hatayımıza girdi. birden fazla değeri tek bir yapı içerisinde kullandığımız özel bir veri tipi
 
  public static void TuppleSample()
  {
    // class gibi bir tip değil
    // blok düzeyinde tanımlanan, değişkenlerimiz bir container içerisinde erişmize olanak sağlayn bir tip.

    // 1. tanımlama şekli
    var address = ("İstanbul", "34500", "Üsküdar");

    Console.WriteLine($"{address.Item1},{address.Item2}, {address.Item3}");

    string city =  getAddressInfo().city;
    string zipCode = getAddressInfo().zipCode;
    string state = getAddressInfo().state;

    // ikinci tanımla şekli
    var t = Tuple.Create<string, int, string>("a",1,"a");

    var t2 = Tuple.Create<Sample, Location, Money>(new Sample(), new Location("10.4", "4.5"), new Money { Amount = 10, Currency = "$"});

    // Net Core MVC return sadece tek model gönderim yapılıyor.



  }

  static (string city, string zipCode, string state) getAddressInfo()
  {
    return ("İstanbul", "34500", "Üsküdar");
  }

}






// Tupple
// Record
// Regular Expression
// Event Delegate
// Extension Class
// HashSet
// Dictionary
// ArrayList
// Serialization
// FileStream işlemleri System.IO


