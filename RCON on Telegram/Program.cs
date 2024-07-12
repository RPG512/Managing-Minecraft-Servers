using System.Net;
using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using CoreRCON;
using CoreRCON.Parsers.Standard;
using System;

namespace RCON_on_Telegram
{
    internal class Program
    {
        private static RCON _rcon;

        private static TelegramBotClient _bot = new TelegramBotClient(ConfigurationManager.AppSettings["BotToken"]);

        private const string _onButton = "Включить";
        private const string _offButton = "Выключить";

        private static InlineKeyboardMarkup _menuMarkup = new
        (
            new[] {
                      new[] { InlineKeyboardButton.WithCallbackData(_onButton) },
                      new[] { InlineKeyboardButton.WithCallbackData(_offButton) }
                  }
        );

        static void Main(string[] args)
        {
            string ip = string.Empty;
            ushort port = 0;
            string password = string.Empty;
            if (!(args.Length > 0))
            {
                if (true/*args[0].Equals("-ingui")*/)
                {
                    ip = "192.168.1.119";
                    port = 25574;
                    password = "11211";
                }
            }
            else
            {
                Console.Write("IP: ");
                ip = Console.ReadLine();
                Console.Write("Port:");
                port = Convert.ToUInt16(Console.ReadLine());
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            _rcon = new RCON(IPAddress.Parse(ip), port, password);

            using var cts = new CancellationTokenSource();

            _bot.StartReceiving(
                updateHandler: HandleUpdate,
                pollingErrorHandler: HandleError,
                cancellationToken: cts.Token
            );

            Console.WriteLine("Отслеживание обновлений начато. Нажмите enter для остановки");

            Console.ReadLine();

            cts.Cancel();//Завершение программы

            async Task HandleUpdate(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        await HandleMessage(update.Message!);
                        break;

                    case UpdateType.CallbackQuery:
                        await HandleButton(update.CallbackQuery!);
                        break;
                }

            }

            async Task HandleError(ITelegramBotClient _, Exception exception, CancellationToken cancellationToken)
            {
                await Console.Error.WriteLineAsync(exception.Message);
            }

            async Task HandleMessage(Message msg)
            {
                var chat = msg.Chat;
                var text = msg.Text ?? string.Empty;

                if (chat is null)
                    return;

                Console.WriteLine($"{chat.Username} написал {text}");

                try
                {
                    if (text.StartsWith("/"))
                    {
                        await HandleCommand(chat.Id, text);
                    }
                    else
                    {
                        var command = text;
                        var res = _rcon.SendCommandAsync(command);
                        await _bot.SendTextMessageAsync(chat.Id, res.Result);//сообщ
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Хз может бота закинули в чат для тгк и кто-то выложил пост");
                }
            }

            async Task HandleCommand(long userId, string command)
            {
                switch (command)
                {
                    case "/menu":
                        await SendMenu(userId);
                        break;
                    case "/start":
                        await _bot.SendTextMessageAsync(userId, "Здравствуйте.\nДля вызова меню - /menu");
                        break;
                    default:
                        var res = _rcon.SendCommandAsync(command);
                        await _bot.SendTextMessageAsync(userId, res.Result);
                        break;
                }

                await Task.CompletedTask;
            }

            async Task SendMenu(long userId)
            {
                await _bot.SendTextMessageAsync
                    (
                        userId,
                        "Включить/отключить отправку уведомлений о новых постах на DTF, раздел \"Популярное\"?",
                        parseMode: ParseMode.Html,
                        replyMarkup: _menuMarkup
                    );
            }

            async Task HandleButton(CallbackQuery query)
            {
                long userId = query.Message!.Chat.Id;

                string text = string.Empty;
                InlineKeyboardMarkup markup = new(Array.Empty<InlineKeyboardButton>());

                if (query.Data == _onButton)
                {
                    
                }
                else if (query.Data == _offButton)
                {
                    
                }

                await _bot.AnswerCallbackQueryAsync(query.Id);

                await _bot.EditMessageTextAsync(
                    userId,
                    query.Message.MessageId,
                    text,
                    ParseMode.Html,
                    replyMarkup: markup
                );
            }














            /*var cmd = _rcon.SendCommandAsync("help");
            Console.Write(cmd.Result + "\n\nCommand: ");
            while (true)
            {
                var command = Console.ReadLine();
                var res = _rcon.SendCommandAsync(command);
                Console.Write(res.Result + "\n\nCommand: ");
            }*/
        }
    }
}
