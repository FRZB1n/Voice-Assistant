using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
namespace WindowsFormsApp1
{
    internal class dim
    {
        public static string outik;
        // await FromMic();
        public async static Task<string> FromMic()
        {
            var speechConfig = SpeechConfig.FromSubscription("1234be419bb44f5f82e47adcd1798cb0", "eastus");
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            speechConfig.SpeechSynthesisLanguage = "ru-RU";
            speechConfig.SpeechRecognitionLanguage = "ru-RU";


            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);
            //var keyword = Microsoft.CognitiveServices.Speech.KeywordRecognitionModel.FromFile(@"C:\Users\FRZ\Downloads\New Recording.wav");
            //var phraselist = Microsoft.CognitiveServices.Speech.PhraseListGrammar.FromRecognizer(recognizer);
            //phraselist.AddPhrase("start");
            //Form1.speak("а");
            //await recognizer.StartKeywordRecognitionAsync(keyword);
            Console.WriteLine("Speak into your microphone.");

            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine(result.Text);
            outik = result.Text;
            return (outik);
            // FromMic().Dispose();
        }

        #region AmplitudeVoise
        //double[] readAmplitudeValues(bool isBigEndian)
        //{
        //   // rea
        //    int MSB, LSB; // старший и младший байты
        //    byte[] buffer = System.IO.File.ReadAllBytes("C:\\Users\\FRZ\\Desktop\\Record (online-voice-recorder.com).mp3");// читаем данные откуда-нибудь
        //    double[] data = new double[buffer.Length / 2];

        //    for (int i = 0; i < buffer.Length; i += 2)
        //    {
        //        if (isBigEndian) // задает порядок байтов во входном сигнале
        //        {
        //            // первым байтом будет MSB
        //            MSB = buffer[2 * i];
        //            // вторым байтом будет LSB
        //            LSB = buffer[2 * i + 1];
        //        }
        //        else
        //        {
        //            // наоборот
        //            LSB = buffer[2 * i];
        //            MSB = buffer[2 * i + 1];
        //        }
        //        // склеиваем два байта, чтобы получить 16-битное вещественное число
        //        // все значения делятся на максимально возможное - 2^15
        //        data[i] = ((MSB << 8)  ) / 32768;
        //    }

        //    return data;
        //}


        #endregion

        public static async Task speak(string text)
        {
            var config = SpeechConfig.FromSubscription("1234be419bb44f5f82e47adcd1798cb0", "eastus");
            //config.SpeechSynthesisLanguage = "ru-RU";
            config.SpeechSynthesisVoiceName = "ru-RU-DmitryNeural";
            //config.SpeechSynthesisVoiceName = "Male";
            //config.
            var synthesizer = new SpeechSynthesizer(config);
            await synthesizer.SpeakTextAsync(text);
            await synthesizer.StopSpeakingAsync();
        }
        public static async Task<string> listenAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription("1234be419bb44f5f82e47adcd1798cb0", "eastus");
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            // richTextBox1.Text += ("Speak into your microphone.");
            var result = await recognizer.RecognizeOnceAsync();
            return (result.Text);
        }
    }
}
