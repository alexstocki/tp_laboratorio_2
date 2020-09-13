using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Llamada al metodo Limpiar que limpia los valores impresos en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();    
        }
        /// <summary>
        /// Limpia los valores que se ven en los elementos lblResultado, 
        /// txtNumero1 y txtNumero2, como asi tambien el cmbOperador
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }
        /// <summary>
        /// Realiza la operacion seleccionada por pantalla y la imprime en
        /// el lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Instancia elementos Numero y Calculadora para utilizar las operaciones
        /// que pertenecen a estos objetos
        /// </summary>
        /// <param name="numero1">string obtenido en txtNumero1</param>
        /// <param name="numero2">string obtenido en txtNumero2</param>
        /// <param name="operador">string obtenido en cmbOperador</param>
        /// <returns>double correspondiente a la operacion seleccionada</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            Calculadora calculadora = new Calculadora();

            double resultado = calculadora.Operar(num1, num2, operador);

            return resultado;
        }
        /// <summary>
        /// Cierra la ventana de ejecucion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Instancia un elemento Numero para utilizar su metodo de conversion
        /// imprime en el lblResultado el dato convertido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero numero = new Numero();
                lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
            }
        }
        /// <summary>
        /// Instancia un elemento Numero para utilizar su metodo de conversion
        /// imprime en el lblResultado el dato convertido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero numero = new Numero();
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            }
        }
    }
}
