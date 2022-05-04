using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;

namespace SolvingEquations
{
    public partial class Form1 : Form
    {
        private int condition;
        private double firstElement, secondElement, thirdElement, fourthElement, fifthElement, freeElement;
        private int previousPosition = 0;
        private int currentPosition = 0;
        private double startCoordinat = 0;
        private double endCoordinat = 10;
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
                MessageBox.Show(
                    text1 + text2, "Проверка корней уравнения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
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
                                number += $"\n{item} : " + eq.ToString();
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
                                number += $"\n{item} : " + eq.ToString();
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
                                number += $"\n{item} : " + eq.ToString();
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
                                number += $"\n{item} : " + eq.ToString();
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
            textBoxFindRoofs.Clear();
            textBoxFifthDegree.Clear();
            textBoxFourthDegree.Clear();
            textBoxThirdDegree.Clear();
            textBoxSecondDegree.Clear();
            textBoxFirstDegree.Clear();
            textBoxFreeMember.Clear();

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

        //Нахождение корней уравнения
        private void buttonFindRoofs_Click(object sender, EventArgs e)
        {
            buttonBuildGraph.Enabled = true;
            textBoxFindRoofs.Enabled = true;
            IEnumerable<Complex> result;
            buttonVerification.Enabled = true;

            textBoxFindRoofs.Clear();

            double.TryParse(textBoxFreeMember.Text, out freeElement);
            double.TryParse(textBoxFirstDegree.Text, out firstElement);
            double.TryParse(textBoxSecondDegree.Text, out secondElement);
            double.TryParse(textBoxThirdDegree.Text, out thirdElement);
            double.TryParse(textBoxFourthDegree.Text, out fourthElement);
            double.TryParse(textBoxFifthDegree.Text, out fifthElement);

            switch (condition)
            {
                case 1:
                    {

                        double EquationOfTheFirstDegree = (freeElement * (-1)) / firstElement;
                        textBoxFindRoofs.Text = textBoxFindRoofs.Text + EquationOfTheFirstDegree.ToString() + Environment.NewLine;
                        break;
                    }
                case 2:
                    {
                        result = Calculation.EquationOfTheSecondDegree(secondElement, firstElement, freeElement);

                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }


                        break;
                    }
                case 3:
                    {
                        result = Calculation.EquationOfTheThirdDegree(thirdElement, secondElement, firstElement, freeElement);

                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }
                        break;
                    }
                case 4:
                    {
                        result = Calculation.EquationOfTheFourthDegree(fourthElement, thirdElement, secondElement, firstElement, freeElement);

                        foreach (var item in result)
                        {
                            textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
                        }
                        break;
                    }
                case 5:
                    {
                        result = Calculation.EquationOfTheFifthDegree(fifthElement, fourthElement, thirdElement, secondElement, firstElement, freeElement);

                        foreach (var item in result)
                        {
                            if (item.Real == double.MaxValue)
                                textBoxFindRoofs.Text = "Отсутвуют действительные корни!";
                            else
                                textBoxFindRoofs.Text = textBoxFindRoofs.Text + GetString(item) + Environment.NewLine;
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
            BuildGraph();
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
            startCoordinat = Convert.ToDouble(StartX.Text);
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
