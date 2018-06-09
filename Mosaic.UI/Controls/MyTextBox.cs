using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Mosaic.UI.Controls
{
    public class MyTextBox : System.Windows.Controls.TextBox
    {
        public static readonly DependencyProperty InputModeProperty =
            DependencyProperty.Register("InputMode",
                                        typeof(InputMode), 
                                        typeof(MyTextBox));

        public InputMode InputMode
        {
            get { return (InputMode)GetValue(InputModeProperty); }
            set { SetValue(InputModeProperty, value); }
        }
        
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (InputMode == InputMode.Any || e.Text.All(Char.IsDigit))
                base.OnTextInput(e);
        }

        //protected override void OnTextInput(TextCompositionEventArgs e)
        //{
        //    bool isInputValid = true;
        //    switch (InputMode)
        //    {
        //        case InputMode.Any:
        //            isInputValid = true;
        //            break;
        //        case InputMode.Numeric:
        //            isInputValid = e.Text.All(Char.IsDigit);
        //            break;
        //    }
        //    if (isInputValid) base.OnTextInput(e);
        //}
    }

    public enum InputMode
    {
        Numeric,
        Any,
    }
}
