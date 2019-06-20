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
            string A = string.Empty;
            string B = string.Empty;
            string C = string.Empty;
            int firstCount = 0;
            int secondCount = 0;
            var result = 0;
            for (int i = 0; i < equation.Length; i++){
                if(equation[i] == '*'){
                    firstCount = i;
                }else if(equation[i] == '='){
                    secondCount =i;
                }
            }
            A = equation.Substring(0,firstCount);
            int length = secondCount - firstCount;
            B = equation.Substring(firstCount+1,length-1);
            length = equation.Length - secondCount;
            C = equation.Substring(secondCount+1,length-1);
            
            if(A.Contains("?")){
                result = Int32.Parse(C) / Int32.Parse(B);
                if(A.Length == result.ToString().Length){
                    int i = A.IndexOf("?");
                    var ans = result.ToString()[i].ToString();
                    return Int32.Parse(ans);
                }else{
                    return -1;
                }
            }else if(B.Contains("?")){
                result = Int32.Parse(C) / Int32.Parse(A);
                if(B.Length == result.ToString().Length && result * Int32.Parse(A) == Int32.Parse(C)){
                    int i = B.IndexOf("?");
                    var ans = result.ToString()[i].ToString();
                    return Int32.Parse(ans);
                }else{
                    return -1;
                }
            }else if(C.Contains("?")){
                result = Int32.Parse(A) * Int32.Parse(B);
                if(C.Length == result.ToString().Length ){
                    int i = C.IndexOf("?");
                    var ans = result.ToString()[i].ToString();
                    return Int32.Parse(ans);
                }
            }
            return -1;
        }
    }
}
