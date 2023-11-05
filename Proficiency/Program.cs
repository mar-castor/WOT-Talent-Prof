string MU = "MU"; string FF = "FF";
string KL = "KL"; string GE = "GE";
string IN = "IN"; string KO = "KO";
string CH = "CA"; string KK = "KK";

//Char
Dictionary<string, int> statArray = new Dictionary<string, int>();

SetFertigkeiten(10, 4, 6, 5, 4, 8, 7, 10, statArray);


//Talent
(string, string, string) Talent = (KL,FF,KK);
int TaW = 6;
int ausgleich = 0;

List<(string, bool)> output = new List<(string, bool)>();

for (int w1 = 1; w1 <= 20; w1++)
{
    int f1 = statArray.GetValueOrDefault(Talent.Item1);
    var ausgleich1 = ausgleich;

    f1 = TaWApply(TaW, f1, w1, ref ausgleich1);

    for (int w2 = 1; w2 <= 20; w2++)
    {
        int f2 = statArray.GetValueOrDefault(Talent.Item2);
        var ausgleich2 = ausgleich1;

        f2 = TaWApply(TaW, f2, w2, ref ausgleich2);

        for (int w3 = 1; w3 <= 20; w3++)
        {
            int f3 = statArray.GetValueOrDefault(Talent.Item3);
            var ausgleich3 = ausgleich2;

            f3 = TaWApply(TaW, f3, w3, ref ausgleich3);

            //Success Eval
            var x = (Eval(w1, f1) + Eval(w2, f2) + Eval(w3, f3));

            output.Add(($"{w1}, {w2}, {w3} | Rest:{TaW - ausgleich3} | Out:{x} ", x >= 2));
        }
    }
}

//Console.WriteLine(String.Join("\n", output));

Console.WriteLine($"{output.Where(x => x.Item2 == true).Count()} / {output.Count()}");
Console.WriteLine($"{(float)output.Where(x => x.Item2 == true).Count() / output.Count() * 100}");
Console.WriteLine("--");

int Eval(int w, int f)
{
    if (w == 1)
    {
        return 2;
    }
    if (w == 20)
    {
        return -2;
    }

    return (f >= w ? 1 : 0);
}

int TaWApply(int taW, int f, int w, ref int ausgleich)
{
    if (TaW < 0)
    {
        f = f - 2;
    }
    else
    {
        for (int i = ausgleich; ausgleich < TaW && f < w; ausgleich++)
        {
            f = f + 1;
        }
    }
    return f;
}

void SetFertigkeiten(int Mut, int Finger, int Klug, int Gewand, int Intu, int Konst, int Char, int Körper, Dictionary<string, int> statArray)
{
    statArray.Add(MU, Mut);
    statArray.Add(KL, Klug);
    statArray.Add(IN, Intu);
    statArray.Add(CH, Char);

    statArray.Add(FF, Finger);
    statArray.Add(GE, Gewand);
    statArray.Add(KO, Konst);
    statArray.Add(KK, Körper);
}