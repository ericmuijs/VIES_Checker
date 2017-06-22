using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIES_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            VIES_Model VIES_request = new VIES_Model("NL", "810518740B01");
            VIES_request.getDetailVATWithVerification("NL", "810518740B01");
            VIES_request.PrintInConsole();
            Console.ReadKey();
        }
    }
}
