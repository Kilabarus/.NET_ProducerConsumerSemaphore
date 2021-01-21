using System;
using System.Threading;

namespace ProducerConsumer
{
    // Класс "Потребителя" (3-ий поток по условию)
    public class Consumer
    {
        // События для вывода логов на форму
        public event Action<string> TryingToGetMessageFromBuffer;
        public event Action<string, bool> MessageGotFromBuffer;
        public event Action<string, string> AddedInfoToMessage;

        // Буфер для получения сообщений (2-ой поток по условию)
        Stack _buffer;

        public Consumer(Stack buffer)
        {
            _buffer = buffer;            
        }

        // Создание и старт потока
        public void StartConsumerThread()
        {
            if (_buffer == null 
                || TryingToGetMessageFromBuffer == null || MessageGotFromBuffer == null || AddedInfoToMessage == null)
            {
                throw new NullReferenceException();
            }

            Thread producerThread = new Thread(ConsumeMessage);
            producerThread.Start();
        }

        // Получение сообщений из 2-го буфера,
        //      добавление к ним своей информации и его передача как параметра события для логов
        private void ConsumeMessage()
        {
            Random rnd = new Random();

            int i = 1;
            string oldMessage, newMessage;

            while (true)
            {
                Thread.Sleep(rnd.Next(5000, 6000));

                TryingToGetMessageFromBuffer.Invoke("3-ий поток пытается забрать сообщение из 2-го буфера");
                oldMessage = _buffer.Pop();
                MessageGotFromBuffer.Invoke($"3-ий поток забрал сообщение \"{oldMessage}\" из 2-го буфера", false);

                // Добавленная информация представляет из себя номер обрабатываемого данным потоком сообщения
                Thread.Sleep(1000);
                newMessage = oldMessage + $" - {i++}";

                AddedInfoToMessage.Invoke($"3-ий поток добавил к сообщению \"{oldMessage}\" свою информацию, итоговое сообщение: \"{newMessage}\"", newMessage);
            }
        }
    }
}
