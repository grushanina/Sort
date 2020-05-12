using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int GetRadioIndex(GroupBox group)
        {
            foreach (Control control in group.Controls)
                if (control is RadioButton)
                    if (((RadioButton)control).Checked)
                        return int.Parse(control.Tag.ToString());
            return -1;
        }
        public static void Shuffle<T>(T[] arr)
        {
            Random rand = new Random();
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                T tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }

        static void BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = 0; j < mas.Length - i - 1; j++)
                {
                    if (mas[j + 1] < mas[j])
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        static void ShellSort(int[] mas)
        {
            var d = mas.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < mas.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (mas[j - d] > mas[j]))
                    {
                        Swap(ref mas[j], ref mas[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }
        }
        int partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) 
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
           
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }

        int[] arr;
        int[] keys;
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Numbers"].Points.Clear();

            arr = new int[Int32.Parse(textBox1.Text)];
            keys = new int[Int32.Parse(textBox1.Text)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
                keys[i] = i;
            }
            Shuffle(arr);

            if (checkBox1.Checked)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    chart1.Series["Numbers"].Points.AddXY(arr[i].ToString(), arr[i]);
                }
            }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Text = GetRadioIndex(groupBox1).ToString();
            switch (GetRadioIndex(groupBox1))
            {
                case 1:
                    long ellapledTicks = DateTime.Now.Ticks;
                    BubbleSort(arr);
                    ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
                    textBox2.Text += "Bubble sort: " + ellapledTicks.ToString() + " ms" + Environment.NewLine;
                    break;

                case 2:
                    ellapledTicks = DateTime.Now.Ticks;
                    ShellSort(arr);
                    ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
                    textBox2.Text += "Shell sort: " + ellapledTicks.ToString() + " ms" + Environment.NewLine;
                    break;

                case 3:
                    ellapledTicks = DateTime.Now.Ticks;
                    quicksort(arr, 0, arr.Length-1);
                    ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
                    textBox2.Text += "Quick sort: " + ellapledTicks.ToString() + " ms" + Environment.NewLine;
                    break;

                case 4:
                    ellapledTicks = DateTime.Now.Ticks;
                    Array.Sort(arr);
                    ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
                    textBox2.Text += "Array.Sort: " + ellapledTicks.ToString() + " ms" + Environment.NewLine;
                    break;

                default:
                    break;
            }
            if (checkBox1.Checked)
            {
                chart1.Series["Numbers"].Points.Clear();
                for (int i = 0; i < arr.Length; i++)
                {
                    chart1.Series["Numbers"].Points.AddXY(arr[i].ToString(), arr[i]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
