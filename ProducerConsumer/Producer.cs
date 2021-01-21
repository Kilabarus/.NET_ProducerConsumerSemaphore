using System;
using System.Threading;

namespace ProducerConsumer
{
    // Класс "Производителя" (1-ый поток по условию)
    public class Producer
    {
        // События для вывода логов на форму
        public event Action<string> CreatedMessageAndTryingToAddItToBuffer;
        public event Action<string, bool> MessageAddedToBuffer;        

        // Буфер, куда добавляются созданные строки (1-ый буфер по условию)
        Stack _buffer;

        public Producer(Stack buffer)
        {
            _buffer = buffer;
        }

        // Создание и старт потока
        public void StartProducerThread()
        {
            if (_buffer == null 
                || CreatedMessageAndTryingToAddItToBuffer == null 
                || MessageAddedToBuffer == null)
            {
                throw new NullReferenceException();
            }

            Thread producerThread = new Thread(ProduceMessages);
            producerThread.Start();
        }

        // Генерация сообщений и добавление их в буфер
        private void ProduceMessages()
        {
            Random rnd = new Random();

            string message;
            int i = 1;

            while (true)
            {
                Thread.Sleep(rnd.Next(1000, 2000));

                // Сообщения представляют из себя номер создаваемого сообщения
                message = i++.ToString();

                CreatedMessageAndTryingToAddItToBuffer.Invoke($"1-ый поток создал сообщение \"{message}\" и пытается поместить его в 1-ый буфер");
                
                _buffer.Push(message);
                MessageAddedToBuffer.Invoke($"1-ый поток поместил сообщение \"{message}\" в 1-ый буфер", true);                       
            }            
        }
    }
}
