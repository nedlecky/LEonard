using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            this.TextAlign = ContentAlignment.MiddleLeft;
        }
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int h = this.ClientSize.Height - 2;
            //Rectangle rc = new Rectangle(new Point(0, 1), new Size(h, h));
            Rectangle rc = new Rectangle(new Point(0, this.Height / 2 - h / 2), new Size(h, h));
            ControlPaint.DrawCheckBox(e.Graphics, rc, this.Checked ? ButtonState.Checked : ButtonState.Normal);
        }
    }
}
