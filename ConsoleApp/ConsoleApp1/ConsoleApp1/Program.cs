using System.Reflection;

namespace ConsoleApp1;

/*public class kek
{
    public
        int x = 5;
    public
        int z = 10;
    private
        int _y = 3;
}*/
class Program
{
    static void Main(string[] args)
    {
        // принимаем только 1 аргумент на вход - имя файла
        if (args.Length != 1)
        {
            Console.WriteLine("Please, enter just one input file");
            return;
        }
        // проверка на существование файла по указанному пути
        string input = args[0];
        if (File.Exists(input) == false)
        {
            Console.WriteLine("Your file doesnt exist! :(");
            return;
        }
        // записываем файл 
        var fContent = File.ReadLines(input);
        // в эту штуковину записываются все аргументы метода, насколько я понял
        Object[] arguments = { fContent };
        // создаем экземпляр класса и определяем его тип, чтобы далее получить нужный метод
        var obj = new ClassLibrary1.Class1();
        
        var type = typeof(ClassLibrary1.Class1);
        // получаем метод инфо
        var m_info = type.GetMethod("parse", BindingFlags.NonPublic | BindingFlags.Instance);
        // вызываем полученный метод
        var res = (Dictionary<string, int>) m_info.Invoke(obj, arguments);


        if (res == null)
        {
            Console.WriteLine("GOODBUy!");
            return;
        }

        var sort_words = res.OrderByDescending(_ => _.Value);
        using (StreamWriter file = new StreamWriter("output.txt"))
        {
            foreach (var row in sort_words)
            {
                file.WriteLine($"{row.Key} {row.Value}");
            }
        }
        Console.WriteLine("Complited!");
    }
}