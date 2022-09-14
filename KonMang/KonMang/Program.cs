// See https://aka.ms/new-console-template for more information
using KonMang;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
try
{
    Peaklass.PlayGame(5);
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Пожалуйста заполните файл file.txt на рабочем столе и попробуйте снова.");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Пожалуйста создайте файл file.txt на рабочем столе и попробуйте снова.");
}