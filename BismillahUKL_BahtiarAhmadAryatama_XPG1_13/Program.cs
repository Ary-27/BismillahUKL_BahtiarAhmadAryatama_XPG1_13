List<Stand> data_stand = new List<Stand>()
{
    new Outdoor("Outdoor-1", 400000, ""),
    new Outdoor("Outdoor-2", 500000, ""),
    new Indoor("Indoor-1", 700000, ""),
    new Indoor("Indoor-2", 800000, ""),
    new Premium("Premium-1", 1800000, ""),
    new Premium("Premium-2", 2000000,"")
};

while (true)
{
    Console.Clear();

    Console.WriteLine("\n======= MOKLET EXPO MANAGEMENT CENTER =======");
    Console.WriteLine("\nDaftar Stand Tersedia");

    foreach (var dk in data_stand)
    {
        dk.tampilkanInfo();
    }

    Console.WriteLine("\nPilih Menu: ");
    Console.WriteLine("1. Sewa\n2. Kembali\n3. Keluar");
    Console.Write("Pilihan Anda: ");
    string pilihan = Console.ReadLine();

    if (pilihan == "1")
    {
        Console.Write("\nInput Jenis Stand: ");
        string namaStand = Console.ReadLine();

        var cari_stand = data_stand.FirstOrDefault(ck => string.Equals(namaStand, ck.NamaStand, StringComparison.OrdinalIgnoreCase));

        if (cari_stand == null)
        {
            Console.WriteLine("\nStand tidak ditemukan!");
        }
        else if (cari_stand.IsAvailable)
        {
            Console.WriteLine("\nInput jumlah hari sewa: ");
            int hari = int.Parse(Console.ReadLine());

            double total_sewa = cari_stand.hitungtotal(hari);

            cari_stand.ubahstatus();

            Console.WriteLine($"Total pembayaran sewa: Rp {total_sewa}");
        }
        else
        {
            Console.WriteLine("\nStand tidak tersedia!");
        }
    }
    else if (pilihan == "2")
    {
        Console.Write("\nInput Jenis Stand: ");
        string namaKendaraan = Console.ReadLine();

        var cari_stand = data_stand.FirstOrDefault(ck => string.Equals(namaKendaraan, ck.NamaStand, StringComparison.OrdinalIgnoreCase));

        if (cari_stand == null)
        {
            Console.WriteLine("\nStand tidak ditemukan");
        }
        else if (!cari_stand.IsAvailable)
        {
            cari_stand.ubahstatus();
            Console.WriteLine("\nStand berhasil dikembalikan");
        }
        else
        {
            Console.WriteLine("\nStand pengembalian tidak bisa dilakukan");
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