using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Validator
{
    public class InputValidator : IInputValidator
    {

        public bool ValidateSpiderInput(string spiderPosition)
        {
            string[] positions = spiderPosition.Trim().Split(' ');
            int result;
            if (positions.Length == 3 && int.TryParse(positions[0], out result) && int.TryParse(positions[1], out result)
                && (positions[2].ToString().ToUpper() == "RIGHT" || positions[2].ToString().ToUpper() == "LEFT"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Input is not in correct format.");
                return false;
            }
        }

        public bool ValidateWallInput(string wallTopOrientation)
        {
            string[] positions = wallTopOrientation.Trim().Split(' ');
            int result;
            if (positions.Length == 2 && int.TryParse(positions[0], out result) && int.TryParse(positions[1], out result))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Input is not in correct format.");
                return false;
            }
        }
        public bool ValidateInstruction(string moveInstruction)
        {
            string pattern = @"^[FLR]+$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(moveInstruction))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Input is not in correct format.");
                return false;
            }
        }
    }
}
