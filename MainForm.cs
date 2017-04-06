using System;
using System.Windows.Forms;
using DSASimpesFaipBridge;
using IDTModule;
using Microsoft.Practices.Unity;

namespace IDTTest
{
    public partial class MainForm : Form
    {
// ReSharper disable once NotAccessedField.Local
        private IUnityContainer _container;

        private readonly DSASimpesFaipBridge.Bridge _bridge;

        public MainForm(IUnityContainer container, Bridge bridge)
        {
            InitializeComponent();
            _container = container;
            _bridge = bridge;
            _bridge.Start();
            _bridge.DiagnosticMessage += BridgeOnDiagnosticMessage;
        }

        private void BridgeOnDiagnosticMessage(object sender, BridgeBase.DiagnosticEventArgs diagnosticEventArgs)
        {
            Action act = delegate
            {
                string s = diagnosticEventArgs.Message;
                lstMessage.Items.Add(s);
                lstMessage.SelectedIndex = (lstMessage.Items.Count - 1);
            };
            if (InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bridge.StopAndWait();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstMessage.Items.Clear();
        }
    }
}
