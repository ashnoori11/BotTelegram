using FarhangBot.SaveDataExtentions;
using FarhangBot.StringExtentions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace FarhangBot
{
    public partial class Form1 : Form
    {
        static string Token = "";
        private Thread BotThraed;
        private Telegram.Bot.TelegramBotClient bot;
        private ReplyKeyboardMarkup mainKeyBoard;
        string answer = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtToken.Text))
            {
                Token = txtToken.Text;
                try
                {
                    BotThraed = new Thread(new ThreadStart(RunBot));
                    BotThraed.Start();
                    if (BotThraed.IsAlive || BotThraed.IsBackground)
                    {
                        btnStart.Enabled = false;
                        btnPhoto.Enabled = true;
                        btnSelectFile.Enabled = true;
                        btnSend.Enabled = true;
                        btnSendPhoto.Enabled = true;
                        btnVideo.Enabled = true;
                        btnSendText.Enabled = true;
                        btnSendVideo.Enabled = true;
                    }
                }
                catch
                {
                    btnStart.Enabled = true;
                    btnPhoto.Enabled = false;
                    btnSelectFile.Enabled = false;
                    btnSend.Enabled = false;
                    btnSendPhoto.Enabled = false;
                    btnVideo.Enabled = false;
                    btnSendText.Enabled = false;
                    btnSendVideo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("لطفا ابتدا توکن را وارد نمایید و سپس بعد از آن بر روی استارت کلیک کنید .");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (btnStart.Enabled == true)
            {
                btnPhoto.Enabled = false;
                btnSelectFile.Enabled = false;
                btnSend.Enabled = false;
                btnSendPhoto.Enabled = false;
                btnVideo.Enabled = false;
                btnSendText.Enabled = false;
                btnSendVideo.Enabled = false;
            }

            KeyboardButton[] rowOne =
            {
                 new KeyboardButton("نظرسنجی"+" "+"\U0001F4A1")
            };

            KeyboardButton[] rowTwo =
            {
                new KeyboardButton("درباره ما"+" "+"\U0001F3E4" ),
                new KeyboardButton("تماس با ما"+" "+"\U0000260E"),
                new KeyboardButton("پرسش پاسخ"+" "+"\U00002753")
            };

            mainKeyBoard = new ReplyKeyboardMarkup(rowOne);

            mainKeyBoard.Keyboard = new KeyboardButton[][]
            {
                rowOne,rowTwo
            };
        }

         void RunBot()
        {
            bot = new Telegram.Bot.TelegramBotClient(Token);

            // change color and text of status label on statusBar on Form1 
            this.Invoke(new Action(() =>
            {
                lblStatus.Text = "Online";
                lblStatus.ForeColor = Color.Green;
            }));

            int offset = 0;

            while (true)
            {
                Telegram.Bot.Types.Update[] updates = bot.GetUpdatesAsync(offset).Result;

                foreach (var item in updates)
                {
                    offset = item.Id + 1;
                    if(item.CallbackQuery != null)
                    {
                        if (item.CallbackQuery.Data.Contains("1"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "سر درد داشته   - 1":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"سر درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id,item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "دل درد داشته   - 1":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"دل درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "   - 1گلودرد داشته ":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"گلو درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "تب داشته   - 1":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"تب داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "سرفه داشته   - 1":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"سرفه داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "   - 1آبریزش بینی داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"آبریزش بینی داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "   - 1از دست دادن حس بویایی داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"از دست دادن حس بویایی"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "احساس تنگی نفس داشته   - 1":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"احساس تنگی نفس داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "   - 1هیچکدام":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال اول : {"هیچکدام"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                            }
                        }
                        else if (item.CallbackQuery.Data.Contains("2"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "-2-      سر درد داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"سر درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      دل درد داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"دل درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      گلودرد داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"گلو درد داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      تب داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"تب داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      سرفه داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"سرفه داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      آبریزش بینی داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"آبریزش بینی داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      از دست دادن حس بویایی داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"از دست دادن حس بویایی"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      احساس تنگی نفس داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"احساس تنگی نفس داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "-2-      هیچکدام":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال دوم : {"هیچکدام"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                            }
                        }
                        else if (item.CallbackQuery.Data.Contains("3"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "بله استفاده کرده           -3":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال سوم : {"بله استفاده کرده"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "خیر اصلا استفاده نکرده           -3":
                                    {
                                            answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال سوم : {"خیر ، استفاده نکرده"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                            SaveAsTxtFileExtention.WriteAnswers(answer);
                                            bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                            break;
                                    }
                            }
                        }
                        else if (item.CallbackQuery.Data.Contains("4"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "بله در ارتباط بوده4":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال چهارم : {"بله در ارتباط بوده"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "خیر اصلا4 ":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال چهارم : {"خیر ، اصلا ارتباط نداشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                            }
                        }
                        else if (item.CallbackQuery.Data.Contains("5"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "5بله حضور داشته":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال پنجم : {"بله حضور داشته"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "خیر اصلا5 ":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال پنجم : {"خیر اصلا"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                            }
                        }
                        else if (item.CallbackQuery.Data.Contains("6"))
                        {
                            switch (item.CallbackQuery.Data)
                            {
                                case "بله صداقت داشتم6":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال ششم : {"صداقت داشتم"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                                case "خیر هیچ صداقتی ندارم6 ":
                                    {
                                        answer = $"{item.CallbackQuery.From.Username} | {item.CallbackQuery.From.FirstName + item.CallbackQuery.From.LastName} | پاسخ به سوال ششم : {"دروغ گفتم"} | {DateTime.Now.ConvertMiladiToShamsi()}";
                                        SaveAsTxtFileExtention.WriteAnswers(answer);
                                        bot.DeleteMessageAsync(item.CallbackQuery.Message.Chat.Id, item.CallbackQuery.Message.MessageId);
                                        break;
                                    }
                            }
                        }
                    }

                    if (item.Message == null)
                        continue;

                    var text = item.Message.Text;
                    var fromWho = item.Message.From;
                    var chatId = item.Message.Chat.Id;

                    if (text.ToLower().Contains("/start"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"سلام - {fromWho.Username} - به ربات سامانه نظرسنجی مجموعه فرهنگی آموزشی فرهنگ سعادت خوش آمدید");
                        sb.AppendLine("");
                        sb.AppendLine($"لطفا بر روی (نظر سنجی) کلیک کنید تا سوالات برای شما ارسال شوند .");
                        sb.AppendLine("-                                         -");

                         bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null, mainKeyBoard);
                    }
                    else if (text.ToLower().Contains("/contactus") || text.Trim().ToLower().Contains("تماس با ما"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"راه های تماس با ما : ");
                        sb.AppendLine("");
                        sb.AppendLine($"شماره تماس : ");
                        sb.AppendLine("\U0001F4DE" + "021-88699795");
                        sb.AppendLine("\U0001F4DE" + "021-88699795");
                        sb.AppendLine("\U0001F4DE" + "021-88699795");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F698" + "آدرس ها : ");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F3E1" + "دبستان و پیش‌دبستان فرهنگ سعادت : ");
                        sb.AppendLine("\U0001F690" + "سعادت‌آباد، خیابان سی و هشتم غربی، نبش گلها، پلاک ۲");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F3EB" + "مدرسه متوسطه اول‌ فرهنگ سعادت : ");
                        sb.AppendLine("\U0001F690" + "شهرک غرب، خیابان ایران زمین، خیابان دوم، اول اردیبهشت، پلاک ۱۳");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F4F1" + "واتس آپ : 0385219700");
                        sb.AppendLine("");
                        sb.AppendLine("\U00002705" + "آدرس وب سایت : www.farhangesaadat.ir");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F4E7" + "ارتباط مستقیم با مدیریت :" + "ghasempour@farhangesaadat.ir");
                        sb.AppendLine("-                                         -");

                         bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null, mainKeyBoard);
                    }
                    else if (text.ToLower().Contains("/aboutus") || text.Trim().ToLower().Contains("درباره ما"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("امکانات :");
                        sb.AppendLine("مشاوره‌ي پرورشي");
                        sb.AppendLine("مشاوره‌ي روان‌شناسي (گروه مشاوره‌ي دكتر تبريزي)");
                        sb.AppendLine("مشاوره‌ي درسي (معلم پايه)");
                        sb.AppendLine("كلاس‌هاي هوشمند تعاملي تبلت‌محور");
                        sb.AppendLine("كارگاه سازه ماكاروني");
                        sb.AppendLine("كارگاه الكترونيك رباتيك");
                        sb.AppendLine("كارگاه هوافضا");
                        sb.AppendLine("كارگاه مكاسيستم");
                        sb.AppendLine("كارگاه نجاري");
                        sb.AppendLine("كارگاه رياضي خلاق");
                        sb.AppendLine("كارگاه پرينت 3 بعدي");
                        sb.AppendLine("كلاس المپياد رياضي");
                        sb.AppendLine("كلاس المپياد فيزيك");
                        sb.AppendLine("كلاس المپياد شيمي");
                        sb.AppendLine("كلاس المپياد نجوم");
                        sb.AppendLine("كلاس المپياد ادبيات");
                        sb.AppendLine("اردوهاي تفريحي: سفر به مشهد مقدس، شهر تاريخي يزد");
                        sb.AppendLine("  اردوهاي ورزشي: شركت در مسابقات منطقه‌اي، استاني، و كشور");
                        sb.AppendLine("اردوهاي آموزشي: اردوي نجوم در كوير، بازديد از مراكز علمي و پژوهشي");
                        sb.AppendLine("برگزاري كلاس‌هاي ورزش در مجموعه ورزشي انقلاب تهران");
                        sb.AppendLine("رشته‌ي فوتسال: آموزش زير نظر آقاي خسرو حاج‌خليل مربي درجه‌ي A آسيا و بازيكن سابق تيم ملّي");
                        sb.AppendLine("رشته‌ي بسكتبال: آموزش زير نظر آقاي فريدوني");
                        sb.AppendLine("برگزاري مسابقات درون مدرسه‌اي و منطقه‌اي و استاني");
                        sb.AppendLine("انجام پيكرسنجي و استعداديابي ورزشي زير نظر متخصصين مربوطه");
                        sb.AppendLine("تدارك و تجهيز اتاق بازي‌هاي فكري براي دانش‌آموزان");
                        sb.AppendLine("برگزاري نمازجماعت در ساعت تفريح ظهر");
                        sb.AppendLine("برقراري امكان استفاده از بوفه‌ي هوشمند");
                        sb.AppendLine("---------------------------------------");
                        sb.AppendLine($"کوتاه درباره ما :");
                        sb.AppendLine("");
                        sb.AppendLine("مجتمع آموزشي فرهنگ سعادت در سال ۱۳۷۵ تاسيس شد. از همان ابتدا، تلاش اوليا مدرسه بر پايه پرورش فرزندان عزيزمان در كنار توجه به آموزش آنها بوده است. از همين رو، اختصاص فضاهاي مدرسه به كارگاه‌هاي مهارت‌اندوزي و همچنين ساعات آموزشي به كلاس‎هاي تخصصي در دستور كار مجموعه قرار گرفت. چرا كه بر اين باوريم صرف توجه و تمركز بر روي آموزش، در نهايت منجر به رشد تنها يك بُعد از شخصيت فرزند ما خواهد شد. در كنار مسائل پرورشي و مهارت‌اندوزي، توجه ويژه‌اي به تكنولوژي روز جهان در صنعت آموزش و پرورش گرديد كه ثمره‌ي آن پيشگامي اين مجموعه در اين حوزه، در تمام منطقه ۲ و در مقياسي بزرگتر حتي در سطح استان و كشور مي‌باشد.");
                        sb.AppendLine("");
                        sb.AppendLine("با عنايت به گستره‌ي فعاليت آموزشي و فرهنگي در ساليان گذشته و نياز اولياي گرامي به تربيت نونهالان خويش كه از سنين پايين‌تر مكاني شايسته براي تحصيل فرزندان خويش انتخاب نمايند، هيات مديره ي مجتمع آموزشي فرهنگ سعادت بر آن شد تا با توجه به ظرفيت‌هاي موجود از سال تحصيلي ۹۷-۹۶ دوره‌ي اول دبيرستان را نيز راه‌اندازي نمايند. مشورت با پيشكسوتان عرصه‌ي آموزش و  برنامه‌ريزي‌هاي صورت گرفته در واحد آموزش مدرسه منجر به آن شد تا دروس اصلي مدرسه براساس سرفصل‌هاي مطرح شده در كتاب قسمت‌بندي گردند و بر اين اساس درس رياضي به دو شاخه‌ي «جبر و حساب» و «هندسه» و درس علوم به شاخه‌هاي «فيزيك»، «شيمي»، «زيست‌شناسي»، و «زمين‌شناسي» تقسيم و ساعات جداگانه‌اي براي آموزش آنها در نظر گرفته شده است. ");
                        sb.AppendLine("");
                        sb.AppendLine("يكي از مهمترين اركان مدرسه، واحد مشاوره‌ي آن مي‌باشد. ما در اين مجموعه اهمّيّت فراواني براي امر مشاوره قائل بوده و در سه شاخه‌ي پرورشي، آموزشي، و رفتاري(روان‌شناسي) آن را اجرا مي‌نماييم. به دليل همزماني دوران بلوغ پسران عزيزمان با اين برهه‌ي آموزشي، كوشش مي‌كنيم تا آنها را در اين سن حسّاس بيشتر و بهتر همراهي و درك كرده تا به سهم خود يار و ياور خانواده‌ي محترم آنها باشيم.");
                        sb.AppendLine("");
                        sb.AppendLine("همچنين دپارتمان تحقيق و پژوهش مدرسه، با برپايي كارگاه‌هاي سازه ماكاروني، الكترونيك-رباتيك، هوافضا، مكاسيستم، رياضي خلاق، پرينت ۳ بعدي، و نجاري امور مربوط به مهارت‌‌اندوزي دانش‌آموزان را طراحي و اجرا مي‌نمايد. نكته‌ي قابل تامل در اين زمينه، بكارگيري اساتيد و معلمين تخصصي براي اين دروس و از آن مهمتر، طراحي و تخصيص فضاهاي ويژه و تجهيز آن فضاها با وسايل مربوطه مي‌باشد.");
                        sb.AppendLine("");
                        sb.AppendLine("در كنار موارد فوق، كلاس‌هاي هوشمند تعاملي مبتني بر تبلت نيز در اين مجموعه طراحي و اجرا گرديده است. در اين مدل كلاس، يك دستگاه تلويزيون تاچ‌اسكرين ۶۵ اينچي در كلاس نصب شده و جاي تخته‌هاي سياه و يا سفيد معمول را گرفته است. به هر دانش‌آموز يك تبلت اختصاص داده شده كه تمامي آنها به كامپيوتر آموزگار اتصال داشته و در كنترل معلم مي باشند. امكان تعامل ميان دانش‌آموز با معلم و مطالب درج شده روي برد، آزمون‌هاي كلاسي، محتواي الكترونيك اختصاصي براي دروس مختلف، و كنترل تكاليف از ديگر امكانات در نظر گرفته شده براي اين كلاسها مي‌باشد. ");
                        sb.AppendLine("");
                        sb.AppendLine("ساعت آغاز به كار مدرسه ۷:۳۰ و پايان آن ساعت ۱۵ مي‌باشد. همچنين ساعت ۱۲:۳۰ دانش‌آموزان به مدت ۳۰ دقيقه براي خوردن نهار و اقامه‌ي نماز جماعت وقت آزاد دارند. براي هر دانش‌آموز يك كمد جداگانه اختصاص يافته تا وسايل خود را در آن قرار داده و لازم نباشد كتابها و جزوات خود را همواره با خود حمل نمايد.");
                        sb.AppendLine("");
                        sb.AppendLine("-                                         -");

                         bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null, mainKeyBoard);
                    }
                    else if (text.Trim().ToLower().Contains("نظرسنجی"))
                    {
                        // InlineKeyboardMarkup inline = new InlineKeyboardMarkup();
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"لطفا سوالات را با دقت مطالعه کرده و با پاسخ های صادقانه ما را در خدمت رسانی هرچه بهتر به فرزندان خود یاری فرمایید - با تشکر" + " " + "\U0001F64F");
                        sb.AppendLine("-                                         -");
                        bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null);

                        #region question one
                        InlineKeyboardButton[] row1 =
                        {
                           InlineKeyboardButton.WithCallbackData("سردرد","سر درد داشته   - 1"),
                        };

                        InlineKeyboardButton[] row2 =
{
                           InlineKeyboardButton.WithCallbackData("دل درد","دل درد داشته   - 1"),
                        };

                        InlineKeyboardButton[] row3 =
{
                            InlineKeyboardButton.WithCallbackData("گلودرد","   - 1گلودرد داشته "),
                        };

                        InlineKeyboardButton[] row4 =
{
                          InlineKeyboardButton.WithCallbackData("تب","تب داشته   - 1"),
                        };

                        InlineKeyboardButton[] row5 =
{
                           InlineKeyboardButton.WithCallbackData("سرفه","سرفه داشته   - 1"),
                        };

                        InlineKeyboardButton[] row6 =
{
                           InlineKeyboardButton.WithCallbackData("آبریزش بینی","   - 1آبریزش بینی داشته"),
                        };

                        InlineKeyboardButton[] row7 =
{
                           InlineKeyboardButton.WithCallbackData("از دست دادن حس بویایی","   - 1از دست دادن حس بویایی داشته"),
                        };

                        InlineKeyboardButton[] row8 =
{
                          InlineKeyboardButton.WithCallbackData("احساس تنگی نفس","احساس تنگی نفس داشته   - 1"),
                        };

                        InlineKeyboardButton[] row9 =
{
                           InlineKeyboardButton.WithCallbackData("هیچکدام","   - 1هیچکدام"),
                        };

                        List<InlineKeyboardButton[]> allRows = new List<InlineKeyboardButton[]>()
                        {
                            row1,row2,row3,row4,row5,row6,row7,row8,row9
                        };

                        InlineKeyboardMarkup inlineKeyboard1 = new InlineKeyboardMarkup(allRows);

                        bot.SendTextMessageAsync(chatId, "(1)آیا فرزند شما در طی ۲۴ ساعت گذشته دارای یک یا چند علائم زیر بوده است؟", default, null, false, false, null, null, inlineKeyboard1);
                        #endregion
                        #region question two
                        InlineKeyboardButton[] row21 =
                        {
                           InlineKeyboardButton.WithCallbackData("سردرد","-2-      سر درد داشته"),
                        };

                        InlineKeyboardButton[] row22 =
{
                           InlineKeyboardButton.WithCallbackData("دل درد","-2-      دل درد داشته"),
                        };

                        InlineKeyboardButton[] row23 =
{
                                                     InlineKeyboardButton.WithCallbackData("گلودرد","-2-      گلودرد داشته"),
                        };

                        InlineKeyboardButton[] row24 =
{
                                                      InlineKeyboardButton.WithCallbackData("تب","-2-      تب داشته"),
                        };

                        InlineKeyboardButton[] row25 =
{
                           InlineKeyboardButton.WithCallbackData("سرفه","-2-      سرفه داشته"),
                        };

                        InlineKeyboardButton[] row26 =
{
                           InlineKeyboardButton.WithCallbackData("آبریزش بینی","-2-      آبریزش بینی داشته"),
                        };

                        InlineKeyboardButton[] row27 =
{
                           InlineKeyboardButton.WithCallbackData("از دست دادن حس بویایی","-2-      از دست دادن حس بویایی داشته"),
                        };

                        InlineKeyboardButton[] row28 =
{
                          InlineKeyboardButton.WithCallbackData("احساس تنگی نفس","-2-      احساس تنگی نفس داشته"),
                        };

                        InlineKeyboardButton[] row29 =
{
                           InlineKeyboardButton.WithCallbackData("هیچکدام","-2-      هیچکدام"),
                        };

                        List<InlineKeyboardButton[]> allRows2 = new List<InlineKeyboardButton[]>()
                        {
                            row21,row22,row23,row24,row25,row26,row27,row28,row29
                        };

                        InlineKeyboardMarkup inlineKeyboard2 = new InlineKeyboardMarkup(allRows2);

                         bot.SendTextMessageAsync(chatId, "(2)آیا شما و افرادی که با فرزندتان در مدت ۴۸ ساعت گذشته در ارتباط بوده اید، دارای یک یا چند مورد از علائم زیر بوده اند؟", default, null, false, false, null, null, inlineKeyboard2);
                        #endregion
                        #region question three
                        InlineKeyboardButton[] row31 =
                        {
                           InlineKeyboardButton.WithCallbackData("بله","بله استفاده کرده           -3"),
                        };

                        InlineKeyboardButton[] row32 =
{
                           InlineKeyboardButton.WithCallbackData("خیر","خیر اصلا استفاده نکرده           -3"),
                        };

                        List<InlineKeyboardButton[]> allRows3 = new List<InlineKeyboardButton[]>()
                        {
                            row31,row32
                        };

                        InlineKeyboardMarkup inlineKeyboard3 = new InlineKeyboardMarkup(allRows3);

                         bot.SendTextMessageAsync(chatId, "آیا فرزند شما در طول مدت روز گذ۶شته از وسایل حمل و نقل عمومی استفاده کرده است؟ در صورت پاسخ مثبت لطفا با روابط عمومی یا مسئولین مدرسه تماس گرفته شود.", default, null, false, false, null, null, inlineKeyboard3);
                        #endregion
                        #region question four
                        InlineKeyboardButton[] row41 =
                        {
                           InlineKeyboardButton.WithCallbackData("بله","بله در ارتباط بوده4"),
                        };

                        InlineKeyboardButton[] row42 =
{
                           InlineKeyboardButton.WithCallbackData("خیر","خیر اصلا4 "),
                        };

                        List<InlineKeyboardButton[]> allRows4 = new List<InlineKeyboardButton[]>()
                        {
                            row41,row42
                        };

                        InlineKeyboardMarkup inlineKeyboard4 = new InlineKeyboardMarkup(allRows4);

                         bot.SendTextMessageAsync(chatId, "آیا فرزند شما درطول ۱۴ روز گذشته با 'فرد مبتلا به کرونا' در ارتباط بوده است؟ در صورت پاسخ مثبت، لطفا با روابط عمومی یا مسئولین مدرسه تماس گرفته شود(4).", default, null, false, false, null, null, inlineKeyboard4);
                        #endregion
                        #region question five
                        InlineKeyboardButton[] row51 =
                        {
                           InlineKeyboardButton.WithCallbackData("بله","5بله حضور داشته"),
                        };

                        InlineKeyboardButton[] row52 =
{
                           InlineKeyboardButton.WithCallbackData("خیر","خیر اصلا5 "),
                        };

                        List<InlineKeyboardButton[]> allRows5 = new List<InlineKeyboardButton[]>()
                        {
                            row51,row52
                        };

                        InlineKeyboardMarkup inlineKeyboard5 = new InlineKeyboardMarkup(allRows5);

                         bot.SendTextMessageAsync(chatId, "(5)آیا فرزند شما در طول مدت ۴۸ ساعت گذشته در مکان های عمومی و یا پرخطر از لحاظ شیوع ویروس کرونا حضور داشته است؟ در صورت پاسخ مثبت ، لطفا با روابط عمومی یا مسئول مدرسه تماس گرفته شود؟", default, null, false, false, null, null, inlineKeyboard5);
                        #endregion
                        #region question six
                        InlineKeyboardButton[] row61 =
                        {
                           InlineKeyboardButton.WithCallbackData("بله","بله صداقت داشتم6"),
                        };

                        InlineKeyboardButton[] row62 =
{
                           InlineKeyboardButton.WithCallbackData("خیر","خیر هیچ صداقتی ندارم6 "),
                        };

                        List<InlineKeyboardButton[]> allRows6 = new List<InlineKeyboardButton[]>()
                        {
                            row61,row62
                        };

                        InlineKeyboardMarkup inlineKeyboard6 = new InlineKeyboardMarkup(allRows6);

                        bot.SendTextMessageAsync(chatId, "آیا فرزند شما در طول مدت ۴۸ ساعت گذشته در مکان های عمومی و یا پرخطر از لحاظ شیوع ویروس کرونا حضور داشته است؟ در صورت پاسخ مثبت ، لطفا با روابط عمومی یا مسئول مدرسه تماس گرفته شود؟(6)", default, null, false, false, null, null, inlineKeyboard6);
                        #endregion

                        //bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null, VotereplyKeyboardMarkup);
                    }
                    else if (text.Trim().ToLower().Contains("پرسش پاسخ"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"سلام - {fromWho.Username} - عزیز ");
                        sb.AppendLine("");
                        sb.AppendLine("\U0001F535" + "لطفا سوال خود را مطرح کنید تا در سریع ترین زمان ، کارشناسان ما پاسخ بدهند ");

                        sb.AppendLine("-                                         -");
                         bot.SendTextMessageAsync(chatId, sb.ToString(), default, null, false, false, null, null, mainKeyBoard);
                    }



                    dgReport.Invoke(new Action(() =>
                    {
                        dgReport.Rows.Add(item.Message.Chat.Id, fromWho.Username, text.RemoveUniCodes(), item.Message.MessageId, item.Message.Date.ConvertMiladiToShamsi());
                        SaveAsTxtFileExtention.WriteAsync($"(شناسه چت : {item.Message.Chat.Id}) - (نام کاربری : {fromWho.Username}) - ( پاسخ : {text.RemoveUniCodes()} ) - (شناسه پیام : {item.Message.MessageId}) - (تاریخ : {item.Message.Date.ConvertMiladiToShamsi()})");
                    }));
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //  BotThraed.Abort();

            if (btnStart.Enabled == false)
            {
                BotThraed.Abort();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                if (dgReport.CurrentRow.Selected)
                {
                    int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                    bot.SendTextMessageAsync(chatId, txtMessage.Text);
                    txtMessage.Text = "";
                }
                else
                {
                    MessageBox.Show("لطفا اول یک کاربر انتخاب کنید ، سپس بر روی دکمه ارسال کلیک کنید ");
                }
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openfile.FileName;
            }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show($"لطفا اول یک تصویر انتخاب کنید ، سپس روی دکمه {"Photo"} کلیک کنید ");
            }

            if (dgReport.CurrentRow != null)
            {
                if (dgReport.CurrentRow.Selected)
                {
                    if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                    {
                        MessageBox.Show($"لطفا اول یک تصویر انتخاب کنید ، سپس روی دکمه {"Photo"} کلیک کنید ");
                    }
                    FileStream imageFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);
                    int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                    bot.SendPhotoAsync(chatId, new InputOnlineFile(imageFile, "ارسال شده توسط مجموعه فرهنگی آموزشی  فرهنگ سعادت"), string.IsNullOrEmpty(txtMessage.Text) == true ? "" : txtMessage.Text);
                    txtMessage.Text = "";
                    txtFilePath.Text = "";
                }
                else
                {
                    MessageBox.Show($"لطفا اول یک کاربر انتخاب کنید ، سپس بر روی دکمه {"Photo"} کلیک کنید ");
                }
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show($"لطفا اول یک فایل ویدیویی انتخاب کنید ، سپس روی دکمه {"Video"} کلیک کنید ");
            }

            if (dgReport.CurrentRow != null)
            {
                if (dgReport.CurrentRow.Selected)
                {
                    if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                    {
                        MessageBox.Show($"لطفا اول یک فایل ویدیویی انتخاب کنید ، سپس روی دکمه {"Video"} کلیک کنید ");
                    }

                    int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                    FileStream stream = new FileStream(txtFilePath.Text, FileMode.Open);
                    bot.SendVideoAsync(chatId, new InputOnlineFile(stream, "ارسال شده توسط مجموعه فرهنگی آموزشی  فرهنگ سعادت"));
                }
                else
                {
                    MessageBox.Show($"لطفا اول یک کاربر انتخاب کنید ، سپس بر روی دکمه {"Video"} کلیک کنید ");
                }
            }
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == null || txtMessage.Text == "")
            {
                MessageBox.Show($"لطفا قبل از سعی برای ارسال ، یک پیام بنویسید چون بدون وجود متن پیام ، امکان ارسال وجود ندارد .");
            }
            else
            {
                bot.SendTextMessageAsync(txtChanel.Text, txtMessage.Text, Telegram.Bot.Types.Enums.ParseMode.Html);
                txtMessage.Text = "";
            }
        }

        private void btnSendPhoto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show($"لطفا اول یک تصویر انتخاب کنید ، سپس روی دکمه کلیک کنید ");
            }

            if (txtChanel.Text != null)
            {
                if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                {
                    MessageBox.Show($"لطفا اول یک تصویر انتخاب کنید ، سپس روی دکمه {"Photo"} کلیک کنید ");
                }
                FileStream imageFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);
                bot.SendPhotoAsync(txtChanel.Text, new InputOnlineFile(imageFile, "ارسال شده توسط مجموعه فرهنگی آموزشی  فرهنگ سعادت"), string.IsNullOrEmpty(txtMessage.Text) == true ? "" : txtMessage.Text);
                txtMessage.Text = "";
                txtFilePath.Text = "";
            }
            else
            {
                MessageBox.Show("لطفا ابتدا آیدی یا همان شناسه کانال را در جای مربوطه قرار دهید و سپس کلیک کنید .");
            }
        }

        private void btnSendVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show($"لطفا اول یک فایل ویدیویی انتخاب کنید ، سپس روی دکمه کلیک کنید ");
            }

            if (txtChanel.Text != null)
            {
                FileStream stream = new FileStream(txtFilePath.Text, FileMode.Open);
                bot.SendVideoAsync(txtChanel.Text, new InputOnlineFile(stream, "ارسال شده توسط مجموعه فرهنگی آموزشی  فرهنگ سعادت"));
            }
            else
            {
                MessageBox.Show("لطفا ابتدا آیدی یا همان شناسه کانال را در جای مربوطه قرار دهید و سپس کلیک کنید .");
            }

        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
