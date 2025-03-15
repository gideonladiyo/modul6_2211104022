using System;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul tidak boleh null atau kosong");
        if (string.IsNullOrEmpty(title)) throw new ArgumentException("Judul tidak boleh null atau kosong");

        Debug.Assert(title.Length < 200, "Judul tidak boleh lebih dari 200 karakter");
        if (title.Length > 200) throw new ArgumentException("Judul tidak boleh lebih dari 200 karakter");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count) 
    {
        Debug.Assert(count > 0 && count <= 25000000, "Count harus lebih dari 0 dan maksimal 25.000.000");
        if (count < 0 && count > 25000000) throw new ArgumentException("Count harus lebih dari 0 dan maksimal 25.000.000");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("⚠ Overflow terjadi! Play count tidak dapat ditambahkan.");
        }
    }

    public void PrintVideoDetail()
    {
        Console.WriteLine($"ID: {id}, Title: {title}, Play Count {playCount}");
    }

    public String GetTitle() => title;

    public int GetPlayCount() => playCount;
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadesVideo;

    public SayaTubeUser(string username)
    {
        Debug.Assert(!string.IsNullOrEmpty(username), "Username tidak boleh null atau kosong");
        if (string.IsNullOrEmpty(username)) throw new ArgumentException("Username tidak boleh null atau kosong");

        Debug.Assert(username.Length <= 100, "Username tidak boleh lebih dari 100 karakter");
        if (username.Length > 100) throw new ArgumentException("Username tidak boleh lebih dari 100 karakter");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.username = username;
        this.uploadesVideo = new List<SayaTubeVideo>();
    }

    public void addVideo(SayaTubeVideo video)
    {
        if (video == null) throw new ArgumentException("Video tidak boleh null");

        if (video.GetPlayCount() >= int.MaxValue)
        {
            throw new ArgumentException("Video play count tidak boleh mencapai batas maksimum integer.");
        }

        uploadesVideo.Add(video);
    }

    public int TotalPlayCount()
    {
        int totalPlayCount = 0;
        foreach (var video in uploadesVideo)
        {
            totalPlayCount += 1;
        }
        return totalPlayCount;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {username}");
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine($"Video {i + 1}: {uploadesVideo[i].GetTitle()}");
        }
    }

    public string GetUsername() => username;
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Gideon");
            List<String> animeTitles = new List<String>
            {
                "Attack on Titan",
                "Demon Slayer",
                "One Piece",
                "Naruto",
                "Jujutsu Kaisen",
                "Death Note",
                "Fullmetal Alchemist: Brotherhood",
                "My Hero Academia",
                "Spy x Family",
                "Chainsaw Man"
            };

            foreach (string title in animeTitles)
            {
                Console.WriteLine($"Review Anime {title} oleh {user.GetUsername()}");
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.addVideo(video);
            }

            Console.WriteLine("\n");
            SayaTubeVideo testVideo = new SayaTubeVideo("Tes overflow");
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    testVideo.IncreasePlayCount(25000000);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
            Console.WriteLine("\n");
            user.PrintAllVideoPlaycount();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan umum: {ex.Message}");
        }
    }
}