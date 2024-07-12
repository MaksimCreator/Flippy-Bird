public class Wallet
{
    public int Score { get; private set; } = 0;

    public void AddScore()
        => Score += 1;
}
