using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlMinijuego : MonoBehaviour
{
    public int sel;
    public TextMeshProUGUI titu, desc;
    // Start is called before the first frame update
    void Start()
    {
        sel = Random.Range(1, 8);
    }

    // Update is called once per frame
    void Update()
    {
        titulo();
        descripcion();

    }

    public void titulo()
    {
        switch (sel)
        {
            case 1:
                titu.text = "Infla el globo";
                break;
            case 2:
                titu.text = "Adivina el cofre";
                break;
            case 3:
                titu.text = "Atrapa el robot";
                break;
            case 4:
                titu.text = "Memorama";
                break;
            case 5:
                titu.text = "Dardos";
                break;
            case 6:
                titu.text = "Recoge Manzanas";
                break;
            case 7:
                titu.text = "Ordena Pasteles";
                break;
        }
    }

    public void descripcion()
    {
        switch (sel)
        {
            case 1:
                desc.text = "infla el globo hasta ser el primero que lo reviente";
                break;
            case 2:
                desc.text = "Abre el cofre que tenga el tesoro y ganaras";
                break;
            case 3:
                desc.text = "Atrapa la mayor cantidad de robots dentro del rancho espacial";
                break;
            case 4:
                desc.text = "Encuentra la mayor cantidad de pares en el memorama";
                break;
            case 5:
                desc.text = "Revienta la mayor cantidad de globos tirando el dardo";
                break;
            case 6:
                desc.text = "Atrapa la mayor cantidad de manzanas posibles";
                break;
            case 7:
                desc.text = "Toma y guarda el pastel que te toco en su respectiva caja";
                break;
        }
    }
}
