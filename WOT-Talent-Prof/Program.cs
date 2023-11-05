string Mut              = "MU";
string Klugheit         = "KL";
string Intuition        = "IN";
string Charisma         = "CA";

string Fingerfertigkeit = "FF";
string Gewandheit       = "GE";
string Konstitution     = "KO";
string Körperkraft      = "KK";

//Char
Dictionary<string, int> fertigkeiten = new Dictionary<string, int>();
fertigkeiten.Add(Mut,               8);
fertigkeiten.Add(Klugheit,          8);
fertigkeiten.Add(Intuition,         10);
fertigkeiten.Add(Charisma,          8);

fertigkeiten.Add(Fingerfertigkeit,  11);
fertigkeiten.Add(Gewandheit,        8);
fertigkeiten.Add(Konstitution,      12);
fertigkeiten.Add(Körperkraft,       7);


//Talent
(string, string, string) Talent = (Klugheit, Klugheit, Intuition);
int TaW = 10;


List<(string, bool)> output = new List<(string, bool)>();

int ausgleich = 0;
for(int w1 = 1; w1 <= 20; w1++)
{
    int f1 = fertigkeiten[Talent.Item1];
    var ausgleich1 = ausgleich;

    if (TaW < 0)
    {
        f1 = f1 - 2;
    }
    else
    {
        for(int i = ausgleich1; ausgleich1 <= TaW && f1 < w1; ausgleich1++)
        {
            f1 = f1 + 1;
        }
    }


    for (int w2 = 1; w2 <= 20; w2++)
    {
        int f2 = fertigkeiten[Talent.Item2];
        var ausgleich2 = ausgleich1;


        if (TaW < 0)
        {
            f2 = f2 - 2;
        }
        else
        {
            for (int i = ausgleich2; ausgleich2 <= TaW && f2 <= w2; ausgleich2++)
            {
                f2 = f2 + 1;
            }
        }

        for (int w3 = 1; w3 <= 20; w3++)
        {
            int f3 = fertigkeiten[Talent.Item3];
            var ausgleich3 = ausgleich2;


            if (TaW < 0)
            {
                f3 = f3 - 2;
            }
            else
            {
                for (int i = ausgleich3; ausgleich3 <= TaW && f3 < w3; ausgleich3++)
                {
                    f3 = f3 + 1;
                }
            }

            //Success Eval
            var x = (Eval(w1, f1) + Eval(w2, f2) + Eval(w3, f3));
            
            output.Add(($"{w1}, {w2}, {w3} | Rest:{TaW - ausgleich3} | Out:{x} ", x >= 2));
        }
    }
}

Console.WriteLine(String.Join("\n", output));

Console.WriteLine($"{output.Where(x => x.Item2 == true).Count()} / {output.Count()}" );



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