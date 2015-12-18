using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Helper
{
    public class Led : Control
    {
        private readonly Timer tick;

        public Led()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Width = 17;
            Height = 17;
            tick = new Timer {Enabled = false};
            tick.Tick += this.Ontick;
        }

        private bool _Active = true;
        [Category("Behavior"),
        DefaultValue(true)]
        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                Invalidate();
            }
        }

        private Color _ColorOn = Color.Red;
        [Category("Appearance")]
        public Color ColorOn
        {
            get { return _ColorOn; }
            set
            {
                _ColorOn = value;
                Invalidate();
            }
        }

        private Color _ColorOff = SystemColors.Control;
        [Category("Appearance")]
        public Color ColorOff
        {
            get { return _ColorOff; }
            set
            {
                _ColorOff = value;
                Invalidate();
            }
        }

        private Color colorMouseCapture = Color.Red;
        [Category("Appearance")]
        public Color ColorMouseCapture
        {
            get { return colorMouseCapture; }
            set
            {
                colorMouseCapture = value;                
                Invalidate();
            }
        }

        private string _FlashIntervals = "250";
        public int[] flashIntervals = new int[1] { 250 };
        [Category("Appearance"),
        DefaultValue("250")]
        public string FlashIntervals
        {
            get { return _FlashIntervals; }
            set
            {
                _FlashIntervals = value;
                string[] fi = _FlashIntervals.Split(new char[] { ',', '/', '|', ' ', '\n' });
                flashIntervals = new int[fi.Length];
                for (int i = 0; i < fi.Length; i++)
                    try
                    {
                        flashIntervals[i] = int.Parse(fi[i]);
                    }
                    catch
                    {
                        flashIntervals[i] = 25;
                    }
            }
        }

        private string _FlashColors = string.Empty;
        public Color[] flashColors;
        private int tickIndex;

        [Category("Appearance"),
        DefaultValue("")]
        public string FlashColors
        {
            get { return _FlashColors; }
            set
            {
                _FlashColors = value;
                if (_FlashColors == string.Empty)
                {
                    flashColors = null;
                }
                else
                {
                    string[] fc = _FlashColors.Split(new char[] { ',', '/', '|', ' ', '\n' });
                    flashColors = new Color[fc.Length];
                    for (int i = 0; i < fc.Length; i++)
                        try
                        {
                            flashColors[i] = (fc[i] != "") ? Color.FromName(fc[i]) : Color.Empty;
                        }
                        catch
                        {
                            flashColors[i] = Color.Empty;
                        }
                }
            }
        }

        private bool _Flash = false;
        private bool mouseCapture;

        [Category("Behavior"),
        DefaultValue(false)]
        public bool Flash
        {
            get { return _Flash; }
            set
            {
                _Flash = value && (flashIntervals.Length > 0);
                tickIndex = 0;
                tick.Interval = flashIntervals[tickIndex];
                tick.Enabled = _Flash;
                Active = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if (Enabled)
            {
                if (Active)
                {                    
                    e.Graphics.FillEllipse(new SolidBrush(_ColorOn), 1, 1, Width - 3, Height - 3);
                    e.Graphics.DrawArc(new Pen(FadeColor(_ColorOn,
                               Color.White, 1, 2), 2), 3, 3, Width - 7,
                               Height - 7, -90.0F, -90.0F);
                    e.Graphics.DrawEllipse(new Pen(FadeColor(_ColorOn,
                               Color.Black), 1), 1, 1, Width - 3, Height - 3);
                }
                else if (mouseCapture)
                {
                    var color = Color.FromArgb(0x80, colorMouseCapture);
                    e.Graphics.FillEllipse(new SolidBrush(color), 1, 1, Width - 3, Height - 3);
                    e.Graphics.DrawArc(new Pen(FadeColor(color,
                               Color.White, 1, 2), 2), 3, 3, Width - 7,
                               Height - 7, -90.0F, -90.0F);
                    e.Graphics.DrawEllipse(new Pen(FadeColor(color,
                               Color.Black), 1), 1, 1, Width - 3, Height - 3);
                }
                else
                {
                    var color = _ColorOff;                    
                    e.Graphics.FillEllipse(new SolidBrush(color), 1, 1, Width - 3, Height - 3);
                    e.Graphics.DrawArc(new Pen(FadeColor(color,
                               Color.Black, 2, 1), 2), 3, 3, Width - 7, Height - 7, 0.0F, 90.0F);
                    e.Graphics.DrawEllipse(new Pen(FadeColor(color,
                               Color.Black), 1), 1, 1, Width - 3, Height - 3);
                }
            }

            else e.Graphics.DrawEllipse(new
                            Pen(SystemColors.ControlDark, 1),
                            1, 1, Width - 3, Height - 3);
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            mouseCapture = true;
            base.OnMouseEnter(e); 
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            mouseCapture = false;
            base.OnMouseLeave(e);
            Invalidate();
        }

        private void Ontick(object sender, System.EventArgs e)
        {
            tickIndex = (++tickIndex) % (flashIntervals.Length);
            tick.Interval = flashIntervals[tickIndex];
            try
            {
                if ((flashColors == null)
                || (flashColors.Length < tickIndex)
                || (flashColors[tickIndex] == Color.Empty))
                    Active = !Active;
                else
                {
                    ColorOn = flashColors[tickIndex];
                    Active = true;
                }
            }
            catch
            {
                Active = !Active;
            }
        }

        public static Color FadeColor(Color c1, Color c2, int i1, int i2)
        {
            int r = (i1 * c1.R + i2 * c2.R) / (i1 + i2);
            int g = (i1 * c1.G + i2 * c2.G) / (i1 + i2);
            int b = (i1 * c1.B + i2 * c2.B) / (i1 + i2);

            return Color.FromArgb(r, g, b);
        }

        public static Color FadeColor(Color c1, Color c2)
        {
            return FadeColor(c1, c2, 1, 1);
        }
    }
}