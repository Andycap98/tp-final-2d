using UnityEngine;

public static class contadorDeDestrucciones 
{
    public static void sumarAsteroides() 
    {
        int cantidad = PlayerPrefs.GetInt("asteroides", 0);
        cantidad++;
        PlayerPrefs.SetInt("asteroides", cantidad);
        PlayerPrefs.Save();
    
    
    }

    public static void sumarMeteoritos()
    {
        int cantidad = PlayerPrefs.GetInt("meteoritos", 0);
        cantidad++;
        PlayerPrefs.SetInt("meteoritos", cantidad);
        PlayerPrefs.Save();


    }
}
