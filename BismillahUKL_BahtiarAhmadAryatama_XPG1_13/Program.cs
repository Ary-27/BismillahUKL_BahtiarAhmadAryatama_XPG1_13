List<Stand> data_stand = new List<Stand>()
{
    new StandOutdoor("Outdoor-1", 400000),
    new StandOutdoor("Outdoor-2", 500000),
    new StandIndoor("Indoor-1", 700000),
    new StandIndoor("Indoor-2", 800000),
    new StandPremium("Premium-1", 1800000),
    new StandPremium("Premium-2", 2000000)
};

while (true)
{
    Console.Clear();

    Console.WriteLine("\n======= MOKLET EXPO MANAGEMENT =======");
    Console.WriteLine("\nDaftar Stand Bazaar Tersedia");

    foreach (var dk in data_stand)
    {
        dk.TampilkanInfo();
    }

    Console.WriteLine("\nPilih Menu: ");
    Console.WriteLine("1. Sewa Stand\n2. Akhiri Sewa\n3. Keluar");
    Console.Write("Pilihan Anda: ");
    string pilihan = Console.ReadLine();

    if (pilihan == "1") // Proses penyewaan stand
    {
        Console.Write("\nInput nama stand: ");
        string namaStand = Console.ReadLine();

        var cari_stand = data_stand.FirstOrDefault(cs => string.Equals(namaStand, cs.NamaStand, StringComparison.OrdinalIgnoreCase));

        if (cari_stand == null)
        {
            Console.WriteLine("\nStand tidak ditemukan");
        }
        else if (cari_stand.IsAvailable)
        {
            Console.Write("\nInput jumlah hari sewa: ");
            int hari = int.Parse(Console.ReadLine());

            double total_sewa = cari_stand.HitungTotal(hari);

            cari_stand.UbahStatus();

            Console.WriteLine($"Total pembayaran sewa: Rp {total_sewa}");
        }
        else
        {
            Console.WriteLine("\nStand sedang tidak tersedia");
        }
    }
    else if (pilihan == "2") // Proses pengembalian stand
    {
        Console.Write("\nInput nama stand: ");
        string namaStand = Console.ReadLine();

        var cari_stand = data_stand.FirstOrDefault(cs => string.Equals(namaStand, cs.NamaStand, StringComparison.OrdinalIgnoreCase));

        if (cari_stand == null)
        {
            Console.WriteLine("\nStand tidak ditemukan");
        }
        else if (cari_stand.IsAvailable)
        {
            cari_stand.UbahStatus();
            Console.WriteLine("\nSewa stand berhasil diakhiri");
        }
        else
        {
            Console.WriteLine("\nProses pengembalian tidak bisa dilakukan");
        }
    }
    else if (pilihan == "3")
    {
        Console.WriteLine("\nTekan E N T E R untuk menutup aplikasi...");
        Console.ReadLine();
        break;
    }
    else
    {
        Console.WriteLine("\nPilihan Invalid!");
    }

    Console.WriteLine("\nTekan E N T E R untuk mengulangi proses...");
    Console.ReadLine();
}

// CLASS STAND
class Stand
{
    protected string _namaStand;
    protected double _hargaSewaPerHari;
    protected bool _isAvailable;

    public Stand(string namaStand, double hargaSewaPerHari)
    {
        _namaStand = namaStand;
        _hargaSewaPerHari = hargaSewaPerHari;
        _isAvailable = true;
    }

    public string NamaStand
    {
        get { return _namaStand; }
        set { _namaStand = value; }
    }

    public double HargaSewaPerHari
    {
        get { return _hargaSewaPerHari; }
        set
        {
            if (value > 0)
                _hargaSewaPerHari = value;
            else
                Console.WriteLine("Harga sewa per hari harus lebih besar dari 0.");
        }
    }

    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public void TampilkanInfo()
    {
        Console.WriteLine($"{NamaStand} | Rp {HargaSewaPerHari} / hari | {(IsAvailable ? "Tersedia" : "Tidak tersedia")}");
    }

    public void UbahStatus()
    {
        _isAvailable = !_isAvailable;
    }

    public virtual double HitungTotal(int jumlahHari)
    {
        return _hargaSewaPerHari * jumlahHari;
    }
}

// CLASS OUTDOOR
class StandOutdoor : Stand
{
    private double _biayaTenda;
    public StandOutdoor(string namaStand, double hargaSewaPerHari) : base(namaStand, hargaSewaPerHari)
    {
        _biayaTenda = 75000;
    }
    public double BiayaTenda
    {
        get { return _biayaTenda; }
    }
    public override double HitungTotal(int jumlahHari)
    {
        return base.HitungTotal(jumlahHari) + (_biayaTenda * jumlahHari);
    }
}

// CLASS INDOOR
class StandIndoor : Stand
{
    private double _biayaListrik;
    public StandIndoor(string namaStand, double hargaSewaPerHari) : base(namaStand, hargaSewaPerHari)
    {
        _biayaListrik = 100000;
    }
    public double BiayaListrik
    {
        get { return _biayaListrik; }
    }
    public override double HitungTotal(int jumlahHari)
    {
        return base.HitungTotal(jumlahHari) + (_biayaListrik * jumlahHari);
    }
}