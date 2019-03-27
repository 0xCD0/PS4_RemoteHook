using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemotePlayHook {
    [Serializable()]
    public class StaticKeyCode {
        public Keys D_Up = Keys.W;
        public Keys D_Down = Keys.S;
        public Keys D_Left = Keys.A;
        public Keys D_Right = Keys.D;

        public bool _D_Up = false;
        public bool _D_Down = false;
        public bool _D_Left = false;
        public bool _D_Right = false;


        public Keys L1 = Keys.D1;
        public Keys L2 = Keys.D2;
        public Keys L3 = Keys.D9;

        public bool _L1 = false;
        public bool _L2 = false;
        public bool _L3 = false;

        public Keys R1 = Keys.D3;
        public Keys R2 = Keys.D4;
        public Keys R3 = Keys.D0;

        public bool _R1 = false;
        public bool _R2 = false;
        public bool _R3 = false;

        public Keys Triangle = Keys.O;
        public Keys Square = Keys.K;
        public Keys Circle = Keys.P;
        public Keys Cross = Keys.L;

        public bool _Triangle = false;
        public bool _Square = false;
        public bool _Circle = false;
        public bool _Cross = false;


        public Keys TouchLeft = Keys.T;
        public Keys TouchRight = Keys.Y;
        public Keys Share = Keys.R;
        public Keys Option = Keys.U;

        public bool _TouchLeft = false;
        public bool _TouchRight = false;
        public bool _Share = false;
        public bool _Option = false;

        public Keys LA_Up = Keys.Home;
        public Keys LA_Down = Keys.End;
        public Keys LA_Left = Keys.Delete;
        public Keys LA_Right = Keys.PageDown;

        public bool _LA_Up = false;
        public bool _LA_Down = false;
        public bool _LA_Left = false;
        public bool _LA_Right = false;

        public Keys RA_Up = Keys.NumPad8;
        public Keys RA_Down = Keys.NumPad5;
        public Keys RA_Left = Keys.NumPad4;
        public Keys RA_Right = Keys.NumPad6;

        public bool _RA_Up = false;
        public bool _RA_Down = false;
        public bool _RA_Left = false;
        public bool _RA_Right = false;
    }
}
