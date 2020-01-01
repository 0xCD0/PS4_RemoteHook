using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using PS4RemotePlayInterceptor;

namespace RemotePlayHook {
    public partial class MainForm : Form {
        #region 로컬 변수
        private bool inInjected = false;
        private int PID;
        StaticKeyCode keycode;
        #endregion

        #region 초기화
        public MainForm() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            keycode = new StaticKeyCode();
        }

        /// <summary>
        /// 초기화
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e) {
            Interceptor.Callback = new InterceptionDelegate(OnReceiveData);
            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.KeyUp += HookManager_KeyUp;
            FirstSet();
            try {
                LoadConfig();
                FirstSet();
            }
            catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 전역 키보드 후킹
        private void HookManager_KeyDown(object sender, KeyEventArgs e) {
            if (keycode.D_Up == e.KeyCode) {
                keycode._D_Up = true;
            }
            if (keycode.D_Down == e.KeyCode) {
                keycode._D_Down = true;
            }
            if (keycode.D_Left == e.KeyCode) {
                keycode._D_Left = true;
            }
            if (keycode.D_Right == e.KeyCode) {
                keycode._D_Right = true;
            }


            if (keycode.Triangle == e.KeyCode) {
                keycode._Triangle = true;
            }
            if (keycode.Square == e.KeyCode) {
                keycode._Square = true;
            }
            if (keycode.Circle == e.KeyCode) {
                keycode._Circle = true;
            }
            if (keycode.Cross == e.KeyCode) {
                keycode._Cross = true;
            }

            if (keycode.Option == e.KeyCode) {
                keycode._Option = true;
            }
            if (keycode.Share == e.KeyCode) {
                keycode._Share = true;
            }

            if (keycode.L1 == e.KeyCode) {
                keycode._L1 = true;
            }
            if (keycode.L2 == e.KeyCode) {
                keycode._L2 = true;
            }
            if (keycode.L3 == e.KeyCode) {
                keycode._L3 = true;
            }
            if (keycode.R1 == e.KeyCode) {
                keycode._R1 = true;
            }
            if (keycode.R2 == e.KeyCode) {
                keycode._R2 = true;
            }
            if (keycode.R3 == e.KeyCode) {
                keycode._R3 = true;
            }

            if (keycode.LA_Left == e.KeyCode) {
                keycode._LA_Left = true;
            }
            if (keycode.LA_Right == e.KeyCode) {
                keycode._LA_Right = true;
            }
            if (keycode.LA_Up == e.KeyCode) {
                keycode._LA_Up = true;
            }
            if (keycode.LA_Down == e.KeyCode) {
                keycode._LA_Down = true;
            }

            if (keycode.RA_Left == e.KeyCode) {
                keycode._RA_Left = true;
            }
            if (keycode.RA_Right == e.KeyCode) {
                keycode._RA_Right = true;
            }
            if (keycode.RA_Up == e.KeyCode) {
                keycode._RA_Up = true;
            }
            if (keycode.RA_Down == e.KeyCode) {
                keycode._RA_Down = true;
            }

            if (keycode.TouchLeft == e.KeyCode) {
                keycode._TouchLeft = true;
            }
            if (keycode.TouchRight == e.KeyCode) {
                keycode._TouchRight = true;
            }
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e) {
            if (keycode.D_Up == e.KeyCode) {
                keycode._D_Up = false;
            }
            if (keycode.D_Down == e.KeyCode) {
                keycode._D_Down = false;
            }
            if (keycode.D_Left == e.KeyCode) {
                keycode._D_Left = false;
            }
            if (keycode.D_Right == e.KeyCode) {
                keycode._D_Right = false;
            }


            if (keycode.Triangle == e.KeyCode) {
                keycode._Triangle = false;
            }
            if (keycode.Square == e.KeyCode) {
                keycode._Square = false;
            }
            if (keycode.Circle == e.KeyCode) {
                keycode._Circle = false;
            }
            if (keycode.Cross == e.KeyCode) {
                keycode._Cross = false;
            }

            if (keycode.Option == e.KeyCode) {
                keycode._Option = false;
            }
            if (keycode.Share == e.KeyCode) {
                keycode._Share = false;
            }

            if (keycode.L1 == e.KeyCode) {
                keycode._L1 = false;
            }
            if (keycode.L2 == e.KeyCode) {
                keycode._L2 = false;
            }
            if (keycode.L3 == e.KeyCode) {
                keycode._L3 = false;
            }
            if (keycode.R1 == e.KeyCode) {
                keycode._R1 = false;
            }
            if (keycode.R2 == e.KeyCode) {
                keycode._R2 = false;
            }
            if (keycode.R3 == e.KeyCode) {
                keycode._R3 = false;
            }

            if (keycode.LA_Left == e.KeyCode) {
                keycode._LA_Left = false;
            }
            if (keycode.LA_Right == e.KeyCode) {
                keycode._LA_Right = false;
            }
            if (keycode.LA_Up == e.KeyCode) {
                keycode._LA_Up = false;
            }
            if (keycode.LA_Down == e.KeyCode) {
                keycode._LA_Down = false;
            }

            if (keycode.RA_Left == e.KeyCode) {
                keycode._RA_Left = false;
            }
            if (keycode.RA_Right == e.KeyCode) {
                keycode._RA_Right = false;
            }
            if (keycode.RA_Up == e.KeyCode) {
                keycode._RA_Up = false;
            }
            if (keycode.RA_Down == e.KeyCode) {
                keycode._RA_Down = false;
            }

            if (keycode.TouchLeft == e.KeyCode) {
                keycode._TouchLeft = false;
            }
            if (keycode.TouchRight == e.KeyCode) {
                keycode._TouchRight = false;
            }
        }
        #endregion

        #region Dualshock Receive Data Callback
        /// <summary>
        /// Dualshock ReceiveData 콜백입니다.
        /// </summary>
        private void OnReceiveData(ref DualShockState state) {
            #region Digital
            state.DPad_Up = keycode._D_Up;
            state.DPad_Down = keycode._D_Down;
            state.DPad_Left = keycode._D_Left;
            state.DPad_Right = keycode._D_Right;

            state.Triangle = keycode._Triangle;
            state.Square = keycode._Square;
            state.Circle = keycode._Circle;
            state.Cross = keycode._Cross;

            state.Options = keycode._Option;
            state.Share = keycode._Share;

            state.TouchButton = keycode._TouchLeft || keycode._TouchRight;
            #endregion

            #region LR Trigger
            state.L1 = keycode._L1;

            if (keycode._L2) {
                state.L2 = 255;
            }
            else {
                state.L2 = 0;
            }
            state.L3 = keycode._L3;

            state.R1 = keycode._R1;

            if (keycode._R2) {
                state.R2 = 255;
            }
            else {
                state.R2 = 0;
            }
            state.R3 = keycode._R3;
            #endregion

            #region Left Analog Trigger
            if (keycode._LA_Left) {
                state.LX = 0;
            }
            else {
                state.LX = 128;
                state.LY = 128;
            }

            if (keycode._LA_Right) {
                state.LX = 255;
            }
            else {
                state.LX = 128;
                state.LY = 128;
            }

            if (keycode._LA_Up) {
                state.LY = 0;
            }
            else {
                state.LX = 128;
                state.LY = 128;
            }

            if (keycode._LA_Down) {
                state.LY = 255;
            }
            else {
                state.LX = 128;
                state.LY = 128;
            }

            #endregion

            #region Right Analog Trigger
            if (keycode._RA_Left) {
                state.RX = 0;
            }
            else {
                state.RX = 128;
                state.RY = 128;
            }

            if (keycode._RA_Right) {
                state.RX = 255;
            }
            else {
                state.RX = 128;
                state.RY = 128;
            }

            if (keycode._RA_Up) {
                state.RY = 0;
            }
            else {
                state.RX = 128;
                state.RY = 128;
            }

            if (keycode._RA_Down) {
                state.RY = 255;
            }
            else {
                state.RX = 128;
                state.RY = 128;
            }

            #endregion
        }
        #endregion

        #region Event Handler
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                Process.GetProcessById(PID).Kill();
                Interceptor.StopInjection();

            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btn_remoteplay_Click(object sender, EventArgs e) {
            try {
                if (inInjected == false) {
                    Interceptor.EmulateController = true;
                    Interceptor.Watchdog.Start();
                    PID = Interceptor.Inject();
                    inInjected = true;
                }
                else {
                    Interceptor.EmulateController = false;
                    Interceptor.Watchdog.Stop();
                    Interceptor.StopInjection();
                    inInjected = false;
                }
                UpdateUI();
            }
            catch (Exception ex) {
                MessageBox.Show("RemotePlay가 실행되지 않았습니다. RemotePlay를 실행시킨 후 다시 시도하여 주십시오.", "오류");
            }

        }

        private void btn_save_Click(object sender, EventArgs e) {
            try {
                BinaryFormatter serializer = new BinaryFormatter();
                Stream stream = File.Open("config.cfg", FileMode.Create);

                serializer.Serialize(stream, keycode);
                stream.Close();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        #region 키 바인딩
        private void text_L2_MouseDown(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.L2 = dlg.keyCode;
            text_L2.Text = dlg.keyCode.ToString();
        }

        private void text_L1_MouseDown(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.L1 = dlg.keyCode;
            text_L1.Text = dlg.keyCode.ToString();
        }

        private void text_Up_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.D_Up = dlg.keyCode;
            text_Up.Text = dlg.keyCode.ToString();
        }

        private void text_Down_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.D_Down = dlg.keyCode;
            text_Down.Text = dlg.keyCode.ToString();
        }

        private void text_Left_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.D_Left = dlg.keyCode;
            text_Left.Text = dlg.keyCode.ToString();
        }

        private void text_Right_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.D_Right = dlg.keyCode;
            text_Right.Text = dlg.keyCode.ToString();
        }

        private void text_LAUp_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.LA_Up = dlg.keyCode;
            text_LAUp.Text = dlg.keyCode.ToString();
        }

        private void text_LADown_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.LA_Down = dlg.keyCode;
            text_LADown.Text = dlg.keyCode.ToString();
        }

        private void text_LALeft_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.LA_Left = dlg.keyCode;
            text_LALeft.Text = dlg.keyCode.ToString();
        }

        private void text_LARight_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.LA_Right = dlg.keyCode;
            text_LARight.Text = dlg.keyCode.ToString();
        }

        private void text_L3_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.L3 = dlg.keyCode;
            text_L3.Text = dlg.keyCode.ToString();
        }

        private void text_TouchLeft_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.TouchLeft = dlg.keyCode;
            text_TouchLeft.Text = dlg.keyCode.ToString();
        }

        private void text_Share_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Share = dlg.keyCode;
            text_Share.Text = dlg.keyCode.ToString();
        }

        private void text_Option_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Option = dlg.keyCode;
            text_Option.Text = dlg.keyCode.ToString();
        }

        private void Text_TouchRight_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.TouchRight = dlg.keyCode;
            text_TouchRight.Text = dlg.keyCode.ToString();
        }

        private void text_R2_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.R2 = dlg.keyCode;
            text_R2.Text = dlg.keyCode.ToString();
        }

        private void text_R1_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.R1 = dlg.keyCode;
            text_R1.Text = dlg.keyCode.ToString();
        }

        private void text_Triangle_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Triangle = dlg.keyCode;
            text_Triangle.Text = dlg.keyCode.ToString();
        }

        private void text_Circle_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Circle = dlg.keyCode;
            text_Circle.Text = dlg.keyCode.ToString();
        }

        private void text_Cross_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Cross = dlg.keyCode;
            text_Cross.Text = dlg.keyCode.ToString();
        }

        private void text_Square_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.Square = dlg.keyCode;
            text_Square.Text = dlg.keyCode.ToString();
        }

        private void text_RAUp_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.RA_Up = dlg.keyCode;
            text_RAUp.Text = dlg.keyCode.ToString();
        }

        private void text_RADown_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.RA_Down = dlg.keyCode;
            text_RADown.Text = dlg.keyCode.ToString();
        }

        private void text_RALeft_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.RA_Left = dlg.keyCode;
            text_RALeft.Text = dlg.keyCode.ToString();
        }

        private void text_RARight_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.RA_Right = dlg.keyCode;
            text_RARight.Text = dlg.keyCode.ToString();
        }

        private void text_R3_MouseClick(object sender, MouseEventArgs e) {
            KeyBindForm dlg = new KeyBindForm();
            dlg.ShowDialog();

            keycode.R3 = dlg.keyCode;
            text_R3.Text = dlg.keyCode.ToString();
        }
        #endregion
        #endregion

        #region 내부 함수
        private void UpdateUI() {
            btn_remoteplay.Text = inInjected == true ? "리모트 플레이 연결 해제" : "리모트 플레이 연결";
        }

        private void LoadConfig() {
            try {
                Stream stream = File.Open("config.cfg", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();

                keycode = (StaticKeyCode)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void FirstSet() {
            text_L2.Text = keycode.L2.ToString();
            text_L1.Text = keycode.L1.ToString();
            text_Up.Text = keycode.D_Up.ToString();
            text_Down.Text = keycode.D_Down.ToString();
            text_Left.Text = keycode.D_Left.ToString();
            text_Right.Text = keycode.D_Right.ToString();
            text_LAUp.Text = keycode.LA_Up.ToString();
            text_LADown.Text = keycode.LA_Down.ToString();
            text_LALeft.Text = keycode.LA_Left.ToString();
            text_LARight.Text = keycode.LA_Right.ToString();
            text_L3.Text = keycode.L3.ToString();
            text_TouchLeft.Text = keycode.TouchLeft.ToString();
            text_Share.Text = keycode.Share.ToString();
            text_Option.Text = keycode.Option.ToString();
            text_TouchRight.Text = keycode.TouchRight.ToString();
            text_R2.Text = keycode.R2.ToString();
            text_R1.Text = keycode.R1.ToString();
            text_Triangle.Text = keycode.Triangle.ToString();
            text_Circle.Text = keycode.Circle.ToString();
            text_Cross.Text = keycode.Cross.ToString();
            text_Square.Text = keycode.Square.ToString();

            text_RAUp.Text = keycode.RA_Up.ToString();
            text_RADown.Text = keycode.RA_Down.ToString();
            text_RALeft.Text = keycode.RA_Left.ToString();
            text_RARight.Text = keycode.RA_Right.ToString();
            text_R3.Text = keycode.R3.ToString();
        }
        #endregion

        private void link_page_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://mos6502.tistory.com/");
        }
    }
}
