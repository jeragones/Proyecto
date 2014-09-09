using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAAG.App_Code
{
    class CustomFunction
    {
        public String codeGenerator()
        {
            Random rnd = new Random();
            int cont = 0;
            int number;
            String code = "";
            while (cont <= 6)
            {
                number = rnd.Next(48, 123);
                if (number < 58 || number > 96)
                {
                    code += (char)number;
                    cont++;
                }
            }
            return code;
        }
    }
}
