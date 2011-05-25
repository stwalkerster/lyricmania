using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LyricMania
{
    public partial class Control : Form
    {
        public Control( )
        {
            InitializeComponent( );
        }

        string lrc = "Q:\\temp.lrc";
            
            string mp3 = "Q:\\PortableApps\foobar2000\foobar2000.exe";

        private void button1_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            if( ofd.ShowDialog( ) == DialogResult.OK )
                mp3 = label1.Text = ofd.FileName;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            SaveFileDialog ofd = new SaveFileDialog( );
            if( ofd.ShowDialog( ) == DialogResult.OK )
                lrc = label2.Text = ofd.FileName;
        }

        private void button3_Click( object sender, EventArgs e )
        {
            new PlayForm( lrc, textBox1.Lines, mp3 ).Show( );
        }

        private void Control_Load( object sender, EventArgs e )
        {
            label1.Text = mp3;
            label2.Text = lrc;
        }

    }
}
