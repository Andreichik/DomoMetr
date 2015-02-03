using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;
using Helpers;

namespace NumericTextBox
{
    public partial class NumericTextBox : TextBox
    {
        private int decimalNumbers;

        public int DecimalNumbers
        {
            get { return decimalNumbers; }
            set
            {
                decimalNumbers = (value < 0 || value > 10) ? 2 : value;
            }
        }
        public NumericTextBox()
        {
            InitializeComponent();

            DecimalNumbers = 2;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            string value = (this as TextBox).Text;
            int pos = value.IndexOfAny(Delimeters.Any);

            if (pos == 0)
            {
                (this as TextBox).Text = "0" + value;
                (this as TextBox).Select(2, 0);
                e.Handled = false;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            string keyInput = e.KeyChar.ToString();
            string inputText = (this as TextBox).Text;

            if (Char.IsDigit(e.KeyChar)
                || keyInput.IndexOfAny(Delimeters.Any) != -1)
            {
                // выделение текста
                string text;
                text = inputText.Substring(0, (this as TextBox).SelectionStart);
                text += keyInput;
                text += inputText.Substring((this as TextBox).SelectionStart + (this as TextBox).SelectionLength);
                // проверяем
                e.Handled = !NumericValidator.IsValidFormat(text, DecimalNumbers);
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
                    text = inputText.Substring(0, (this as TextBox).SelectionStart);
                    text += Clipboard.GetText();
                    text += inputText.Substring((this as TextBox).SelectionStart + (this as TextBox).SelectionLength);
                    // проверяем
                    e.Handled = !NumericValidator.IsValidFormat(text, DecimalNumbers);
                }
            }
            else
            {
                // запретить изменение
                e.Handled = true;
            }
        }
    }
}
