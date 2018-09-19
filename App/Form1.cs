using System;
using System.Windows.Forms;
using LibVagas;

namespace App
{
    public partial class Form1 : Form
    {
        // Carrega nova instância do componente
        //-------------------------------------
        IDisplay disp = new Display();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Utiliza o atributo "_dispIp" para informar o IP do painel no componente
            //-------------------------------------------------------------------------
            disp._dispIp = "192.168.0.111";
            textBox_ipserver.Text = "192.168.0.111";

            // Liga timer para enviar informações para o painel em intervalos de 1 seg.
            //--------------------------------------------------------------------------
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            // Utiliza o atributo "_dispIp" para mudar o IP do painel no componente
            //----------------------------------------------------------------------
            disp._dispIp = textBox_ipserver.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Utiliza o método "Show" para enviar informações ao painel
            //-----------------------------------------------------------
            if (disp.Show(
                string.Format("{0:D3}", (int)numericUpDown1.Value),
                string.Format("{0:D3}", (int)numericUpDown2.Value),
                string.Format("{0:D3}", (int)numericUpDown3.Value),
                string.Format("{0:D3}", (int)numericUpDown4.Value),
                string.Format("{0:D3}", (int)numericUpDown5.Value),
                string.Format("{0:D3}", (int)numericUpDown6.Value)))
            {
                // Comunicou corretamente...
                // Mostra horário de envio e resultado através do atributo "_status"
                //-------------------------------------------------------------------
                textBox1.Text = "Enviando em: " + DateTime.Now.ToString() + Convert.ToChar(13) + Convert.ToChar(10);
                textBox1.Text += disp._status + Convert.ToChar(13) + Convert.ToChar(10);
            }
            else
            {
                // Não comunicou corretamente...
                // Mostra horário de envio e resultado através do atributo "_status"
                //-------------------------------------------------------------------
                textBox1.Text = "Enviando em: " + DateTime.Now.ToString() + Convert.ToChar(13) + Convert.ToChar(10);
                textBox1.Text += disp._status + Convert.ToChar(13) + Convert.ToChar(10);
            }
        }
    }
}
