using System;
using System.Windows.Forms;

/*
 * Лабораторная №1
 * Реализовать задачу "Поставщик-потребитель"
 * 
 * Вариант 1.2.5
 * Представление буфера - стек
 * Средства синхронизации - семафоры и мьютексы
 * 
 * Создать многопоточное приложение, в котором главный поток создаёт три потока:
 *      1-ый поток создаёт сообщение и помещает его в 1-ый буфер
 *      2-ой поток забирает сообщение из 1-го буфера, добавляет к сообщению свою информацию и передаёт сообщение во 2-ой буфер
 *      3-ий поток забирает сообщение из 2-го буфера, и добавляет к нему своё сообщение
 *      
 *  Данильченко Роман, 9 гр.
 */

namespace ProducerConsumer
{
    public partial class Form1 : Form
    {
        Stack _1stBuf, _2ndBuf;

        Producer _producer;
        ConsumerProducer _consumerProducer;
        Consumer _consumer;

        public Form1()
        {
            Random rnd = new Random();

            InitializeComponent();

            _1stBuf = new Stack(10);
            _2ndBuf = new Stack(10);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _producer = new Producer(_1stBuf);
            _producer.MessageAddedToBuffer += ContentOfBufferChanged;
            _producer.CreatedMessageAndTryingToAddItToBuffer += EventWithoutChangingBufferHappened;

            _consumerProducer = new ConsumerProducer(_1stBuf, _2ndBuf);
            _consumerProducer.MessageGotFromBuffer += ContentOfBufferChanged;
            _consumerProducer.MessageAddedToBuffer += ContentOfBufferChanged;
            _consumerProducer.TryingToGetMessageFromBuffer += EventWithoutChangingBufferHappened;
            _consumerProducer.AddedInfoToMessageAndTryingToAddItToBuffer += EventWithoutChangingBufferHappened;

            _consumer = new Consumer(_2ndBuf);
            _consumer.MessageGotFromBuffer += ContentOfBufferChanged;
            _consumer.TryingToGetMessageFromBuffer += EventWithoutChangingBufferHappened;
            _consumer.AddedInfoToMessage += EventWithoutChangingBufferHappened;

            _producer.StartProducerThread();
            _consumerProducer.StartConsumerProducerThread();
            _consumer.StartConsumerThread();
        }       

        private void ContentOfBufferChanged(string eventDesc, bool isFirstBuffer)
        {                        
            eventsListTB.BeginInvoke(new Action(() => eventsListTB.AppendText(eventDesc + Environment.NewLine)));
            
            if (isFirstBuffer)
            {
                firstBufferContentTB.BeginInvoke(new Action(() => firstBufferContentTB.Text = _1stBuf.ToString()));
            }
            else
            {
                secondBufferContentTB.BeginInvoke(new Action(() => secondBufferContentTB.Text = _2ndBuf.ToString()));
            }            
        }        

        private void EventWithoutChangingBufferHappened(string eventDesc)
        {
            eventsListTB.BeginInvoke(new Action(() => eventsListTB.AppendText(eventDesc + Environment.NewLine)));
        }        

        private void EventWithoutChangingBufferHappened(string eventDesc, string resultMessage)
        {
            eventsListTB.BeginInvoke(new Action(() => eventsListTB.AppendText(eventDesc + Environment.NewLine)));

            resultMessagesTB.BeginInvoke(new Action(() => resultMessagesTB.AppendText(resultMessage + Environment.NewLine)));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
