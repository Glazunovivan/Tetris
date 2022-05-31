using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public Dificult Dificult { get; set; }

    public Dificult LoadSettings()
    {
        Dificult = new Dificult();

        if (PlayerPrefs.HasKey(Dificult.KEY_DIFICULT))
        {
            Dificult.Value = PlayerPrefs.GetFloat(Dificult.KEY_DIFICULT);
        }
        else
        {
            Dificult.Value = 1.3f;    //медленная скорость    
        }

        return Dificult;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(Dificult.KEY_DIFICULT, Dificult.Value);
    }
}

public class Dificult
{
    public const string KEY_DIFICULT = "DIFICULT";

    public float Value { get; set; }
}
