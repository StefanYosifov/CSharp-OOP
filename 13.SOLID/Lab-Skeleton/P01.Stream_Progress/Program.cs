using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStremable music = new Music("Gosho","Na havaite",100,100);
            StreamProgressInfo stream=new StreamProgressInfo(music);
            int fileSize=stream.CalculateCurrentPercent();
            Console.WriteLine(fileSize);

        }
    }
}
