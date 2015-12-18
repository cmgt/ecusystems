using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace IoControlPlugin
{
    internal partial class IoControl : UserControl
    {
        private float min;
        private float max;
        private float scaleMultiplier;
        private readonly Timer timer;

        public event EventHandler ActiveChanging;
        public event EventHandler CurrentValueChange;

        public string Description
        {
            get { return descriptionLabel.Text; }
            set { descriptionLabel.Text = value; }
        }

        [DefaultValue(false)]
        public bool FloatPoint { get; set; }

        [DefaultValue(10f)]
        public float Max
        {
            get { return max; }
            set
            {
                max = value;                
                PrepareTrackBar();
            }
        }


        [DefaultValue(0f)]
        public float Min
        {
            get { return min; }
            set
            {
                min = value;                
                PrepareTrackBar();
            }
        }

        private bool active;
        private const double timerInterval = 200;

        [DefaultValue(false)]
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                captureLed.Active = active;
            }
        }

        public IoControl()
        {
            InitializeComponent();
            min = currentValueTrack.Minimum;
            max = currentValueTrack.Maximum;
            scaleMultiplier = 1f;
            timer = new Timer(timerInterval) {SynchronizingObject = this, AutoReset = false};
            timer.Elapsed += (sender, args) => OnCurrentValueChange(EventArgs.Empty);
        }

        private void PrepareTrackBar()
        {
            scaleMultiplier = 20f / (max - min);

            currentValueTrack.Maximum = (int)Math.Ceiling(max * scaleMultiplier);
            currentValueTrack.Minimum = (int)Math.Floor(min * scaleMultiplier);
            var length = currentValueTrack.Maximum - currentValueTrack.Minimum;

            currentValueTrack.LargeChange = length/5;
            currentValueTrack.SmallChange = length/20;
            currentValueTrack.Value = (int)(currentValueTrack.Minimum + length / 2f);
            SetTextBoxValue(currentValueTrack.Value / scaleMultiplier);
        }

        private void OnActiveChanging(EventArgs e)
        {
            var handler = ActiveChanging;
            if (handler != null) handler(this, e);
        }

        private void OnCurrentValueChange(EventArgs e)
        {
            var handler = CurrentValueChange;
            if (handler != null) handler(this, e);
        }

        private void currentValueTrack_Scroll(object sender, EventArgs e)
        {
            SetTextBoxValue(currentValueTrack.Value / scaleMultiplier);
            if (!Active)
            {
                Active = true;
            }
            timer.Interval = timerInterval;
            timer.Start();
        }

        private void SetTextBoxValue(float value)
        {
            string text;

            if (FloatPoint)
            {
                text =
                    Math.Max(
                        Math.Min(Math.Round(value, 2, MidpointRounding.AwayFromZero),
                                 max), min).ToString("0.##", CultureInfo.InvariantCulture);
            }
            else
            {
                text =
                    Math.Max(
                        Math.Min(Math.Round(value, MidpointRounding.AwayFromZero), max),
                        min).ToString();
            }

            currentValue.Text = text;
        }

        private void SetTrackBarValue(float value)
        {
            currentValueTrack.Value = (int)Math.Round(value * scaleMultiplier, MidpointRounding.AwayFromZero);
        }

        private void currentValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            var value = GetCurrentvalue();
            if (!value.Item1) return;
            currentValue.Text = value.Item3.ToString();
            SetTrackBarValue(value.Item3);
            OnCurrentValueChange(EventArgs.Empty);
        }

        public Tuple<bool, string, float> GetCurrentvalue()
        {
            float value;
            var ic = CultureInfo.InvariantCulture;
            var res = false;
            string source = currentValue.Text
                .Replace(".", ic.NumberFormat.NumberDecimalSeparator)
                .Replace(",", ic.NumberFormat.NumberDecimalSeparator);

            if (float.TryParse(source, NumberStyles.Float, ic, out value))
            {
                value = Math.Max(Math.Min(value, max), min);
                res = true;
            }

            return new Tuple<bool, string, float>(res, currentValue.Text, FloatPoint ? value : (int)Math.Round(value, MidpointRounding.AwayFromZero));
        }

        public void SetCurrentValue(float value)
        {
            value = Math.Max(Math.Min(value, max), min);
            SetTextBoxValue(value);
            SetTrackBarValue(value);
        }

        private void captureLed_Click(object sender, EventArgs e)
        {           
            OnActiveChanging(EventArgs.Empty);
        }
    }
}
