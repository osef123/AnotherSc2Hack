using System;
using System.Windows.Forms;
using System.Drawing;

namespace Another_SC2_Hack.Classes
{
    class BufferPanel : Panel
    {
        private readonly Timer _tmrTick;
        private int _iMaxItems = 2;
        private int _iCurrentItem = 0;
        public BufferPanel()
        {
            /*** Disable Flickering ***/
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);

            _tmrTick = new Timer();
            _tmrTick.Tick += tmrTick_Tick;
            _tmrTick.Interval = 100;
            _tmrTick.Enabled = true;
        }

        void tmrTick_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //How much will be painted.
            float ifilledWidth = (Width - ((_iMaxItems - (_iMaxItems - 1 ) * 2))) / _iMaxItems;
            //ifilledWidth--;
            


            for (int i = 0; i < _iMaxItems; i++)
            {
                //Fill the needed one
                if (_iCurrentItem.Equals(i + 1))
                    e.Graphics.FillRectangle(Brushes.Gray, i*ifilledWidth, 0, ifilledWidth - 2, 10);             

                if (i == _iMaxItems - 1)
                    e.Graphics.DrawRectangle(Pens.Black, i * ifilledWidth, 0, ifilledWidth - i, 10);

                //The last one has to be seperated..
                else
                    e.Graphics.DrawRectangle(Pens.Black, i * ifilledWidth, 0, ifilledWidth - 2, 10);
                
            }
        }



        public int MaxItem
        {
            get { return _iMaxItems; }
            set { _iMaxItems = value; }
        }

        public int CurrentItem
        {
            get { return _iCurrentItem; }
            set { _iCurrentItem = value; }
        }

    }
}
