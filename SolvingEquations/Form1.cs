using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace SolvingEquations
{
    public partial class Form1 : Form
    {
        private int condition;
        private double firstElement, secondElement, thirdElement, fourthElement, fifthElement, freeElement;
        private int previousPosition = 0;
        private int currentPosition = 0;
        private double startCoordinat = 0;
        private double endCoordinat = 0;
        private static string GetString(Complex complex)
        {
            if (complex.Real < 1E-14 && complex.Real > -1E-14)
                complex = new Complex(0, complex.Imaginary);
            if (complex.Imaginary < 1E-14 && complex.Imaginary > -1E-14)
                return complex.Real.ToString();
            else
                return complex.Real == 0 ? $"{complex.Imaginary}i" : $"{complex.Real}" + (complex.Imaginary > 0 ? $" + {complex.Imaginary}i" : $" - {-complex.Imaginary}i");
        }
        //Проверка корней уравнения
        private void buttonVerification_Click(object sender, EventArgs e)
        {
            IEnumerable<Complex> result;
            double eq;
            string stringCondition = "Проверка верна";
            string number = "";
            void MassageBoxWrong(string text1, string text2)
            {
                MessageBox.Show(this,
                    text1 + text2, "Проверка корней уравнения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, 0);
            }
            switch (condition)
            {
                case 1:
                    {
                        double EquationOfTheFirstDegree = (freeElement * (-1)) / firstElement;
                        eq = EquationOfTheFirstDegree * firstElement + freeElement;
                        if (eq > 1E-9 || eq < -1E-9)
                        {
                            stringCondition = "Проверка неверна: ";
                            number += $"\nF({EquationOfTheFirstDegree}) = " + eq.ToString();
                        }
                        MassageBoxWrong(stringCondition, "");
                        break;
                    }
                case 2:
                    {
                        result = Calculation.EquationOfTheSecondDegree(secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            eq = (Math.Pow(item.Real, 2) - Math.Pow(item.Imaginary, 2)) * secondElement + 
                                item.Real * firstElement + freeElement;
                            if (eq > 1E-9 || eq < -1E-9)
                            {
                                stringCondition = "Проверка неверна: ";
                                number += $"\nF({item}) = " + eq.ToString();
                            }
                        }
                        MassageBoxWrong(stringCondition, number);
                        break;
                    }
                case 3:
                    {
                        result = Calculation.EquationOfTheThirdDegree(thirdElement, secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            eq = (Math.Pow(item.Real, 3) - 3 * item.Real * Math.Pow(item.Imaginary, 2))* thirdElement + 
                                (Math.Pow(item.Real, 2) - Math.Pow(item.Imaginary, 2)) * secondElement + 
                                item.Real * firstElement + freeElement;
                            if (eq > 1E-9 || eq < -1E-9)
                            {
                                stringCondition = "Проверка неверна: ";
                                number += $"\nF({item}) = " + eq.ToString();
                            }
                        }
                        MassageBoxWrong(stringCondition, number);
                        break;
                    }
                case 4:
                    {
                        result = Calculation.EquationOfTheFourthDegree(fourthElement, thirdElement, secondElement, firstElement, freeElement);
                        foreach (var item in result)
                        {
                            eq = Math.Pow(Math.Pow(item.Real, 2)  + Math.Pow(item.Imaginary, 2),2)*Math.Cos(4 * Math.Atan(item.Imaginary / item.Real)) * fourthElement +
                                (Math.Pow(item.Real, 3) - 3 * item.Real * Math.Pow(item.Imaginary, 2)) * thirdElement + 
                                (Math.Pow(item.Real, 2) - Math.Pow(item.Imaginary, 2)) * secondElement + 
                                item.Real * firstElement + freeElement;
                            if (eq > 1E-9 || eq < -1E-9)
                            {
                                stringCondition = "Проверка неверна: ";
                                number += $"\nF({item}) = " + eq.ToString();
                            }
                        }
                        MassageBoxWrong(stringCondition, number);
                        break;
                    }
                case 5:
                    {
                        result = Calculation.EquationOfTheFifthDegree(fifthElement, fourthElement, thirdElement, secondElement, firstElement, freeElement);
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
                        MassageBoxWrong(stringCondition, number);
                        break;
                    }
            }
        }

        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

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
                        labelThirstDegree.Enabled = true;
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
                        labelThirstDegree.Enabled = true;
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
                        labelThirstDegree.Enabled = true;
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
                        labelThirstDegree.Enabled = true;
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
                        labelThirstDegree.Enabled = true;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBoxFifthDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBoxFifthDegree.SelectionStart == 0) { }
            else
            {
                if (e.KeyChar == 46) e.KeyChar = ',';
                if ((e.KeyChar == 44 || e.KeyChar == 46) && textBoxFifthDegree.SelectionStart > (textBoxFifthDegree.Text.IndexOf('-') == 0 ? 1 : 0))
                {
                    if (textBoxFifthDegree.Text.IndexOf(',') > 1)
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
                    if (textBoxFourthDegree.Text.IndexOf(',') > 1)
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
                    if (textBoxThirdDegree.Text.IndexOf(',') > 1)
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
                    if (textBoxSecondDegree.Text.IndexOf(',') > 1)
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
                    if (textBoxFirstDegree.Text.IndexOf(',') > 1)
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
                    if (textBoxFreeMember.Text.IndexOf(',') > 1)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFindRoofs.Clear();
            textBoxFifthDegree.Clear();
            textBoxFourthDegree.Clear();
            textBoxThirdDegree.Clear();
            textBoxSecondDegree.Clear();
            textBoxFirstDegree.Clear();
            textBoxFreeMember.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Enabled = false;
            StartX.Text = "-10";
            EndX.Text = "10";
            buttonBuildGraph.Enabled = false;
            buttonVerification.Enabled = false;
            textBoxFindRoofs.Enabled = false;
        }

        //Нахождение корней уравнения
        private void buttonFindRoofs_Click(object sender, EventArgs e)
        {
            buttonBuildGraph.Enabled = true;
            textBoxFindRoofs.Enabled = true;
            buttonVerification.Enabled = true;
            chart1.Series[0].Points.Clear();
            chart1.Enabled = false;
            StartX.Text = "-10";
            EndX.Text = "10";
            textBoxFindRoofs.Clear();
            double.TryParse(textBoxFreeMember.Text, out freeElement);
            double.TryParse(textBoxFirstDegree.Text, out firstElement);
            double.TryParse(textBoxSecondDegree.Text, out secondElement);
            double.TryParse(textBoxThirdDegree.Text, out thirdElement);
            double.TryParse(textBoxFourthDegree.Text, out fourthElement);
            double.TryParse(textBoxFifthDegree.Text, out fifthElement);
            IEnumerable<Complex> result;
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
                            MassageBoxError();
                        else
                        {
                            double EquationOfTheFirstDegree = (freeElement * (-1)) / firstElement;
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + EquationOfTheFirstDegree.ToString() + Environment.NewLine;
                            string text = ListResults.Text;
                            ListResults.Clear();
                            ListResults.Text += $"{firstElement}x " + 
                                (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0") +
                                Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
                        }
                        break;
                    }
                case 2:
                    {
                        if (secondElement == 0)
                            MassageBoxError();
                        else
                        {
                            result = Calculation.EquationOfTheSecondDegree(secondElement, firstElement, freeElement);
                            foreach (var item in result)
                            {
                                textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                            }
                            string text = ListResults.Text;
                            ListResults.Clear();
                            ListResults.Text += $"{secondElement}x² " +
                                (firstElement > 0 ? $"+ {firstElement}x " : firstElement < 0 ? $"- {-firstElement}x " : "") +
                                (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0") +
                                Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
                        }
                        break;
                    }
                case 3:
                    {
                        if (thirdElement == 0)
                            MassageBoxError();
                        else
                        {
                            result = Calculation.EquationOfTheThirdDegree(thirdElement, secondElement, firstElement, freeElement);
                            foreach (var item in result)
                            {
                                textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                            }
                            string text = ListResults.Text;
                            ListResults.Clear();
                            ListResults.Text += $"{thirdElement}x³ " +
                                (secondElement > 0 ? $"+ {secondElement}x² " : secondElement < 0 ? $"- {-secondElement}x² " : "") +
                                (firstElement > 0 ? $"+ {firstElement}x " : firstElement < 0 ? $"- {-firstElement}x " : "") +
                                (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0") +
                                Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
                        }
                        break;
                    }
                case 4:
                    {
                        if (fourthElement == 0)
                            MassageBoxError();
                        else
                        {
                            result = Calculation.EquationOfTheFourthDegree(fourthElement, thirdElement, secondElement, firstElement, freeElement);
                            foreach (var item in result)
                            {
                                textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                            }
                            string text = ListResults.Text;
                            ListResults.Clear();
                            ListResults.Text += $"{fourthElement}x⁴ " +
                                (thirdElement > 0 ? $"+ {thirdElement}x³ " : thirdElement < 0 ? $"- {-thirdElement}x³ " : "") +
                                (secondElement > 0 ? $"+ {secondElement}x² " : secondElement < 0 ? $"- {-secondElement}x² " : "") +
                                (firstElement > 0 ? $"+ {firstElement}x " : firstElement < 0 ? $"- {-firstElement}x " : "") +
                                (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0") +
                                Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
                        }
                        break;
                    }
                case 5:
                    {
                        if (fifthElement == 0)
                            MassageBoxError();
                        else
                        {
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
                            string text = ListResults.Text;
                            ListResults.Clear();
                            ListResults.Text += $"{fifthElement}x⁵ " +
                                (fourthElement > 0 ? $"+ {fourthElement}x⁴ " : fourthElement < 0 ? $"- {-fourthElement}x⁴ " : "") +
                                (thirdElement > 0 ? $"+ {thirdElement}x³ " : thirdElement < 0 ? $"- {-thirdElement}x³ " : "") +
                                (secondElement > 0 ? $"+ {secondElement}x² " : secondElement < 0 ? $"- {-secondElement}x² " : "") +
                                (firstElement > 0 ? $"+ {firstElement}x " : firstElement < 0 ? $"- {-firstElement}x " : "") +
                                (freeElement > 0 ? $"+ {freeElement} = 0" : freeElement < 0 ? $"- {-freeElement} = 0" : "= 0") +
                                Environment.NewLine + textBoxFindRoofs.Text + Environment.NewLine + text + Environment.NewLine;
                        }
                        break;
                    }
            }
        }

        //Очистка полей
        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxFindRoofs.Clear();
            chart1.Series[0].Points.Clear();
            textBoxFifthDegree.Clear();
            textBoxFourthDegree.Clear();
            textBoxThirdDegree.Clear();
            textBoxSecondDegree.Clear();
            textBoxFirstDegree.Clear();
            textBoxFreeMember.Clear();
        }

        private void buttonBuildGraph_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Enabled = true;
            BuildGraph();
            chart1.Series[0].Color = System.Drawing.Color.Blue;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPosition = (Cursor.Position.X - this.Left);

                if (currentPosition > previousPosition)
                {
                    StartX.Text = (Convert.ToDouble(StartX.Text) - 0.05).ToString();
                    EndX.Text = (Convert.ToDouble(EndX.Text) - 0.05).ToString();
                }
                else
                {
                    StartX.Text = (Convert.ToDouble(StartX.Text) + 0.05).ToString();
                    EndX.Text = (Convert.ToDouble(EndX.Text) + 0.05).ToString();
                }
                previousPosition = (Cursor.Position.X - this.Left);
                BuildGraph();
            }
        }

        private void BuildGraph()
        {
            startCoordinat = Convert.ToDouble(StartX.Text) + 0.1;
            endCoordinat = Convert.ToDouble(EndX.Text);
            chart1.Series[0].Points.Clear();
            for (double i = startCoordinat; i <= endCoordinat; i += 0.1)
            {
                double y = fifthElement * Math.Pow(i, 5) + fourthElement * Math.Pow(i, 4) + thirdElement * Math.Pow(i, 3) + secondElement * Math.Pow(i, 2) + firstElement * i + freeElement;
                chart1.Series[0].Points.AddXY(i, y);
            }
        }
    }
}
