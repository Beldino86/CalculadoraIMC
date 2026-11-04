using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CalculadoraIMC;

public class Form1 : Form
{
    private Label lblTitulo = new Label();
    private Label lblPesoTxt = new Label();
    private Label lblAlturaTxt = new Label();
    private TextBox txtPeso = new TextBox();
    private TextBox txtAltura = new TextBox();
    private Button btnCalcular = new Button();
    private Label lblResultado = new Label();

    public Form1()
    {
        Text = "Calculadora de IMC";
        ClientSize = new Size(420, 340);
        StartPosition = FormStartPosition.CenterScreen;

        lblTitulo.Text = "Calculadora de IMC";
        lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(0, 100, 180);
        lblTitulo.AutoSize = true;
        lblTitulo.Location = new Point(90, 15);

        lblPesoTxt.Text = "Peso (kg):";
        lblPesoTxt.AutoSize = true;
        lblPesoTxt.Location = new Point(30, 70);

        txtPeso.Name = "txtPeso";
        txtPeso.PlaceholderText = "Digite o seu peso...";
        txtPeso.Location = new Point(30, 92);
        txtPeso.Size = new Size(360, 27);

        lblAlturaTxt.Text = "Altura (m):";
        lblAlturaTxt.AutoSize = true;
        lblAlturaTxt.Location = new Point(30, 135);

        txtAltura.Name = "txtAltura";
        txtAltura.PlaceholderText = "Digite a sua altura (ex: 1.75)...";
        txtAltura.Location = new Point(30, 157);
        txtAltura.Size = new Size(360, 27);

        btnCalcular.Name = "btnCalcular";
        btnCalcular.Text = "Calcular IMC";
        btnCalcular.Location = new Point(30, 205);
        btnCalcular.Size = new Size(150, 50);
        btnCalcular.Click += btnCalcular_Click;

        AcceptButton = btnCalcular;

        lblResultado.Name = "lblResultado";
        lblResultado.Text = "Resultado do IMC e Classificação aparecerá aqui.";
        lblResultado.Location = new Point(30, 270);
        lblResultado.Size = new Size(360, 50);

        Controls.AddRange(new Control[] {
            lblTitulo, lblPesoTxt, txtPeso, lblAlturaTxt,
            txtAltura, btnCalcular, lblResultado });
    }

    private void btnCalcular_Click(object? sender, EventArgs e)
    {
        if (!TryLerNumero(txtPeso.Text, out double peso) ||
            !TryLerNumero(txtAltura.Text, out double altura))
        {
            lblResultado.ForeColor = Color.Firebrick;
            lblResultado.Text = "Introduza apenas valores numéricos válidos (ex.: 75,5 e 1,75).";
            return;
        }

        if (peso <= 0 || altura <= 0)
        {
            lblResultado.ForeColor = Color.Firebrick;
            lblResultado.Text = "Peso e altura devem ser maiores que zero.";
            return;
        }

        double imc = peso / (altura * altura);

        string classificacao;
        if (imc < 18.5) classificacao = "Abaixo do peso";
        else if (imc < 25) classificacao = "Peso normal";
        else if (imc < 30) classificacao = "Sobrepeso";
        else if (imc < 35) classificacao = "Obesidade grau I";
        else if (imc < 40) classificacao = "Obesidade grau II";
        else classificacao = "Obesidade grau III";

        lblResultado.ForeColor = imc < 18.5 || imc >= 30
            ? Color.Firebrick
            : imc < 25 ? Color.SeaGreen : Color.DarkOrange;
        lblResultado.Text = $"IMC: {imc:F2} - {classificacao}";
    }

    /// <summary>
    /// Converte o texto de forma segura, aceitando ponto ou vírgula como
    /// separador decimal e rejeitando valores não finitos (NaN/Infinito).
    /// </summary>
    private static bool TryLerNumero(string texto, out double valor)
    {
        string normalizado = texto.Trim().Replace(',', '.');
        return double.TryParse(normalizado, NumberStyles.Float,
                   CultureInfo.InvariantCulture, out valor)
               && double.IsFinite(valor);
    }
}
