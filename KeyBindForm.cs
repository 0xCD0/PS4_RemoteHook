using System.Windows.Forms;

namespace RemotePlayHook {
    public partial class KeyBindForm : Form {
        public Keys keyCode;

        public KeyBindForm() {
            InitializeComponent();
        }

        private void KeyBindForm_KeyDown(object sender, KeyEventArgs e) {
            keyCode = e.KeyCode;
            this.Close();
        }
    }
}
