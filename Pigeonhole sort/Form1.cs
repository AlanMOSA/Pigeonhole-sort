using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pigeonhole_sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer los números del TextBox
                int[] arr = txtInput.Text.Split(',').Select(int.Parse).ToArray();

                // Ordenar el array usando Pigeonhole Sort
                PigeonholeSort(arr);

                // Mostrar el array ordenado en el TextBox
                txtOutput.Text = string.Join(", ", arr);
            }
            catch
            {
                MessageBox.Show("Por favor, ingresa números válidos separados por comas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PigeonholeSort(int[] arr)
        {
            int min = arr.Min();
            int max = arr.Max();
            int range = max - min + 1;
            int[] holes = new int[range];

            // Inicializar los agujeros
            foreach (var num in arr)
                holes[num - min]++;

            // Recoger los elementos de los agujeros y ponerlos de vuelta en el array
            int index = 0;
            for (int i = 0; i < range; i++)
            {
                while (holes[i]-- > 0)
                    arr[index++] = i + min;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
