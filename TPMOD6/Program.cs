using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    // Constructor
    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video tidak boleh kosong dan maksimal 100 karakter.");
        }

        Random random = new Random();
        this.id = random.Next(10000, 99999); // Generate ID 5 digit
        this.title = title;
        this.playCount = 0;
    }

    // Method untuk menambah play count dengan Design by Contract
    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentOutOfRangeException("Jumlah play count harus antara 0 dan 10 juta.");
        }

        try
        {
            checked // Memastikan tidak terjadi overflow
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow saat menambah play count!");
        }
    }

    // Method untuk menampilkan detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID Video: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

// Program Utama
class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – [Reiluthfi Shidqi Wienarya]");

        // Menguji exception handling dengan loop for
        for (int i = 0; i < 10; i++)
        {
            video.IncreasePlayCount(10000000); // 10 juta per iterasi
        }

        video.PrintVideoDetails();
    }
}
