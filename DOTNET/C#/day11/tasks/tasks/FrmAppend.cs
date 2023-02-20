using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasks
{
    public partial class FrmAppend : Form
    {
        public string UserText
        {
            get => textBox1.Text;
        }

        public FrmAppend()
        {
            InitializeComponent();
        }
    }
}
