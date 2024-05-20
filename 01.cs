using System.Globalization;
using System.Runtime.ExceptionServices;

string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

int RetNum(ref string input) {
    int ret = 0;

    for(int i = 0; i < numbers.Length; i++) {
        if (input.Contains(numbers[i])) { 
            ret = i + 1;
            input = "";
            break;
        }
    }

    return ret;
}

string path = "C:\\Users\\MlpLu\\Documents\\Programming projects\\AdventOfCode2023\\input01.txt",
       path1 = "C:\\Users\\MlpLu\\Documents\\Programming projects\\AdventOfCode2023\\message.txt";

if (File.Exists(path)) {
    using (StreamReader sr = new StreamReader(path)) {
        string line;
        int sum = 0;

        while ((line = sr.ReadLine()) != null) {
            string temp = "";
            int firs = 0,
                last = 0;

            foreach (char c in line) {
                if ((int)c > 48 && (int)c < 58) {
                    temp = "";

                    if (firs == 0) {
                        firs = c - '0';
                    }
                    
                    last = c - '0';
                }
                else {
                    temp += c.ToString();
                    int i = RetNum(ref temp);

                    if (i != 0) {
                        if (firs == 0) {
                            firs = i;
                        }

                        last = i;
                        temp += c.ToString();
                    }
                }
            }

            sum += firs * 10 + last;
        }

        Console.WriteLine(sum);
    }    
}
else {
    Console.WriteLine("None");
}