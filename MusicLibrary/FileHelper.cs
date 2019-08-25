using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MusicLibrary
{
    public static class FileHelper
    {
        public async static void WriteTextFileAsync(string filename, string content)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            
           

            File.AppendAllLines(textFile.Path, new String[] { content });
            // var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);
            // var textReader = new DataReader(textStream);
            /*var textWriter = new DataWriter(textStream);
            
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            var prevContent = textReader.ReadString((uint)textLength);

            textWriter.WriteString(content);
            await textWriter.StoreAsync();
            textWriter.Dispose();*/
        }

        public async static Task<string> ReadTextFileAsync(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }
    }
}
