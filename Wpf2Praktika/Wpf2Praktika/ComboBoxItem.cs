using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf2Praktika
{
    public class ComboBoxItem
    {


        string displayValue;

        string hiddenValue;



        //Constructor

        public ComboBoxItem(string d, string h)

        {

            displayValue = d;

            hiddenValue = h;

        }



        //Accessor

        public string HiddenValue

        {

            get

            {

                return hiddenValue;

            }

        }



        //Override ToString method

        public override string ToString()

        {

            return displayValue;

        }



        public static explicit operator ComboBoxItem(bool v)

        {

            throw new NotImplementedException();

        }

    }
}
