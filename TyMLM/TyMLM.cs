using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ty_Speedrun_Memory_Handler
{
    public partial class TyMLM: Form
    {
        public TyMLM()
        {
            InitializeComponent();
            Font = new Font(mFontCollection.Families[0], 12.5F);
            MemUsage.Font = new Font(mFontCollection.Families[0], 25.5F);
        }
    }
}
