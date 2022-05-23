public class SaveData
{
    public uint Score { get; private set; }

    public SaveData()
    {
        Score = 0;
    }

    public SaveData(uint Score)
    {
        this.Score = Score;

        //запись в файл
    }
}
