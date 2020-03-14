using System;
using System.Windows.Forms;
using Ninject;
using ScriptGenerator.Extensibility;

namespace Editor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var scriptGenerator = GetScriptGenerator();

            Application.Run(new Form1(scriptGenerator));
        }

        private static IScriptGenerator GetScriptGenerator()
        {
            var kernel = new StandardKernel();
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
            return kernel.Get<IScriptGenerator>();
        }
    }
}