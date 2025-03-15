using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0) throw new ArgumentException("Can't be negative");
        playCount += count;
    }

    public void PrintVideoDetail()
    {
        Console.WriteLine($"ID: {id}, Title: {title}, Play Count {playCount}");
    }

    public String GetTitle()
    {
        return title;
    }
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadesVideo;

    public SayaTubeUser(string username)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.username = username;
        this.uploadesVideo = new List<SayaTubeVideo>();
    }

    public void addVideo(SayaTubeVideo video)
    {
        if (video == null) throw new ArgumentException("Video tidak boleh null");
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
        int index = 1;
        foreach (var video in uploadesVideo)
        {
            Console.WriteLine($"Video {index}: {video.GetTitle()}");
            index++;
        }
    }

    public string GetUsername()
    {
        return username;
    }
}

class Program
{
    static void Main()
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
        user.PrintAllVideoPlaycount();
    }
}