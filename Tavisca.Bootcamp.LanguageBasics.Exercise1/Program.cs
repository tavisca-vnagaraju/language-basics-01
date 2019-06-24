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
            string first_operand = string.Empty;
            string second_operand = string.Empty;
            string right_operand = string.Empty;
            int firstCount = 0;
            int secondCount = 0;
            int int_first_operand =0;
            int int_second_operand =0;
            int int_right_operand =0;
            var result = string.Empty;
            var ans = 0;
            var int_result =0;
            
            for (int i = 0; i < equation.Length; i++){
                if(equation[i] == '*'){
                    firstCount = i;
                }else if(equation[i] == '='){
                    secondCount =i;
                }
            }
            first_operand = equation.Substring(0,firstCount);
            int length = secondCount - firstCount;
            second_operand = equation.Substring(firstCount+1,length-1);
            length = equation.Length - secondCount;
            right_operand = equation.Substring(secondCount+1,length-1);

            int.TryParse(first_operand,out int_first_operand);
            int.TryParse(second_operand,out int_second_operand);
            int.TryParse(right_operand,out int_right_operand);

            if(first_operand.Contains("?")){
                result = ( int_right_operand / int_second_operand ) .ToString();
                if(first_operand.Length == result.Length){
                    int i = first_operand.IndexOf("?");
                    int.TryParse(result[i].ToString(),out ans);
                    return ans;
                }else{
                    return -1;
                }
            }else if(second_operand.Contains("?")){
                int_result = (int_right_operand / int_first_operand );
                result = int_result.ToString();
                if(second_operand.Length == result.Length && int_result * int_first_operand == int_right_operand){
                    int i = second_operand.IndexOf("?");
                    int.TryParse(result[i].ToString(),out ans);
                    return ans;
                }else{
                    return -1;
                }
            }else if(right_operand.Contains("?")){
                result = (int_first_operand * int_second_operand ).ToString();
                if(right_operand.Length == result.Length ){
                    int i = right_operand.IndexOf("?");
                    int.TryParse(result[i].ToString(),out ans);
                    return ans;
                }
            }
            return -1;
        }
    }
}
