using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 startPos; // Posicion inicial del BackGround
    private float repeartWith;
    private void Awake()
    {
        startPos = transform.position; //Obtenemos la posicion inicial
        repeartWith = GetComponent<BoxCollider>().size.x / 2; //Obtenemos todo el ancho del BackGroud del eje x y lo dividimos en dos, para obtener el punto medio del fondo
    }

    // Update is called once per frame
    void Update()
    {
        //si la posicion actual es < a la posicion inicial, reposicionar el background a la posicion inicial
        if (transform.position.x < startPos.x - repeartWith)
        {
            transform.position = startPos;
        }
    }
}
