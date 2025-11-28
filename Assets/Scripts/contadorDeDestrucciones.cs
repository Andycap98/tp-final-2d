using UnityEngine;

public static class contadorDeDestrucciones

{
    private static int score = 0; //variable para almacenar el score actual
    public static event System.Action OnScoreChanged; //evento para notificar cambios en el score

    

    public static void sumarScore()
    {
        score = PlayerPrefs.GetInt("score", 0);
        score++;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        OnScoreChanged?.Invoke(); //notificar a los scripts que estan escuchando a esta variable que el score ha cambiado


    }


    public static int getScore() //metodo para obtener el score actual
    {
        return score;
    }
    public static void resetScore()
    {
        score = 0;
        
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        


    }
}
