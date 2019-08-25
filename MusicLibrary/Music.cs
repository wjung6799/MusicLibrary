using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace MusicLibrary
{
    public class Music
    {
        private const string TEXT_FILE_NAME = "Songs.txt";
        public string Name { get; set; }
        public string Title { get; set; }
        public string CoverPhotoURI { get; set; }
        public string YoutubeURI { get; set; }

        public static void InitList()
        {
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, "");
        }

        public static void WriteSong(Music music)
        {
            var MusicData = $"{music.Name},{music.Title},{music.CoverPhotoURI}, {music.YoutubeURI}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, MusicData);
        }

        public async static Task<ICollection<Music>> GetMusicsAsync()
        {
            var songs = new List<Music>();
            var content = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = content.Split('\r', '\n');
            for (var i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                var lineParts = lines[i].Split(',');
                var music = new Music
                {
                    Name = lineParts[0],
                    Title = lineParts[1],
                    CoverPhotoURI = lineParts[2],
                    YoutubeURI = lineParts[3]
                };
                songs.Add(music);
            }

            return songs;
        }

        // Defining the hash function 
        static int HashFunction(string s)
        {
            int total = 0;
            char[] c;
            c = s.ToCharArray();

            // Summing up all the ASCII values  
            // of each alphabet in the string 
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total;
        }
    }
}
