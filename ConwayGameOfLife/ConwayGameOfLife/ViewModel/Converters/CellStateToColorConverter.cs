using ConwayGameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ConwayGameOfLife.ViewModel.Converters
{
    public class CellStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CellState currentCellState = (CellState)value;
            Color aliveColor = new Color();
            aliveColor.R = 0;
            aliveColor.G = 255;
            aliveColor.B = 0;
            Color deadColor = new Color();
            deadColor.R = 150;
            deadColor.G = 150;
            deadColor.B = 150;
            if (currentCellState== CellState.Alive)
            {
                return aliveColor;
            }
            else
            {
                return deadColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
