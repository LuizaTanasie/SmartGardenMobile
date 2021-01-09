using SimpleExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartGardenMobile.Helpers
{
    public class MathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            // Parse value into equation and remove spaces
            var mathEquation = parameter as string;
            mathEquation = mathEquation.Replace(" ", "");
            mathEquation = mathEquation.Replace("@VALUE", value.ToString());
            ExpressionEvaluator engine = new ExpressionEvaluator();
            return engine.Evaluate(mathEquation);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
