List<Kendaraan> data_kendaraan = new List<Kendaraan>()
{
    new Kendaraan("Supra", 400000, "N 6767 B"),


};

class Kendaraan
{
    protected string _namaKendaraan;
    protected double _hargaSewaPerHari;
    protected string _nomorPolisi;
    protected bool IsAvailable;
    public Kendaraan(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi)
    {
        _namaKendaraan = namaKendaraan;
        _hargaSewaPerHari = hargaSewaPerHari;
        _nomorPolisi = nomorPolisi;
        IsAvailable = true; // Kendaraan tersedia secara default
    }

    public string NamaKendaraan
    {
        get { return _namaKendaraan; }
        set { _namaKendaraan = value; }
    }

    public double HargaSewaPerHari
    {
        get { return _hargaSewaPerHari; }
        set 
        { 
            if (value > 0)
            {
                _hargaSewaPerHari = value;
            }

            else
            {
                Console.WriteLine("Harga sewa harus lebih besar dari 0");
            }
        }
    }

    public string NomorPolisi
    {
        get { return _nomorPolisi; }
    }

    public bool IsAvailable1
    {
        get { return IsAvailable; }
    }

    public void tampilkanInfo()
    {
        Console.WriteLine($"Nama Kendaraan: {_namaKendaraan}");
        Console.WriteLine($"Harga Sewa Per Hari: {_hargaSewaPerHari}");
        Console.WriteLine($"Nomor Polisi: {_nomorPolisi}");
        Console.WriteLine($"Ketersediaan: {(IsAvailable ? "Tersedia" : "Tidak Tersedia")}");
    }

    public void ubahstatus ()
    {
        IsAvailable = !IsAvailable; // Mengubah status ketersediaan
    }

    public virtual double hitungTotalsewa(int jumlahHari)
    {
        return _hargaSewaPerHari * jumlahHari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi;

    public Mobil(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi) : base(namaKendaraan, hargaSewaPerHari, nomorPolisi) 
    {
        _biayaAsuransi = 50000;
    }

    public override double hitungTotalsewa(int jumlahHari)
    {
        return base.hitungTotalsewa(jumlahHari) + jumlahHari;
    }
}

class MiniBus : Kendaraan
{
    private double _biayaSopir;

    public MiniBus(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi) : base(namaKendaraan, hargaSewaPerHari, nomorPolisi )
    {
        _biayaSopir = 100000;
    }

    public override double hitungTotalsewa(int jumlahHari)
    {
        return base.hitungTotalsewa(jumlahHari) + _biayaSopir * jumlahHari;
    }
}

