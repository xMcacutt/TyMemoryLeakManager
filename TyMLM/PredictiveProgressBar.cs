using System.Drawing;
using System.Windows.Forms;

public class PredictiveProgressBar : ProgressBar
{
    public int PredictedValue { get; set; }
    public int MemValue { get; set; }
    public Color PredictedColor { get; set; }

    public PredictiveProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Value = 0;
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        Rectangle pRect = new Rectangle(0, 0, Width, Height);
        ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rect);

        int mainWidth = (int)((rect.Width / (double)Maximum) * MemValue);
        pRect.Width = (int)(((rect.Width) / (double)Maximum) * (PredictedValue + MemValue)); // Calculate the width of the predictive rectangle based on the remaining space

        if (pRect.Width > 0)
        {
            using (SolidBrush brush = new SolidBrush(PredictedColor))
            {
                e.Graphics.FillRectangle(brush, pRect);
            }
        }

        if (mainWidth > 0)
        {
            using (SolidBrush brush = new SolidBrush(ForeColor))
            {
                e.Graphics.FillRectangle(brush, 0, 0, mainWidth, Height);
            }
        }

        base.OnPaint(e);
    }
}