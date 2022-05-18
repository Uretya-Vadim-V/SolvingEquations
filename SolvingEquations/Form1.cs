using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace SolvingEquations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private int condition;
        private double firstElement, secondElement, thirdElement, fourthElement, fifthElement, freeElement;
        private int previousPosition = 0;
        private int currentPosition = 0;
        private IEnumerable<Complex> result = new List<Complex>();
        private double[] arrResult;
        string path = Directory.GetCurrentDirectory();
        private static string GetString(Complex complex)
        {
            if (complex.Real < 1E-9 && complex.Real > -1E-9)
                complex = new Complex(0, complex.Imaginary);
            if (complex.Imaginary < 1E-9 && complex.Imaginary > -1E-9)
                return complex.Real.ToString();
            else
                return complex.Real == 0 ? $"{complex.Imaginary}i" : $"{complex.Real}" + (complex.Imaginary > 0 ? $" + {complex.Imaginary}i" : $" - {-complex.Imaginary}i");
        }

        //Проверка корней уравнения
        private void buttonVerification_Click(object sender, EventArgs e)
        {
            double eq;
            string stringCondition = "Проверка верна";
            string number = "";
            foreach (var item in result)
            {
                eq = (Math.Pow(item.Real, 5) - 10 * Math.Pow(item.Real, 3) * Math.Pow(item.Imaginary, 2) + 5 * item.Real * Math.Pow(item.Imaginary, 4)) * fifthElement +
                    Math.Pow(Math.Pow(item.Real, 2) + Math.Pow(item.Imaginary, 2), 2) * Math.Cos(4 * Math.Atan(item.Imaginary / item.Real)) * fourthElement +
                    (Math.Pow(item.Real, 3) - 3 * item.Real * Math.Pow(item.Imaginary, 2)) * thirdElement +
                    (Math.Pow(item.Real, 2) - Math.Pow(item.Imaginary, 2)) * secondElement +
                    item.Real * firstElement + freeElement; ;
                if (eq > 1E-9 || eq < -1E-9)
                {
                    stringCondition = "Проверка неверна: ";
                    number += $"\nF({item}) = " + eq.ToString();
                }
            }
            MessageBox.Show(this,
                                stringCondition + number, "Проверка корней уравнения",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1, 0);
        }

        //↓ события, реагирующие на изменение степени уравнения
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(comboBox1.Text, out condition);
            switch (condition)
            {
                case 1:
                    {
                        textBoxFreeMember.Enabled = true;
                        textBoxFirstDegree.Enabled = true;
                        labelEquals.Enabled = true;
                        labelFirstDegree.Enabled = true;
                        textBoxSecondDegree.Enabled = false;
                        labelSecondDegree.Enabled = false;
                        textBoxFourthDegree.Enabled = false;
                        labelFourthDegree.Enabled = false;
                        textBoxFifthDegree.Enabled = false;
                        labelFifthDegree.Enabled = false;
                        textBoxThirdDegree.Enabled = false;
                        labelThirdDegree.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        textBoxFreeMember.Enabled = true;
                        textBoxFirstDegree.Enabled = true;
                        labelEquals.Enabled = true;
                        labelFirstDegree.Enabled = true;
                        textBoxSecondDegree.Enabled = true;
                        labelSecondDegree.Enabled = true;
                        textBoxFourthDegree.Enabled = false;
                        labelFourthDegree.Enabled = false;
                        textBoxFifthDegree.Enabled = false;
                        labelFifthDegree.Enabled = false;
                        textBoxThirdDegree.Enabled = false;
                        labelThirdDegree.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        textBoxFreeMember.Enabled = true;
                        textBoxFirstDegree.Enabled = true;
                        labelEquals.Enabled = true;
                        labelFirstDegree.Enabled = true;
                        textBoxSecondDegree.Enabled = true;
                        labelSecondDegree.Enabled = true;
                        textBoxThirdDegree.Enabled = true;
                        labelThirdDegree.Enabled = true;
                        textBoxFourthDegree.Enabled = false;
                        labelFourthDegree.Enabled = false;
                        textBoxFifthDegree.Enabled = false;
                        labelFifthDegree.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        textBoxFreeMember.Enabled = true;
                        textBoxFirstDegree.Enabled = true;
                        labelEquals.Enabled = true;
                        labelFirstDegree.Enabled = true;
                        textBoxSecondDegree.Enabled = true;
                        labelSecondDegree.Enabled = true;
                        textBoxThirdDegree.Enabled = true;
                        labelThirdDegree.Enabled = true;
                        textBoxFourthDegree.Enabled = true;
                        labelFourthDegree.Enabled = true;
                        textBoxFifthDegree.Enabled = false;
                        labelFifthDegree.Enabled = false;
                        break;
                    }
                case 5:
                    {
                        textBoxFreeMember.Enabled = true;
                        textBoxFirstDegree.Enabled = true;
                        labelEquals.Enabled = true;
                        labelFirstDegree.Enabled = true;
                        textBoxSecondDegree.Enabled = true;
                        labelSecondDegree.Enabled = true;
                        textBoxThirdDegree.Enabled = true;
                        labelThirdDegree.Enabled = true;
                        textBoxFourthDegree.Enabled = true;
                        labelFourthDegree.Enabled = true;
                        textBoxFifthDegree.Enabled = true;
                        labelFifthDegree.Enabled = true;
                        break;
                    }
                default:
                    textBoxSecondDegree.Enabled = false;
                    labelSecondDegree.Enabled = false;
                    textBoxFourthDegree.Enabled = false;
                    labelFourthDegree.Enabled = false;
                    textBoxFifthDegree.Enabled = false;
                    labelFifthDegree.Enabled = false;
                    textBoxThirdDegree.Enabled = false;
                    labelThirdDegree.Enabled = false;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            arrResult = new double[6];
            textBoxFindRoofs.Clear();
            textBoxFifthDegree.Clear();
            textBoxFourthDegree.Clear();
            textBoxThirdDegree.Clear();
            textBoxSecondDegree.Clear();
            textBoxFirstDegree.Clear();
            textBoxFreeMember.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
            StartX.Text = "-10";
            EndX.Text = "10";
            StartY.Text = "-10";
            EndY.Text = "10";
            buttonBuildGraph.Enabled = false;
            buttonVerification.Enabled = false;
            textBoxFindRoofs.Enabled = false;
            buttonFindRoofs.Enabled = false;
        }

        //↓ правила вводимых значений в каждый textBox
        private void textBoxFifthDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxFifthDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxFifthDegree.SelectionStart > (textBoxFifthDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxFifthDegree.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxFourthDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxFourthDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxFourthDegree.SelectionStart > (textBoxFourthDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxFourthDegree.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxThirdDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxThirdDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxThirdDegree.SelectionStart > (textBoxThirdDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxThirdDegree.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxSecondDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxSecondDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxSecondDegree.SelectionStart > (textBoxSecondDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxSecondDegree.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxFirstDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxFirstDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxFirstDegree.SelectionStart > (textBoxFirstDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxFirstDegree.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxFreeMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxFreeMember.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxFreeMember.SelectionStart > (textBoxFreeMember.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxFreeMember.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void EndY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && EndY.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && EndY.SelectionStart > (EndY.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (EndY.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void StartY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && StartY.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && StartY.SelectionStart > (StartY.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (StartY.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void StartX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && StartX.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && StartX.SelectionStart > (StartX.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (StartX.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void EndX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && EndX.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && EndX.SelectionStart > (EndX.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (EndX.Text.IndexOf(',') > 0)
                    {
                        if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        //↓ события, реагирующие на изменение коэффициентов уравнения
        private void textBoxFourthDegree_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxFourthDegree.Text, out fourthElement);
            if (textBoxFourthDegree.TextLength == 0 && textBoxFifthDegree.TextLength == 0)
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            if (textBoxFifthDegree.Enabled == false && condition > 4 || condition == 4)
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        private void textBoxFifthDegree_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxFifthDegree.Text, out fifthElement);
            if (textBoxFifthDegree.TextLength == 0)
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        private void textBoxThirdDegree_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxThirdDegree.Text, out thirdElement);
            if (textBoxThirdDegree.TextLength == 0 && (textBoxFifthDegree.TextLength == 0 && textBoxFourthDegree.TextLength == 0))
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            if (textBoxFourthDegree.Enabled == false && condition > 3 || condition == 3)
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        private void textBoxSecondDegree_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxSecondDegree.Text, out secondElement);
            if (textBoxSecondDegree.TextLength == 0 && (textBoxFifthDegree.TextLength == 0 && textBoxFourthDegree.TextLength == 0 &&
                textBoxThirdDegree.TextLength == 0))
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            if (textBoxThirdDegree.Enabled == false && condition > 2 || condition == 2)
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        private void textBoxFirstDegree_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxFirstDegree.Text, out firstElement);
            if (textBoxFirstDegree.TextLength == 0 && (textBoxFifthDegree.TextLength == 0 && textBoxFourthDegree.TextLength == 0 &&
                textBoxThirdDegree.TextLength == 0 && textBoxSecondDegree.TextLength == 0))
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            if (textBoxSecondDegree.Enabled == false && condition > 1 || condition == 1)
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        private void textBoxFreeMember_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBoxFreeMember.Text, out freeElement);
            if (textBoxFreeMember.TextLength == 0 && (textBoxFifthDegree.TextLength == 0 && textBoxFourthDegree.TextLength == 0 &&
                textBoxThirdDegree.TextLength == 0 && textBoxSecondDegree.TextLength == 0 && textBoxFirstDegree.TextLength == 0))
            {
                buttonFindRoofs.Enabled = false;
            }
            else
            if (textBoxFirstDegree.Enabled == false && condition > 0)
            {
                buttonFindRoofs.Enabled = true;
            }
            buttonVerification.Enabled = false;
            buttonBuildGraph.Enabled = false;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
        }

        //Нахождение корней уравнения
        private void buttonFindRoofs_Click(object sender, EventArgs e)
        {
            if (arrResult[0] == freeElement && arrResult[1] == firstElement && arrResult[2] == secondElement &&
                arrResult[3] == thirdElement && arrResult[4] == fourthElement && arrResult[5] == fifthElement)
                return;
            else
                arrResult = new double[] { freeElement, firstElement, secondElement, thirdElement, fourthElement, fifthElement };
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Enabled = false;
            StartX.Text = "-10";
            EndX.Text = "10";
            StartY.Text = "-10";
            EndY.Text = "10";
            textBoxFindRoofs.Clear();
            string text = "";
            void MassageBoxError()
            {
                MessageBox.Show(this,
                    "Первый элемент не может быть равен нулю!", "Входные данные",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, 0);
            }
            switch (condition)
            {
                case 1:
                    {
                        if (firstElement == 0)
                        {
                            MassageBoxError();
                            return;
                        }
                        double EquationOfTheFirstDegree = -freeElement / firstElement;
                        textBoxFindRoofs.Text = textBoxFindRoofs.Text + EquationOfTheFirstDegree.ToString() + Environment.NewLine;
                        text = ListResults.Text;
                        break;
                    }
                case 2:
                    {
                        if (secondElement == 0)
                        {
                            MassageBoxError();
                            return;
                        }
                        result = Calculation.EquationOfTheSecondDegree(secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }
                        text = ListResults.Text;
                        break;
                    }
                case 3:
                    {
                        if (thirdElement == 0)
                        {
                            MassageBoxError();
                            return;
                        }
                        result = Calculation.EquationOfTheThirdDegree(thirdElement, secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }
                        text = ListResults.Text;
                        break;
                    }
                case 4:
                    {
                        if (fourthElement == 0)
                        {
                            MassageBoxError();
                            return;
                        }
                        result = Calculation.EquationOfTheFourthDegree(fourthElement, thirdElement, secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }
                        text = ListResults.Text;
                        break;
                    }
                case 5:
                    {
                        if (fifthElement == 0)
                        {
                            MassageBoxError();
                            return;
                        }
                        result = Calculation.EquationOfTheFifthDegree(fifthElement, fourthElement, thirdElement, secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            if (item.Real == double.MaxValue)
                                textBoxFindRoofs.Text = "Отсутвуют действительные корни!";
                            else
                            {
                                textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                            }
                        }
                        text = ListResults.Text;
                        break;
                    }
            }
            ListResults.Clear();
            ListResults.Text += GetEquation() + Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
            buttonBuildGraph.Enabled = true;
            textBoxFindRoofs.Enabled = true;
            buttonVerification.Enabled = true;
            using (StreamWriter fstream = new StreamWriter($"{path}\\listResults.txt", true))
            {
                fstream.WriteLine(GetEquation());
                foreach (var item in result)
                {
                    fstream.WriteLine(GetString(item));
                }
                fstream.WriteLine("///");
            }
        }
        private string GetEquation()
        {
            return (fifthElement == 0 ? "" : $"{fifthElement}x⁵ ") +
                            (fifthElement == 0 ? (fourthElement == 0 ? "" : $"{fourthElement}x⁴ ") : (fourthElement > 0 ? $"+ {fourthElement}x⁴ " : fourthElement < 0 ? $"- {-fourthElement}x⁴ " : "")) +
                            (fifthElement == 0 && fourthElement == 0 ? (thirdElement == 0 ? "" : $"{thirdElement}x³ ") : (thirdElement > 0 ? $"+ {thirdElement}x³ " : thirdElement < 0 ? $"- {-thirdElement}x³ " : "")) +
                            (fifthElement == 0 && fourthElement == 0 && thirdElement == 0 ? (secondElement == 0 ? "" : $"{secondElement}x² ") : (secondElement > 0 ? $"+ {secondElement}x² " : secondElement < 0 ? $"- {-secondElement}x² " : "")) +
                            (fifthElement == 0 && fourthElement == 0 && thirdElement == 0 && secondElement == 0 ? (firstElement == 0 ? "" : $"{firstElement}x ") : (firstElement > 0 ? $"+ {firstElement}x " : firstElement < 0 ? $"- {-firstElement}x " : "")) +
                            (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (FileStream fstream = new FileStream($"{path}\\listResults.txt", FileMode.OpenOrCreate)) { }
            string line = "///";
            string text1 = "";
            string text2 = "";
            using (StreamReader sr = new StreamReader($"{path}\\listResults.txt"))
            {
                while (line != null)
                {
                    if (line == "///")
                    {
                        text2 = text1 + Environment.NewLine + text2;
                        text1 = "";
                    }
                    line = sr.ReadLine();
                    if (line != "///")
                    {
                        text1 += line + Environment.NewLine;
                    }
                }
            }
            ListResults.Text = text2;
        }

        //Очистка истории
        private void ClearHistory_Click(object sender, EventArgs e)
        {
            ListResults.Clear();
            File.WriteAllText($"{path}\\listResults.txt", string.Empty);
        }

        //Очистка полей
        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxFindRoofs.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            textBoxFifthDegree.Clear();
            textBoxFourthDegree.Clear();
            textBoxThirdDegree.Clear();
            textBoxSecondDegree.Clear();
            textBoxFirstDegree.Clear();
            textBoxFreeMember.Clear();
            StartX.Text = "-10";
            EndX.Text = "10";
            StartY.Text = "-10";
            EndY.Text = "10";
        }

        //Создание графика
        private void buttonBuildGraph_Click(object sender, EventArgs e)
        {
            chart1.Enabled = true;
            double.TryParse(StartX.Text, out double startX);
            double.TryParse(EndX.Text, out double endX);
            double.TryParse(StartY.Text, out double startY);
            double.TryParse(EndY.Text, out double endY);
            if (endX == startX)
            {
                StartX.Text = "-10";
                EndX.Text = "10";
            }
            if (endY == startY)
            {
                StartY.Text = "-10";
                EndY.Text = "10";
            }
            if (startX > endX)
            {
                StartX.Text = endX.ToString();
                EndX.Text = startX.ToString();
            }
            if (startY > endY)
            {
                StartY.Text = endY.ToString();
                EndY.Text = startY.ToString();
            }
            double.TryParse(StartX.Text, out startX);
            double.TryParse(EndX.Text, out endX);
            double.TryParse(StartY.Text, out startY);
            double.TryParse(EndY.Text, out endY);
            BuildGraph(startX, endX, startY, endY);
        }
        private void BuildGraph(double startX, double endX, double startY, double endY)
        {
            startX += 0.1;
            chart1.ChartAreas[0].AxisY.Minimum = startY;
            chart1.ChartAreas[0].AxisY.Maximum = endY;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            for (double i = startX; i <= endX; i += 0.1)
            {
                try
                {
                    double y = (double)((decimal)fifthElement * (decimal)Math.Pow(i, 5) + (decimal)fourthElement * (decimal)Math.Pow(i, 4) +
                        (decimal)thirdElement * (decimal)Math.Pow(i, 3) + (decimal)secondElement * (decimal)Math.Pow(i, 2) + (decimal)firstElement * (decimal)i + (decimal)freeElement);
                    chart1.Series[0].Points.AddXY(i, y);
                }
                catch
                {
                    MessageBox.Show(this,
                    "Значение было недопустимо малым или недопустимо большим", "Коэффициенты",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, 0);
                    return;
                }
            }
            chart1.Series[1].Points.AddXY(startX, 0);
            chart1.Series[1].Points.AddXY(endX, 0);
            foreach (var item in result)
            {
                if ((decimal)item.Real < decimal.MaxValue && (decimal)item.Real > decimal.MinValue)
                {
                    if ((item.Imaginary < 1E-9 && item.Imaginary > -1E-9) && (item.Real > startX && item.Real < endX))
                        chart1.Series[2].Points.AddXY(item.Real, 0);
                }
            }
        }

        //Сдвиг графика по оси абсцисс удерживанием левой клавиши мыши
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            double.TryParse(StartX.Text, out double startX);
            double.TryParse(EndX.Text, out double endX);
            double.TryParse(StartY.Text, out double startY);
            double.TryParse(EndY.Text, out double endY);
            if (e.Button == MouseButtons.Left)
            {
                currentPosition = (Cursor.Position.X - Left);
                if (currentPosition > previousPosition)
                {
                    StartX.Text = (startX - 0.05).ToString();
                    EndX.Text = (endX - 0.05).ToString();
                }
                else
                {
                    StartX.Text = (startX + 0.05).ToString();
                    EndX.Text = (endX + 0.05).ToString();
                }
                previousPosition = (Cursor.Position.X - Left);
                BuildGraph(startX, endX, startY, endY);
            }
        }

        //Прибилижение или отдаление графика колёсиком мыши 
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            double.TryParse(StartX.Text, out double startX);
            double.TryParse(EndX.Text, out double endX);
            double.TryParse(StartY.Text, out double startY);
            double.TryParse(EndY.Text, out double endY);
            if (startY != endY)
            {
                if (e.Delta < 0)
                {
                    StartX.Text = (startX + 0.01).ToString();
                    EndX.Text = (endX - 0.01).ToString();
                    StartY.Text = (startY + 0.01).ToString();
                    EndY.Text = (endY - 0.01).ToString();
                }
                else
                {
                    StartX.Text = (startX - 0.01).ToString();
                    EndX.Text = (endX + 0.01).ToString();
                    StartY.Text = (startY - 0.01).ToString();
                    EndY.Text = (endY + 0.01).ToString();
                }
                if (startX > endX)
                {
                    double.TryParse(StartX.Text, out startX);
                    double.TryParse(EndX.Text, out endX);
                }
            }
            else
            {
                StartY.Text = "-10";
                EndY.Text = "10";
                startY = -10;
                endY = 10;
            }
            BuildGraph(startX, endX, startY, endY);
        }
    }
}
