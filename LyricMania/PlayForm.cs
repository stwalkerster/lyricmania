using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LyricMania
{
    public partial class PlayForm : Form
    {

        string file, program;
        string[ ] lyrics;
        DateTime d;
        int next;
        Queue<LyricLine> timedLyrics;


        public PlayForm( string lrcFile, string[] lyrics, string program )
        {
            InitializeComponent( );
            file = lrcFile;
            this.program = program;
            this.lyrics = lyrics;
            label2.Text = "";
            label3.Text = lyrics[ 0 ];
            next = 0;
            timedLyrics = new Queue<LyricLine>( );
        }

        private void timer1_Tick( object sender, EventArgs e )
        {
            label1.Text = time( );
        }

        private string time( )
        {
            TimeSpan ts = DateTime.Now - d;
            return ts.Minutes.ToString( ).PadLeft( 2, '0' ) + ":" +
                    ts.Seconds.ToString( ).PadLeft( 2, '0' ) + "." +
                    ts.Milliseconds.ToString( );
        }

        private void PlayForm_Load( object sender, EventArgs e )
        {
            timer1.Start( );
            d = DateTime.Now;
            Process.Start( "Q:\\PortableApps\\foobar2000\\foobar2000.exe", "/play" );

        }

        private void button1_Click( object sender, EventArgs e )
        {
            next++;
            label2.Text = label3.Text;
            timedLyrics.Enqueue( new LyricLine( time( ), label2.Text ) );
            if( lyrics.Length > next )
                label3.Text = lyrics[ next ];
            else
                label3.Text = "";
          

        }

        private void button2_Click( object sender, EventArgs e )
        {
            Process.Start( "Q:\\PortableApps\\foobar2000\\foobar2000.exe", "/stop" );
            StreamWriter sw = new StreamWriter( file );
            while( timedLyrics.Count != 0 )
            {
                sw.WriteLine( timedLyrics.Dequeue( ).ToString( ) );
            }
            sw.Flush( );
        }
    }
}
