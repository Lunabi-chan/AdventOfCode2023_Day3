using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.ExceptionServices;

string[] color_names = { "blue", "red", "green" };

bool RetBool(string input) {
    foreach (string j in input.Split(',')) {
        // 12 red 13 green 14 blue
        int[] colors = { 14, 12, 13 };

        for (int k = 0; k < 3; k++) {
            if (j.Contains(color_names[k])) {
                if (colors[k] < Convert.ToInt32(j.Split(' ')[1])) {
                    return false;
                }
            }
        }
    }

    return true;
}

int RetNum(string[] input) {
    int[] colors = { 1, 1, 1 };

    foreach (string i in input) {
        foreach (string j in i.Split(',')) {
            for (int k = 0; k < 3; k++) {
                if (j.Contains(color_names[k])) {
                    if (colors[k] < Convert.ToInt32(j.Split(' ')[1])) {
                        colors[k] = Convert.ToInt32(j.Split(' ')[1]);
                    }
                }
            }
        }
    }

    return colors[0] * colors[1] * colors[2];
}


string path = "C:\\Users\\MlpLu\\Documents\\Programming projects\\AdventOfCode2023\\input02.txt",
       path1 = "C:\\Users\\MlpLu\\Documents\\Programming projects\\AdventOfCode2023\\misc.txt";


if (File.Exists(path)) {
    using (StreamReader sr = new StreamReader(path)) {
        string line;
        int sum = 0,
            sum2 = 0;

        while ((line = sr.ReadLine()) != null) {
            string[] c = line.Split(':'),
                     b = c[1].Split(';');
            bool ye = true;

            foreach (string i in b) {
                if (!RetBool(i)) {
                    ye = false;
                }
            }

            if (ye) {
                sum += Convert.ToInt32(c[0].Split(' ')[1]);
            }

            sum2 += RetNum(b);
        }

        Console.WriteLine(sum);
        Console.WriteLine(sum2);
    }
}
else {
    Console.WriteLine("None");
}