using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoMetr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Calendar.BoldedDates = new System.DateTime[] { new System.DateTime(2015, 1, 26, 0, 0, 0, 0) };
            Calendar.MaxDate = new System.DateTime(2015, 1, 31, 0, 0, 0, 0);
            Calendar.MaxSelectionCount = 1;

            lCurDate.Text = Calendar.TodayDate.ToShortDateString();
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            lCurDate.Text = e.Start.ToShortDateString();
            lCurDate.Text = float.Parse(tbLight.Text.Replace('.', ',')).ToString();
        }

        /// <summary>
        /// Только цифры
        /// Точность: 2 знака после запятой
        /// </summary>
        private void tbLight_KeyPress(object sender, KeyPressEventArgs e)
        {
            string keyInput = e.KeyChar.ToString();
            string inputText = (sender as TextBox).Text;

            if (Char.IsDigit(e.KeyChar)
                || keyInput.IndexOfAny(NumericValidator.DecimalSeparator) != -1)
            {
                // выделение текста
                string text;
                text = inputText.Substring(0, (sender as TextBox).SelectionStart);
                text += keyInput;
                text += inputText.Substring((sender as TextBox).SelectionStart + (sender as TextBox).SelectionLength);
                // проверяем
                e.Handled = !NumericValidator.IsValidFormat(text);
            }
            else if (e.KeyChar == '\b'
                    || e.KeyChar == '\t'
                    || keyInput.Equals(Keys.Delete.ToString())
                    || keyInput.Equals(Keys.Home.ToString())
                    || keyInput.Equals(Keys.End.ToString()))
            {
                // разрешены backspace, tab, delete, home, end
            }
            else if (e.KeyChar == 26
                     || e.KeyChar == 24
                     || e.KeyChar == 3
                     || e.KeyChar == 22)
            {
                // 26 : Ctrl+Z | 24 : Ctrl+X
                //  3 : Ctrl+C | 22 : Ctrl+V
                if (e.KeyChar == 22)
                {
                    // выделение текста
                    string text;
                    text = inputText.Substring(0, (sender as TextBox).SelectionStart);
                    text += Clipboard.GetText();
                    text += inputText.Substring((sender as TextBox).SelectionStart + (sender as TextBox).SelectionLength);
                    // проверяем
                    e.Handled = !NumericValidator.IsValidFormat(text);
                }
            }
            else
            {
                // запретить изменение
                e.Handled = true;
            }
        }

        private void tbLight_KeyUp(object sender, KeyEventArgs e)
        {
            string value = (sender as TextBox).Text;
            int pos = value.IndexOfAny(Delimeters.Any);
            if (pos == 0)
            {
                (sender as TextBox).Text = "0" + value;
                (sender as TextBox).Select(2, 0);
                e.Handled = false;
            }
        }

    }
}
