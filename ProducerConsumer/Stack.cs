using System;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    // Класс стека (буфер по условию)
    public class Stack
    {
        // Семафоры с кол-вом заполненных и пустых мест в стеке
        Semaphore _filledCount, _emptyCount;
        // Мьютекс для ограничения доступа к стеку
        Mutex _useStack;

        string[] _arr;

        public Stack(int maxCapacity)
        {
            _arr = new string[maxCapacity];
            Count = 0;
            Capacity = maxCapacity;

            // Кол-во пустых мест в стеке при его объявлении равно общему кол-ву мест в нём
            _emptyCount = new Semaphore(maxCapacity, maxCapacity);
            // Кол-во заполненных мест равно нулю
            _filledCount = new Semaphore(0, maxCapacity);

            _useStack = new Mutex();
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public void Push(string s)
        {                       
            // Уменьшаем счетчик в семафоре с кол-вом пустых мест если это возможно,
            //      иначе ждем, пока другой поток заберет элемент из стека
            _emptyCount.WaitOne();
            // Закрываем другим потокам доступ к стеку
            _useStack.WaitOne();

            //Thread.Sleep(1000);

            _arr[Count++] = s;

            // Открываем доступ
            _useStack.ReleaseMutex();
            // Увеличиваем счетчик в семафоре с кол-вом заполненных мест
            _filledCount.Release();            
        }

        public string Pop()
        {
            string poppedString;

            // Уменьшаем счетчик в семафоре с кол-вом заполненных мест если это возможно,
            //      иначе ждем, пока другой поток добавит элемент в стек
            _filledCount.WaitOne();
            // Закрываем другим потокам доступ к стеку
            _useStack.WaitOne();

            //Thread.Sleep(1000);

            poppedString = _arr[--Count];

            // Открываем доступ
            _useStack.ReleaseMutex();
            // Увеличиваем счетчик в семафоре с кол-вом пустых мест
            _emptyCount.Release();

            return poppedString;
        }

        public string Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _arr[Count - 1];
        }

        public bool IsFull()
        {
            return (Count == _arr.Length);
        }

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public void Clear()
        {
            Count = 0;
        }       

        // Приведение стека и его содержимого в к строке
        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();

            // Закрываем другим потокам доступ к стеку
            _useStack.WaitOne();

            // Добавляем к строке пустые места
            for (int i = Capacity - 1; i >= Count; --i)
            {
                sB.Append("|        |").Append(Environment.NewLine);
            }

            // Добавляем к строке заполненные места
            for (int i = Count - 1; i >= 0; --i)
            {
                sB.Append("| ").Append($"{_arr[i], -6}").Append(" |").Append(Environment.NewLine);                
            }

            // "Закрываем" стек снизу
            sB.Append("‾‾‾‾‾‾‾‾‾‾").Append(Environment.NewLine);
            sB.Append("Всего сообщ-й: ").Append(Count).Append(Environment.NewLine);
            
            // Открываем доступ
            _useStack.ReleaseMutex();

            return sB.ToString();
        }
    }
}
