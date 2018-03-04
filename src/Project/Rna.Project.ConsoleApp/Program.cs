using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rna.Foundation.XConnect;

namespace Rna.Project.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var contactIdentifier = Console.ReadLine();
            var occupation = Console.ReadLine();
            ExperienceProfileHelper.AddContact(contactIdentifier);
            ExperienceProfileHelper.AddProfileScore(contactIdentifier, occupation);
            Console.ReadLine();
        }
    }
}
