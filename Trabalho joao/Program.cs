using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crud_BD; 

namespace Crud
{
    internal static class Program
    {
      
        [STAThread]
        static void Main()
        {
            Crud_BD.Banco.conectar();
            Crud_BD.Banco.CriarTabelas(); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
