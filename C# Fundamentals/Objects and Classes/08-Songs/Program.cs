using System;
using System.Collections.Generic;

namespace P03Songs
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                //Reading the information about the object
                string[] songArgs = Console.ReadLine().Split('_',StringSplitOptions.RemoveEmptyEntries);

                //Splitting the information of the object to specific characteristics
                Song newSong = new Song()
                { 
                    Name = songArgs[1],
                    Type = songArgs[0],
                    Time = songArgs[2],
                    //The song is saved with info format as in the template above
                };

                songs.Add(newSong);
            }

            string filterValue = Console.ReadLine();

            if (filterValue == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                var filteredSongs = songs.FindAll(x => x.Type == filterValue);

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
