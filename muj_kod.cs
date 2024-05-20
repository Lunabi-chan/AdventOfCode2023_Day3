using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

namespace my_space {
    public struct Interval {
        public int a;
        public int b;

        public Interval(int a, int b) {
            this.a = a;
            this.b = b;
        }
    }

    class Program {
        public static bool IsSymbol(char symbol) {
            return (!char.IsAsciiDigit(symbol) && symbol != '.') ? true : false;
        }
        public static string EmptyLineBuilder(int n) {
            StringBuilder empty_line = new StringBuilder();
            empty_line.Append('.', n);
            return empty_line.ToString();
        }
        public static List<Interval> IntervalsOfNumbers (string line) {
            int a = 0;
            bool length = false;
            List<Interval> list = new List<Interval> ();
            
            for (int i = 0; i < line.Length; i++) {
                if (char.IsAsciiDigit(line[i]) && !length) {
                    a = i;
                    length = true;
                }

                if (!char.IsAsciiDigit(line[i]) && length) {
                    list.Add(new Interval(a, i - 1));
                    length = false;
                }
            }

            if (length) {
                list.Add(new Interval(a, line.Length - 1));
            }

            return list;
        }
        public static List<int> ListOfNumbers(string line) {
            List<int> list = new List<int>();
            StringBuilder number = new StringBuilder();

            foreach (char c in line) {
                if (char.IsAsciiDigit(c)) {
                    number.Append(c);
                }
                else if (number.Length != 0) {
                    list.Add(int.Parse(number.ToString()));
                    number = new StringBuilder();
                }
            }

            if (number.Length != 0) {
                list.Add(int.Parse(number.ToString()));
            }

            return list;
        }

        static void Main(string[] args) {
            string basePath = Environment.CurrentDirectory;
            string? path = args.Length == 0 ? Console.ReadLine() : Path.GetFullPath(args[0], basePath);

            if (File.Exists(path)) {
                int sum = 0;

                using (StreamReader sr = new StreamReader(path)) {
                    List<Interval>? intervalList = new List<Interval>();
                    List<int>? numberList = new List<int>();

                    string? l,
                            firstLine,
                            secondLine,
                            thirdLine = sr.ReadLine();

                    int lineLen = thirdLine != null ? thirdLine.Length: 0;
                    string emptyLine = EmptyLineBuilder(lineLen);

                    secondLine = emptyLine;

                    bool cond = true;

                    while (cond) {
                        firstLine = secondLine;
                        secondLine = thirdLine;

                        if (secondLine != null && firstLine != null) {
                            intervalList = IntervalsOfNumbers(secondLine);
                            numberList = ListOfNumbers(secondLine);

                            if ((l = sr.ReadLine()) == null) {
                                cond = false;
                            }

                            thirdLine = l == null ? emptyLine : l;

                            for (int i = 0; i < intervalList?.Count; i++) {
                                Interval j = intervalList[i];

                                int left_number = (j.a - 1) < 0 ? 0 : j.a - 1,
                                    right_number = (j.b + 1) >= lineLen ? j.b : j.b + 1;

                                bool belongs = false;

                                if (IsSymbol(secondLine[left_number]) || IsSymbol(secondLine[right_number])) {
                                    belongs = true;
                                }
                                else {
                                    for (int k = left_number; k <= right_number; k++) {
                                        if (IsSymbol(firstLine[k]) || IsSymbol(thirdLine[k])) {
                                            belongs = true;
                                            break;
                                        }
                                    }
                                }
                                sum += belongs ? numberList[i] : 0;
                            }
                        }
                    }
                }
                Console.WriteLine(sum);
            }
            else {
                Console.WriteLine("None");
            }
            Console.ReadKey();
        }
    }
}