using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlgoritmLi
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int nx = 0;
            int ny = 0;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("data.xml");

            int width = Convert.ToInt32(xDoc.SelectSingleNode("Alg/Size/Width").InnerText);
            int height = Convert.ToInt32(xDoc.SelectSingleNode("Alg/Size/Height").InnerText);

            WaveAlg Path = new WaveAlg(width, height);

            //заполняем карту препятствиями
            foreach (XmlNode node in xDoc.SelectNodes("Alg/Blocks/Block"))
            {
                x = Convert.ToInt32(node.SelectSingleNode("X").InnerText);
                y = Convert.ToInt32(node.SelectSingleNode("Y").InnerText);
                Path.block(x, y);
            }

            Path.traceOut();
            Console.WriteLine();
            try {
                Console.WriteLine("Введите x начала");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите y начала");
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите x конца");
                nx = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите y конца");
                ny = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Вводите числа!");
            }
            Path.findPath(x, y, nx, ny);

            Path.traceOut();
            Console.WriteLine();

            Path.waveOut();
        }
    }
}
