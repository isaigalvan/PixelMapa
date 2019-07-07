using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RestablecerCasilla 
{
    public static bool respawn;

    //Leonn
    public static int casModif;
    public static bool hayHab2, esDes1, esDes2;

    //Austin
    public static int[] pintadas = new int[20];
    public static int contPint = 0;
    public static bool hayPint, hayPint1;
    public static float casRec;

    //
    public static bool pusoCasPer1, pusoCasPer2;

    //------------------------------RESPAWN-----------------------------------------
    public static void ponerRespawn(bool resp)
    {
        respawn = resp;
    }
    public static bool obtenerRespawn()
    {
        return respawn;
    }
    //------------------------------casModif1-----------------------------------------
    public static void ponerCasModif1(int cas)
    {
        casModif = cas;
    }
    public static int obtenercasModif1()
    {
        return casModif;
    }
    //------------------------------Pintadas-----------------------------------------
    public static void ponerPintada(int cas)
    {
        pintadas[contPint] = cas;
        contPint++;
    }
    public static int obtenerPintada(int cas)
    {
        return pintadas[cas];
    }

    public static void inicializarPint()
    {
        for(int x = 0; x <= 10; x++)
        {
            pintadas[x] = 0;
            contPint = 0;
        }
      
    }

}
