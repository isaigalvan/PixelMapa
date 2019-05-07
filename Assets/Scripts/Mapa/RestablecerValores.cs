using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RestablecerValores
{
    public static bool respawn=false;

    //CrearPersonaje
    public static float posx=5, posy;
   
    //Personaje
    public static bool[] estados = new bool[3];  // 0-Pintado    1-Bloqueado     2-Inmune
    public static int casillaActual = 0, ph = 0;



    // Update is called once per frame


    //-------------------------------POSX-----------------------------------------
    public static void ponerPosx(float ingresaPosx)
    {
        posx = ingresaPosx;
    }
    public static void ponerPosy(float ingresaPosy)
    {
        posy = ingresaPosy;
    }
    //-------------------------------POSY-----------------------------------------
    public static float obtenerPosx()
    {
        return posx;
    }
    public static float obtenerPosy()
    {
        return posy;
    }
    //------------------------------RESPAWN-----------------------------------------
    public static void ponerRespawn(bool resp)
    {
        respawn = resp;
    }
    public static bool obtenerRespawn()
    {
        return respawn;
    }
    //-------------------------------CASILLA ACTUAL-----------------------------------------
    public static void ponerCasilla(int cas)
    {
        casillaActual = cas;
    }
    public static int obtenerCasilla()
    {
        return casillaActual;
    }
    //-------------------------------PH-----------------------------------------
    public static void ponerPH(int newph)
    {
        ph = newph;
    }
    public static int obtenerPH()
    {
        return ph;
    }
}
