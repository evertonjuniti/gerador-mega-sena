namespace GeradorWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Enabled = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = checkBox7.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Enabled = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = checkBox9.Checked;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Enabled = checkBox10.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validaCheckboxes();
                validaApostas();
                fazApostas();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validaCheckboxes()
        {
            if (!(checkBox1.Checked ||
                  checkBox2.Checked ||
                  checkBox3.Checked ||
                  checkBox4.Checked ||
                  checkBox5.Checked ||
                  checkBox6.Checked ||
                  checkBox7.Checked ||
                  checkBox8.Checked ||
                  checkBox9.Checked ||
                  checkBox10.Checked))
                throw new Exception("Nenhum tipo de aposta selecionado. Favor selecionar ao menos 1 tipo.");
        }

        private void validaApostas()
        {
            List<String> erros = new List<string>();

            if (checkBox1.Checked)
                if (!validaNumero(textBox1.Text))
                    erros.Add("Número inválido para o tipo de 15 apostas;");

            if (checkBox2.Checked)
                if (!validaNumero(textBox2.Text))
                    erros.Add("Número inválido para o tipo de 14 apostas;");

            if (checkBox3.Checked)
                if (!validaNumero(textBox3.Text))
                    erros.Add("Número inválido para o tipo de 13 apostas;");

            if (checkBox4.Checked)
                if (!validaNumero(textBox4.Text))
                    erros.Add("Número inválido para o tipo de 12 apostas;");

            if (checkBox5.Checked)
                if (!validaNumero(textBox5.Text))
                    erros.Add("Número inválido para o tipo de 11 apostas;");

            if (checkBox6.Checked)
                if (!validaNumero(textBox6.Text))
                    erros.Add("Número inválido para o tipo de 10 apostas;");

            if (checkBox7.Checked)
                if (!validaNumero(textBox7.Text))
                    erros.Add("Número inválido para o tipo de 9 apostas;");

            if (checkBox8.Checked)
                if (!validaNumero(textBox8.Text))
                    erros.Add("Número inválido para o tipo de 8 apostas;");

            if (checkBox9.Checked)
                if (!validaNumero(textBox9.Text))
                    erros.Add("Número inválido para o tipo de 7 apostas;");

            if (checkBox10.Checked)
                if (!validaNumero(textBox10.Text))
                    erros.Add("Número inválido para o tipo de 6 apostas;");

            if (erros.Count > 0)
                throw new Exception(String.Join(Environment.NewLine, erros.ToArray()));
        }

        private bool validaNumero(String numero)
        {
            int resultado;

            return int.TryParse(numero, out resultado);
        }

        private void fazApostas()
        {
            List<String> apostas = new List<string>();

            if (checkBox1.Checked)
                gerarNumeros(textBox1.Text, 15, ref apostas);

            if (checkBox2.Checked)
                gerarNumeros(textBox2.Text, 14, ref apostas);

            if (checkBox3.Checked)
                gerarNumeros(textBox3.Text, 13, ref apostas);

            if (checkBox4.Checked)
                gerarNumeros(textBox4.Text, 12, ref apostas);

            if (checkBox5.Checked)
                gerarNumeros(textBox5.Text, 11, ref apostas);

            if (checkBox6.Checked)
                gerarNumeros(textBox6.Text, 10, ref apostas);

            if (checkBox7.Checked)
                gerarNumeros(textBox7.Text, 9, ref apostas);

            if (checkBox8.Checked)
                gerarNumeros(textBox8.Text, 8, ref apostas);

            if (checkBox9.Checked)
                gerarNumeros(textBox9.Text, 7, ref apostas);

            if (checkBox10.Checked)
                gerarNumeros(textBox10.Text, 6, ref apostas);

            textBox11.Text = String.Join(Environment.NewLine, apostas.ToArray());
        }

        private void gerarNumeros(String quantidade, int numeros, ref List<String> apostas)
        {
            int quantidadeInt = int.Parse(quantidade);
            Random random = new Random();

            for (int indiceQuantidade = 1; indiceQuantidade <= quantidadeInt; indiceQuantidade++)
            {
                List<int> numerosGerados = new List<int>();

                for (int indiceNumeros = 1; indiceNumeros <= numeros; indiceNumeros++)
                {
                    bool gerar = true;

                    while(gerar)
                    {
                        int numeroGerado = random.Next(1, 61);

                        if (!numerosGerados.Contains(numeroGerado))
                        {
                            numerosGerados.Add(numeroGerado);
                            gerar = false;
                        }
                    }
                    
                }

                String aposta = "";

                numerosGerados.Sort();

                foreach (int numeroGerado in numerosGerados)
                    aposta += "-" + numeroGerado.ToString();

                apostas.Add(aposta.Substring(1, aposta.Length - 1));
            }
        }
    }
}