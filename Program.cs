class Program
{
    static void Main()
    {
        List<Kendaraan> data_kendaraan = new List<Kendaraan>()
        {
            new Kendaraan("Supra", 400000, "N 6767 B"),
            new Kendaraan("F1zr", 450000, "N 0911 L"),
            new Mobil("Civic", 3000000, "N 1234 M"),
            new Mobil("Pajero", 2000000, "N 4567 O"),
            new MiniBus("Elf", 4000000, "N 4511 P"),
            new MiniBus("HiAce", 4500000, "N 1123 Q")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== RAJA RENTAL ====");
            Console.WriteLine("\nDaftar Kendaraan:");

            foreach (var dk in data_kendaraan)
            {
                dk.TampilkanInfo();
            }

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Sewa Kendaraan");
            Console.WriteLine("2. Kembalikan Kendaraan");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                ProsesSewa(data_kendaraan);
            }
            else if (pilihan == "2")
            {
                ProsesKembali(data_kendaraan);
            }
            else if (pilihan == "3")
            {
                Console.WriteLine("\nTerima kasih!");
                break;
            }
            else
            {
                Console.WriteLine("\nPilihan tidak valid");
                Console.ReadLine();
            }
        }
    }

    static Kendaraan CariKendaraan(List<Kendaraan> data)
    {
        Console.Write("\nInput nama kendaraan: ");
        string nama = Console.ReadLine();

        return data.FirstOrDefault(k => string.Equals(nama, k.NamaKendaraan, StringComparison.OrdinalIgnoreCase));
    }

    static void ProsesSewa(List<Kendaraan> data)
    {
        var kendaraan = CariKendaraan(data);

        if (kendaraan == null)
        {
            Console.WriteLine("Kendaraan tidak ditemukan");
        }
        else if (kendaraan.IsAvailable)
        {
            Console.Write("Jumlah hari sewa: ");
            if (int.TryParse(Console.ReadLine(), out int hari))
            {
                double total = kendaraan.HitungTotalSewa(hari);
                kendaraan.UbahStatus();

                Console.WriteLine($"Total bayar: Rp {total:N0}");
            }
            else
            {
                Console.WriteLine("Input harus angka!");
            }
        }
        else
        {
            Console.WriteLine("Kendaraan tidak tersedia");
        }

        Console.ReadLine();
    }

    static void ProsesKembali(List<Kendaraan> data)
    {
        var kendaraan = CariKendaraan(data);

        if (kendaraan == null)
        {
            Console.WriteLine("Kendaraan tidak ditemukan");
        }
        else if (!kendaraan.IsAvailable)
        {
            kendaraan.UbahStatus();
            Console.WriteLine("Berhasil dikembalikan");
        }
        else
        {
            Console.WriteLine("Kendaraan belum disewa");
        }

        Console.ReadLine();
    }
}

class Kendaraan
{
    protected string _namaKendaraan;
    protected double _hargaSewaPerHari;
    protected string _nomorPolisi;
    protected bool _isAvailable;

    public Kendaraan(string nama, double harga, string nopol)
    {
        _namaKendaraan = nama;
        _hargaSewaPerHari = harga;
        _nomorPolisi = nopol;
        _isAvailable = true;
    }

    public string NamaKendaraan => _namaKendaraan;
    public double HargaSewaPerHari => _hargaSewaPerHari;
    public string NomorPolisi => _nomorPolisi;
    public bool IsAvailable => _isAvailable;

    public virtual void TampilkanInfo()
    {
        Console.WriteLine($"\n{_namaKendaraan} | Rp {_hargaSewaPerHari:N0}/hari | {_nomorPolisi} | {(IsAvailable ? "Tersedia" : "Tidak tersedia")}");
    }

    public void UbahStatus()
    {
        _isAvailable = !_isAvailable;
    }

    public virtual double HitungTotalSewa(int hari)
    {
        return _hargaSewaPerHari * hari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi = 50000;

    public Mobil(string nama, double harga, string nopol)
        : base(nama, harga, nopol) { }

    public override double HitungTotalSewa(int hari)
    {
        return base.HitungTotalSewa(hari) + _biayaAsuransi;
    }
}

class MiniBus : Kendaraan
{
    private double _biayaSopir = 100000;

    public MiniBus(string nama, double harga, string nopol)
        : base(nama, harga, nopol) { }

    public override double HitungTotalSewa(int hari)
    {
        return base.HitungTotalSewa(hari) + (_biayaSopir * hari);
    }
}