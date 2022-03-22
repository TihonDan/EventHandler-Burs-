using System;

namespace eventArgs
{
    public class Publisher
    {
        public event EventHandler<char> OnPressKey;// Создал делегат
        
        public void Run()
        {
            do
            {
                Console.WriteLine("Введите символ");
                char e = char.Parse(Console.ReadLine());
                OnPressKey?.Invoke(this, e);// Событие

            } while (true);
        }

        
    }

    public class Subscription
    {
        public void SomeMethod()
        {
            var eventSub = new Publisher();
            eventSub.OnPressKey += Method;// Создание подписки
            eventSub.Run();

        }
        public void Method(object sender, char letter)// Подписчик
        {
            Console.WriteLine($"Символ {letter} ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subscription sub = new Subscription();
            sub.SomeMethod();
        }
    }

}
