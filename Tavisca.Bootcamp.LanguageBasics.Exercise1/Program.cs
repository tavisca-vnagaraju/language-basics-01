using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            // Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string firstOperand = string.Empty;
            string secondOperand = string.Empty;
            string rightOperand = string.Empty;
            int firstCount = 0;
            int secondCount = 0;
            int intFirstOperand =0;
            int intSecondOperand =0;
            int intRightOperand =0;
            var result = string.Empty;
            var ans = 0;
            var intResult =0;
            
            for (int index = 0; index < equation.Length; index++){
                if(equation[index] == '*'){
                    firstCount = index;
                }else if(equation[index] == '='){
                    secondCount =index;
                }
            }
            firstOperand = equation.Substring(0,firstCount);
            int length = secondCount - firstCount;
            secondOperand = equation.Substring(firstCount+1,length-1);
            length = equation.Length - secondCount;
            rightOperand = equation.Substring(secondCount+1,length-1);

            int.TryParse(firstOperand,out intFirstOperand);
            int.TryParse(secondOperand,out intSecondOperand);
            int.TryParse(rightOperand,out intRightOperand);

            if(firstOperand.Contains("?")){
                result = ( intRightOperand / intSecondOperand ) .ToString();
                if(firstOperand.Length == result.Length){
                    int index = firstOperand.IndexOf("?");
                    int.TryParse(result[index].ToString(),out ans);
                    return ans;
                }else{
                    return -1;
                }
            }else if(secondOperand.Contains("?")){
                intResult = (intRightOperand / intFirstOperand );
                result = intResult.ToString();
                if(secondOperand.Length == result.Length && intResult * intFirstOperand == intRightOperand){
                    int index = secondOperand.IndexOf("?");
                    int.TryParse(result[index].ToString(),out ans);
                    return ans;
                }else{
                    return -1;
                }
            }else if(rightOperand.Contains("?")){
                result = (intFirstOperand * intSecondOperand ).ToString();
                if(rightOperand.Length == result.Length ){
                    int index = rightOperand.IndexOf("?");
                    int.TryParse(result[index].ToString(),out ans);
                    return ans;
                }
            }
            return -1;
        }
    }
}
