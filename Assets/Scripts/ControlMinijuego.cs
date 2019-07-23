using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlMinijuego : MonoBehaviour
{
    public int sel;
    public TextMeshProUGUI titu, desc;
    public GameObject icono;
    public SpriteRenderer iconoR;
    public Sprite[] spriteIcono;
    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        sel = Random.Range(1, 8);
        
    }

    // Update is called once per frame
    void Update()
    {
        iconoR = icono.GetComponent<SpriteRenderer>();
        minijuego();
        tiempo = Time.deltaTime + tiempo;
        if (tiempo >= 4)
        {
            escena();
        }
    }

    public void escena()
    {
        switch (sel)
        {
            case 1:
                SceneManager.LoadScene("02-Infla el globo");
                break;
            case 2:
                SceneManager.LoadScene("03-Adivina el cofre");
                break;
            case 3:
                SceneManager.LoadScene("04-Atrapa el robot");
                break;
            case 4:
                SceneManager.LoadScene("05-Memorama");
                break;
            case 5:
                SceneManager.LoadScene("06-Dardos");
                break;
            case 6:
                SceneManager.LoadScene("07-Recoger Manzanas");
                break;
            case 7:
                SceneManager.LoadScene("08-Ordenar pasteles");
                break;
        }
    }

    public void minijuego()
    {
        switch (sel)
        {
            case 1:
                titu.text = "Infla el globo";
                iconoR.sprite = spriteIcono[0];
                desc.text = "infla el globo hasta ser el primero que lo reviente";
                break;
            case 2:
                titu.text = "Adivina el cofre";
                iconoR.sprite = spriteIcono[1];
                desc.text = "Abre el cofre que tenga el tesoro y ganaras";
                break;
            case 3:
                titu.text = "Atrapa el robot";
                iconoR.sprite = spriteIcono[2];
                desc.text = "Atrapa la mayor cantidad de robots dentro del rancho espacial";
                break;
            case 4:
                titu.text = "Memorama";
                iconoR.sprite = spriteIcono[3];
                desc.text = "Encuentra la mayor cantidad de pares en el memorama";
                break;
            case 5:
                titu.text = "Dardos";
                iconoR.sprite = spriteIcono[4];
                desc.text = "Revienta la mayor cantidad de globos tirando el dardo";
                break;
            case 6:
                titu.text = "Recoge Manzanas";
                iconoR.sprite = spriteIcono[5];
                desc.text = "Atrapa la mayor cantidad de manzanas posibles";
                break;
            case 7:
                titu.text = "Ordena Pasteles";
                iconoR.sprite = spriteIcono[6];
                desc.text = "Toma y guarda el pastel que te toco en su respectiva caja";
                break;
        }
    }

 
}
