using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChartConverter.Core;

namespace ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                var zipFilePath = args[0];
                if (IsValidZipFilePath(zipFilePath))
                    await ProcessZipFileAsync(zipFilePath);
                else 
                    Console.WriteLine("Invalid file path.");                
                return;
            }

            Console.WriteLine("Convert from [z]ip file or BeatSaver request [c]ode?");
            var choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "z":
                    Console.WriteLine("Enter zip-file path:");
                    var zipFilePath = Console.ReadLine();
                    if (IsValidZipFilePath(zipFilePath))
                        await ProcessZipFileAsync(zipFilePath);
                    else
                        Console.WriteLine("Invalid file path.");
                    break;
                case "c":
                    Console.WriteLine("Enter BeatSaver request code:");
                    var requestCode = Console.ReadLine();
                    await ProcessRequestCodeAsync(requestCode);
                    break;
                default:
                    Console.WriteLine("Not a valid choice..");
                    break;
            }

            Console.WriteLine("Press any key to exit."); Console.ReadKey();
        }

        private static async Task ProcessRequestCodeAsync(string requestCode)
        {
            var converter = new BeatSaberToCloneHeroConverter(ConverterConfig.GetDefault());
            var stream = await converter.GetBeatSaverStreamFromRequestCode(requestCode);
            var bytesAndFileName = await converter.GenerateCloneHeroZipStreamFromBeatSaberZipStream(stream);
            File.WriteAllBytes($"{bytesAndFileName.FileName}", bytesAndFileName.Data);
        }

        private static async Task ProcessZipFileAsync(string zipFilePath)
        {
            var converter = new BeatSaberToCloneHeroConverter(ConverterConfig.GetDefault());
            CloneHeroDto bytesAndFileName = await converter.GenerateCloneHeroZipBytesFromBeatSaberZipFile(zipFilePath);
            File.WriteAllBytes($"{bytesAndFileName.FileName}", bytesAndFileName.Data);
        }

        private static bool IsValidZipFilePath(string zipFilePath)
        {
            var trimmedPath = zipFilePath.Trim('"');
            return File.Exists(trimmedPath);
        }
    }
}
