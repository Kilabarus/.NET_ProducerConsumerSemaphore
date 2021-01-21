using System;
using System.Threading;

namespace ProducerConsumer
{
    // Класс "Потребителя-производителя" (2-ой поток по условию)
    class ConsumerProducer
    {
        // События для вывода логов на форму
        public event Action<string> TryingToGetMessageFromBuffer, AddedInfoToMessageAndTryingToAddItToBuffer;
        public event Action<string, bool> MessageGotFromBuffer, MessageAddedToBuffer;

        // Буферы для получения сообщений и для добавления обработанных сообщений (1-ый и 2-ой буферы по условию)
        Stack _bufferToGetMessagesFrom, _bufferToAddMessagesTo;

        public ConsumerProducer(Stack bufferToGetMessagesFrom, Stack bufferToAddMessagesTo)
        {
            _bufferToGetMessagesFrom = bufferToGetMessagesFrom;
            _bufferToAddMessagesTo = bufferToAddMessagesTo;            
        }

        // Создание и старт потока
        public void StartConsumerProducerThread()
        {
            if (_bufferToGetMessagesFrom == null || _bufferToAddMessagesTo == null 
                || TryingToGetMessageFromBuffer == null || AddedInfoToMessageAndTryingToAddItToBuffer == null 
                || MessageGotFromBuffer == null || MessageAddedToBuffer == null)
            {
                throw new NullReferenceException();
            }

            Thread consumerProducerThread = new Thread(ConsumeProduceThread);
            consumerProducerThread.Start();
        }

        // Получение сообщений из 1-го буфера, 
        //      добавление к ним своей информации и добавление полученного сообщения во 2-ой буфер
        public void ConsumeProduceThread()
        {
            Random rnd = new Random();

            int i = 1;
            string oldMessage, newMessage;

            while (true)
            {
                Thread.Sleep(rnd.Next(3000, 4000));

                TryingToGetMessageFromBuffer.Invoke("2-ой поток пытается забрать сообщение из 1-го буфера");
                oldMessage = _bufferToGetMessagesFrom.Pop();
                MessageGotFromBuffer.Invoke($"2-ой поток забрал сообщение \"{oldMessage}\" из 1-го буфера", true);

                Thread.Sleep(500);
                
                // Добавленная информация представляет из себя номер обрабатываемого данным потоком сообщения
                newMessage = oldMessage + $" - {i++}";                

                AddedInfoToMessageAndTryingToAddItToBuffer.Invoke($"2-ой поток добавил к сообщению \"{oldMessage}\" свою информацию и пытается поместить получившееся сообщение \"{newMessage}\" во 2-ой буфер");                                
                
                _bufferToAddMessagesTo.Push(newMessage);
                MessageAddedToBuffer.Invoke($"2-ой поток поместил сообщение \"{newMessage}\" во 2-ой буфер", false);                
            }
        }
    }
}
