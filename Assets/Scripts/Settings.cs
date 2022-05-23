using UnityEngine;

public class Settings
{
    private const string DIFICULT_KEY = "DificultSettings";

    public float Dificult { get; set; }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey(DIFICULT_KEY))
        {
            Dificult = PlayerPrefs.GetFloat(DIFICULT_KEY);
        }
        else
        {
            Dificult = 1.3f;    //медленная скорость    
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(DIFICULT_KEY, (int)Dificult);
    }
}
