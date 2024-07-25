public class Lottery
{

    private static Lottery _instance;
    private Lottery(){}
    private static System.Random random = new System.Random();


    public static Lottery Instance()
    {
        if (_instance == null)
            _instance = new Lottery();
        return _instance;
    }

    public bool FlipCoin()
    {
        return (random.Next(0, 2) == 0);
    }

    public bool TwoOutOfThree()
    {
        return (random.Next(0, 3) < 2);
    }

    public int JustRand(int limit)
    {
        return (random.Next(0, limit));
    }

}