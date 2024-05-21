# Popis Vámi zvoleného prostředí a zejména instrukce k přeložení a spuštění vašeho programu
- Jako technologii jsem si zvolila C# a úlohu jsem programovala v prostředí Visual Studio 2022. V příloze je zip s celým projektem. Zdroj kodu je v souboru "muj_kod.cs".
- Nejdříve se musí rozjet a 'build' soubor "AdventOfCode2023.sln". Poté se překlikáte přes bin -> Debug -> net7.0, tak by tam měl být soubor AdventOfCode2023.exe
- Pomocí příkazového řádku postoupíte jako bylo zadáno (mapka.txt je přejmenována na input03.txt):
> AdventOfCode2023.exe input03.txt
- Jestli kód spustíte z prostředí VS 2022, tak se vám zobrazí okno, kde se zadá cesta k souboru s daty mapky.

# Popis použitého algoritmu
- Vytvořila jsem si strukturu intervalu, která mi držela levou a pravou mez čísla, kterou jsem si pak ukládala do listu intervalList za pomocí metody IntervalsOfNumbers (tam jsem používala cyklus for, aby mi projel řádek).
- Metoda IsSymbol mi vracela bool, zda znak, který obdržel je libovolný znak jiný než číslice a tečka.
- EmptyLineBuilder postavil prázdný řádek (obsahující jen tečky), který jsem využila jako první a poslední řádek.
- Do numberList jsem si ukládala čísla z řádku, který čtu. 
- V programu jsem využila cyklus while, který posouval řádkami jakoby nahoru. Vždy jsem kontrolovala "2. řádek" ze tří a dívala se zda s číslicemi nesousedí nějaký znak. Jestli sousedí, tak jsem čísla sečetla do sumy.

**Kdybych na něco zapomněla nebo by byly další dotazy, tak prosím napište. Předem se omlouvám za vágní vysvětlení.**

# Vypočtená hodnota
Vypočtenou hodnotu, kterou jsem dostala je: **557705**
