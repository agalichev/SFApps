using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq  ;
using Module11VoiceTexterBot.Extensions;
using Vosk;

namespace Module11VoiceTexterBot.Utilities
{
    public static class SpeechDetector
    {
        public static string DetectSpeech(string audioPath, float inputBitrate, string languageCode)
        {
            Vosk.Vosk.SetLogLevel(0);
            var modelPath = Path.Combine(DirectoryExtension.GetSolutionRoot(), "Speech-models", $"vosk-model-small-{languageCode.ToLower()}");
            Model model = new(modelPath);
            return GetWords(model, audioPath, inputBitrate);
        }

        private static string GetWords(Model model, string audioPath, float inputBitrate)
        {
            VoskRecognizer rec = new(model, inputBitrate);
            rec.SetMaxAlternatives(0);
            rec.SetWords(true);

            StringBuilder textBuffer = new();

            using (Stream source = File.OpenRead(audioPath))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (rec.AcceptWaveform(buffer, bytesRead))
                    {
                        var sentenseJson = rec.Result();
                        JObject sentenseObj = JObject.Parse(sentenseJson);
                        string sentense = (string)sentenseObj["text"];
                        textBuffer.Append(StringExtension.UppercaseFirst(sentense) + ".");
                    }
                }
            }

            var finalSentense = rec.FinalResult();
            JObject finalSentenseObj = JObject.Parse(finalSentense);
            textBuffer.Append((string)finalSentenseObj["text"]);
            return textBuffer.ToString();
        }
    }
}
