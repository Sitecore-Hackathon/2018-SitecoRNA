using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rna.Feature.Profile;

namespace Rna.Project.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsHelper.AddContactAndProfileScore();
            Console.ReadLine();
        }
    }
}
