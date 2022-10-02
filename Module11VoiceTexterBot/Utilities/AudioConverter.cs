using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module11VoiceTexterBot.Extensions;
using FFMpegCore;

namespace Module11VoiceTexterBot.Utilities
{
    public static class AudioConverter
    {
        public static void TryConvert(string inputFile, string outputFile)
        {
            GlobalFFOptions.Configure(options => options.BinaryFolder = Path.Combine(DirectoryExtension.GetSolutionRoot(), "ffmpeg-win64", "bin"));
            FFMpegArguments.FromFileInput(inputFile).OutputToFile(outputFile, true, options => options.WithFastStart()).ProcessSynchronously();
        }

        private static string GetSolutionRoot()
        {
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullName = Directory.GetParent(dir).FullName;
            var projectRoot = fullName.Substring(0, fullName.Length - 4);
            return Directory.GetParent(fullName)?.FullName;
        }
    }
}
