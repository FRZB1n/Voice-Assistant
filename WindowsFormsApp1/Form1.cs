using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.IO;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Threading;
using TL;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = new Icon("ico.ico");
            notifyIcon1.Visible = true;

            //Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        async static Task<string> hui(){
            return "hui";
        }


        private readonly ManualResetEventSlim _codeReady ;
        private WTelegram.Client _client;
        private User _user;
        //useless shit
        static Label l;
        double call1 = 0.0;
        double call2 = 0.0;
        double call3 = 0.0;
        double call4 = 0.0;
        double call5 = 0.0;
        double call6 = 0.0;
        double call7 = 0.0;
        double call8 = 0.0;
        double call9 = 0.0;
        double call10 = 0.0;

        public void algoritm_save_info(double e)
        {
            if (call1 == 0.0)
            {
                call2 = e;
            }
            if (call2 == 0.0)
            {
                call2 = e;
            }
            if (call3 == 0.0)
            {
                call3 = e;
            }
            if (call4 == 0.0)
            {
                call4 = e;
            }
            if (call5 == 0.0)
            {
                call5 = e;
            }
            if (call6 == 0.0)
            {
                call6 = e;
            }
            if (call7 == 0.0)
            {
                call7 = e;
            }
            if (call8 == 0.0)
            {
                call8 = e;
            }
            if (call9 == 0.0)
            {
                call9 = e;
            }
            if (call10 == 0.0)
            {
                call10 = e;
            }

            if(call10 != 0.0)
            {
                double result = (call1 + call2 + call3 + call4 + call5 + call6 + call7 + call8 + call9 + call10) / 10;
                File.WriteAllText("settings/MicrophoneMode.hs", result.ToString());
                call1 = 0.0;
                call2 = 0.0;
                call3 = 0.0;
                call4 = 0.0;
                call5 = 0.0;
                call6 = 0.0;
                call7 = 0.0;
                call8 = 0.0;
                call9 = 0.0;
                call10 = 0.0;
            }

        }

        int call = 0;
        int exitSudos = 0;
        int system = 0;

        public async void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (Directory.Exists("settings/"))
            {
                if (File.Exists("settings/MicrophoneMode.hs"))
                {
                    if(File.Exists("settings/name.hs") == false)
                    {
                        File.WriteAllText("settings/name.hs", "дима");
                    }
                }
                else
                {
                    File.WriteAllText("settings/MicrophoneMode.hs", "0,82");
                }
            }
            else
            {
                Directory.CreateDirectory("settings/");
                File.WriteAllText("settings/MicrophoneMode.hs", "0,82");
                File.WriteAllText("settings/name.hs", "дима");
            }

            string set = File.ReadAllText("settings/MicrophoneMode.hs");
            string name = File.ReadAllText("settings/MicrophoneMode.hs");
            if (e.Result.Confidence > 0.8)//its a regular number, but u can calculate this number by calls 0-n
            {
                if (e.Result.Text == File.ReadAllText("settings/name.hs"))
                {
                    //Visible = true;
                   // TopMost = true;
                    await dim.speak("Слушаю");
                    call = 1;
                }
                else
                {
                    if (exitSudos == 1)
                    {
                        //l.Text = e.Result.Text + "\n" + e.Result.Confidence;
                        algoritm_save_info(e.Result.Confidence);
                        await obr(e.Result.Text);
                        call = 0;
                        Visible = false;
                    }
                    if (system == 1)
                    {
                        //l.Text = e.Result.Text + "\n" + e.Result.Confidence;
                        algoritm_save_info(e.Result.Confidence);
                        await obr(e.Result.Text);
                        call = 0;
                        Visible = false;
                    }
                    if (call == 1)
                    {
                        //l.Text = e.Result.Text + "\n" + e.Result.Confidence;
                        algoritm_save_info(e.Result.Confidence);
                        await obr(e.Result.Text);
                        call = 0;
                        Visible = false;
                    }
                }
            }
        }

        string cmdSys = "";

        private async Task obr(string name)
        {
            string[] comand = File.ReadAllLines("settings/Commands.hs");
            using (StreamReader sr = new StreamReader("settings/Commands.hs"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    //easy 4 understand
                    string[] stroka = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (stroka[0] == name)
                    {
                        if (stroka[1] == "open")
                        {
                            await dim.speak("Открываю");
                            if (stroka[2] == "discord")
                            {

                                string userName = Environment.UserName;
                                string[] dirs = Directory.GetDirectories("C:\\Users\\" + userName + "\\AppData\\Local\\Discord", "app*");
                                string ds = dirs[dirs.Length - 1] + "\\Discord.exe";
                                Process.Start(ds);
                                break;
                            }
                            if (stroka[2] == "csgo")
                            {

                                string ouko;
                                if (Directory.Exists("C:\\Program Files(x86)\\Steam\\"))
                                    ouko = ("C:\\Program Files(x86)\\Steam\\steam.exe");
                                else
                                    ouko = ("D:\\Steam\\steam.exe");
                                Process pr = new Process();
                                pr.StartInfo = new ProcessStartInfo()
                                {

                                    FileName = ouko,
                                    Arguments = "steam://rungameid/730",
                                    UseShellExecute = false,
                                };
                                pr.Start();
                                break;
                            }
                            if (stroka[2] == "faceitclient.exe")
                            {

                                Process.Start("D:\\FACEIT AC\\faceitclient.exe");
                                break;
                            }
                            if (stroka[2] == "telegramm")
                            {
                                string[] c = Directory.GetDirectories("C:\\", "Telegra*");
                                if (c.Length > 0)
                                    Process.Start("C:\\Telegram Desktop\\Telegram.exe");

                                string[] E = { };
                                string[] d = { };
                                if (Directory.Exists("D:\\"))
                                {
                                    d = Directory.GetDirectories("D:\\", "Telegram Desktop");
                                    if (d.Length > 0)
                                        Process.Start("D:\\Telegram Desktop\\Telegram.exe");

                                }
                                if (Directory.Exists("E:\\"))
                                {
                                    E = Directory.GetDirectories("E:\\", "Telegra*");
                                    if (E.Length > 0)
                                        Process.Start("E:\\Telegram Desktop\\Telegram.exe");
                                }
                                break;
                            }
                            if (stroka[2] == "steam")
                            {

                                if (Directory.Exists("C:\\Program Files(x86)\\Steam\\"))
                                    Process.Start("C:\\Program Files(x86)\\Steam\\steam.exe");
                                else
                                    Process.Start("D:\\Steam\\steam.exe");
                                break;

                            }

                            Process.Start(stroka[2]);

                            break;
                        }
                        if (stroka[1] == "close")
                        {
                            await dim.speak("Закрываю");
                            try
                            {
                                foreach (Process proc in Process.GetProcessesByName(stroka[2]))
                                {
                                    proc.Kill();
                                }
                            }
                            catch//hehe
                            {
                                foreach (Process proc in Process.GetProcessesByName(stroka[2]))
                                {//DO NOT WORK
                                    proc.Close();
                                    proc.Kill();
                                }
                            }
                            call = 0;
                            break;
                        }
                        if (stroka[1] == "hello")
                        {
                            await dim.speak("Здравствуйте");
                            break;
                        }
                        if (stroka[1] == "name")
                        {
                            await dim.speak("Я робот по имени " + File.ReadAllText("settings/name.hs") + ". Вы можете называть меня как угодно и я буду отзываться! Если хотите меня переименовать, то скажите 'новое имя'");
                            break;
                        }
                        if (stroka[1] == "learnName")
                        {
                            await dim.speak("Здравствуйте");
                            break;
                        }
                        if (stroka[1] == "learnName")
                        {
                            await dim.speak("Здравствуйте");
                            break;
                        }
                        if (stroka[1] == "exitSudo")
                        {
                            await dim.speak("Вы действительно этого хотите?");
                            call = 1;
                            exitSudos = 1;
                            break;
                        }
                        if (stroka[1] == "exitSudoYes" && exitSudos == 1)
                        {
                            await dim.speak("Как жаль. Выключаюсь");

                            Process.GetCurrentProcess().Kill();
                        }
                        if (stroka[1] == "exitSudoNo" && exitSudos == 1)
                        {
                            await dim.speak("Я буду ждать пока вы не позовете меня");
                            exitSudos = 0;
                            call = 0;
                            break;
                        }
                        if (stroka[1] == "cmd")
                        {
                            await dim.speak("Вы действительно этого хотите?");
                            system = 1;
                            cmdSys = stroka[2];
                            break;
                        }
                        if (stroka[1] == "exitSudoYes" && system == 1 && cmdSys != "")
                        {
                            await dim.speak("Выполняю");
                            Process.Start("cmd", cmdSys);
                            break;
                        }
                        if (stroka[1] == "exitSudoNo" && system == 1)
                        {
                            await dim.speak("Отменяю действие");
                            cmdSys = "";
                            system = 0;
                            break;
                        }
                        if (stroka[1] == "aboutyou")
                        {
                            await dim.speak("Меня создал один очень умный программист по имени FRZ");
                            break;
                        }
                        if (stroka[1] == "google")
                        {
                            //speak("что загуглить");
                            //Thread.Sleep(100);

                            var cer = await dim.FromMic();

                            await dim.speak("Ищу " + cer);

                            Process.Start("https://www.google.ru/search?q=" + cer);
                            //string hyt =  await Parserik.ParseAnsAsync("https://www.google.ru/search?q=" + cer);

                            string hyt = await parser.ParseAnsAsync("https://www.google.ru/search?q=" + cer);
                            await dim.speak(hyt);



                            //dim.speak(Parserik.ParseAns("https://yandex.ru/search/?text=" + cer));
                            break;
                        }
                        if (stroka[1] == "cmdPlusText")
                        {

                            var cer = await dim.FromMic();


                            Process.Start("https://www.youtube.com/results?search_query=" + cer);

                            break;
                        }
                        if (stroka[1] == "TGBOT")
                        {
                            //For this u must to ceate a group with ur bot cause TLSharp is shit
                            var msg = await dim.FromMic();//getting some speach stuff

                            var chats = await _client.Messages_GetAllChats(null);//getting all chats
                            ChatBase hui = null; 
                            foreach (var chat in chats.chats.Values)
                                if (chat.IsActive && chat.Title == "RedBott")
                                {
                                    hui = chat;
                                }

                            //I cant understand how it works, but after a lot of tryes its working


                            var users = hui is Channel channel
                            ? (await _client.Channels_GetAllParticipants(channel)).users
                            : (await _client.Messages_GetFullChat(hui.ID)).users;
                            //listBox.Items.Clear();
                            foreach (var user in users.Values)
                            {
                                if(user.username == "BOT_NAME")//UR BOT NAME
                                {
                                    if (!string.IsNullOrEmpty(msg))
                                    {
                                        // msg = "_Here is your *saved message*:_\n" + Markdown.Escape(msg);
                                        var entities = _client.MarkdownToEntities(ref msg);//TL Shit
                                        await _client.SendMessageAsync(user, msg, entities: entities);
                                    }
                                }
                            }








                            break;

                        }


                    }
                }
            }
        }

        private void speak(string text)
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            speaker.Rate = 1;
            speaker.Volume = 100;
            speaker.Speak(text);
        }
        string Config(string what)
        {
            switch (what)
            {
                case "api_id": return "ID";
                case "api_hash": return "HASH";
                case "phone_number": return "+PHONE NUMBER";
                case "verification_code":
                case "password":
                    BeginInvoke(new Action(() => CodeNeeded(what.Replace('_', ' '))));
                    //_codeReady.Reset();
                    //_codeReady.Wait();
                    return "CODE";
                //Thread.Sleep(1000);
                default: return null;
            };
        }
        private void CodeNeeded(string what)
        {
            //heh
        }
        private  void backgroundWorker1_DoWork(object sender, EventArgs e)
        {
           
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            Visible = false;
            //THIS PART IS FOR WORKING WITH TG BOT, DEL THAT SHIT
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:96.0) Gecko/20100101 Firefox/96.0");
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                client.UseDefaultCredentials = true;
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.DownloadFile(@"url", "D:\\kio\\Telebot.exe");
            }
            Process.Start("D:\\kio\\Telebot.exe");
            // buttonLogin.Enabled = false;
            // listBox.Items.Add($"Connecting & login into Telegram servers...");
            _client = new WTelegram.Client(Config);
            _user = await _client.LoginUserIfNeeded();
            // panelActions.Visible = true;
            // listBox.Items.Add($"We are now connected as {_user}");

           


            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


            Choices numbers = new Choices();
            string[] comand = File.ReadAllLines("settings/Commands.hs");
            using (StreamReader sr = new StreamReader("settings/Commands.hs"))
            {
                String line;
                while ((line = sr.ReadLine()) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
                {
                    string[] stroka = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    numbers.Add(new string[] { stroka[0] });
                }
            }

            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            numbers.Add(new string[] { File.ReadAllText("settings/name.hs") });
            gb.Append(numbers);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);

            
        }

        private void Label2_Click(object sender, EventArgs e)
        {

            Process.GetCurrentProcess().Kill();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {




        }






        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.Visible = true; /* покажем форму */
            notifyIcon1.Visible = false; /* скроем икону в трее */
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Visible = false; /* скроем форму */
            notifyIcon1.Visible = true; /* покажем икону в трее */

        }
    }
}
