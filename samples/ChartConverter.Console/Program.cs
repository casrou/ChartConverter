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

namespace ChartConverter.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                var zipFilePath = args[0];
                await ProcessZipFileAsync(zipFilePath);
                return;
            }

            System.Console.WriteLine("Convert from [z]ip file or BeatSaver request [c]ode?");
            var choice = System.Console.ReadLine();

            switch (choice.ToLower())
            {
                case "z":
                    System.Console.WriteLine("Enter zip-file path:");
                    var zipFilePath = System.Console.ReadLine().Trim('"');
                    await ProcessZipFileAsync(zipFilePath);
                    break;
                case "c":
                    System.Console.WriteLine("Enter BeatSaver request code:");
                    var requestCode = System.Console.ReadLine();
                    await ProcessRequestCodeAsync(requestCode);
                    break;
                default:
                    break;
            }
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

    }
}
