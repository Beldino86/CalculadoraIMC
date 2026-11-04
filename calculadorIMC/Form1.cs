using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace calculadorIMC;

public partial class Form1 : Form
{
    private TextBox txtPeso;
    private TextBox txtAltura;
    private Button btnCalcular;
    private Label lblResultado;

    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Calculadora de IMC";
        this.ClientSize = new Size(420, 280);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label lblPeso = new Label();
        lblPeso.Text = "Peso (kg):";
        lblPeso.Location = new Point(30, 30);
        lblPeso.AutoSize = true;

        txtPeso = new TextBox();
        txtPeso.Name = "txtPeso";
        txtPeso.Location = new Point(30, 55);
        txtPeso.Size = new Size(340, 27);

        Label lblAltura = new Label();
        lblAltura.Text = "Altura (m):";
        lblAltura.Location = new Point(30, 95);
        lblAltura.AutoSize = true;

        txtAltura = new TextBox();
        txtAltura.Name = "txtAltura";
        txtAltura.Location = new Point(30, 120);
        txtAltura.Size = new Size(340, 27);

        btnCalcular = new Button();
        btnCalcular.Name = "btnCalcular";
        btnCalcular.Text = "Calcular";
        btnCalcular.Location = new Point(30, 165);
        btnCalcular.Size = new Size(120, 35);
        btnCalcular.Click += BtnCalcular_Click;

        lblResultado = new Label();
        lblResultado.Name = "lblResultado";
        lblResultado.Text = "Resultado do IMC aparecerá aqui.";
        lblResultado.Location = new Point(30, 215);
        lblResultado.Size = new Size(340, 40);
        lblResultado.AutoSize = false;

        this.Controls.Add(lblPeso);
        this.Controls.Add(txtPeso);
        this.Controls.Add(lblAltura);
        this.Controls.Add(txtAltura);
        this.Controls.Add(btnCalcular);
        this.Controls.Add(lblResultado);
    }

    private void BtnCalcular_Click(object sender, EventArgs e)
    {
        bool pesoOk = double.TryParse(txtPeso.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double peso);
        bool alturaOk = double.TryParse(txtAltura.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double altura);

        if (!pesoOk || !alturaOk)
        {
            lblResultado.Text = "Introduza apenas valores numéricos.";
            return;
        }

        if (peso <= 0 || altura <= 0)
        {
            lblResultado.Text = "Peso e altura devem ser maiores que zero.";
            return;
        }

        double imc = peso / (altura * altura);

        string classificacao;
        if (imc < 18.5)
            classificacao = "Abaixo do peso";
        else if (imc < 25)
            classificacao = "Peso normal";
        else if (imc < 30)
            classificacao = "Sobrepeso";
        else if (imc < 35)
            classificacao = "Obesidade grau I";
        else if (imc < 40)
            classificacao = "Obesidade grau II";
        else
            classificacao = "Obesidade grau III";

        lblResultado.Text = $"IMC: {imc:F2} - {classificacao}";
    }
}
