using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DSASimpesFaipBridge.Request;
using IDTModule;
using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using UtilityLib.Config;
using UtilityLib.Exceptions;
using UtilityLib.Ini;

namespace IDTTest
{
    static class Program
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitLogging();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnityContainer container;
            MainForm mf = null;
            try
            {
                container = SetupIOC();
                if (container == null)
                    return;
                mf = container.Resolve<MainForm>();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerMostException();
                MessageBox.Show(inner.Message);
                return;
            }


            container.RegisterInstance<ISynchronizeInvoke>(mf);

            Application.Run(mf);
        }

        private static void InitLogging()
        {
            XmlConfigurator.Configure();
        }


        private static UnityContainer SetupIOC()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);
            MemIni ini = new MemIni();
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string pathFile = Path.Combine(appPath, "Path.ini");
            try
            {
                ini.Load(pathFile);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot load Path.ini file");
                return null;
            }
            //if the path is written in relative i convert it here

            string confPath = ini.GetKeyValue("Path", "ConfigDirectory");

            ApplicationPath path = new ApplicationPath(appPath, confPath);
            container.RegisterInstance(path);
            var configuration = container.Resolve<ApplicationConfiguration>();
            container.RegisterInstance(configuration);

            container.RegisterType<IIDTCommunicator, UDPCommunicator>();
            container.RegisterType<IServiceFactory, ServiceFactory>();

            return container;
        }
    }
}
