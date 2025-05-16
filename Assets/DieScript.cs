using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Die()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Вместо "Destroy(gameObject)" используем имя метода
        Invoke("DestroyObject", 1f);
    }

    // Метод для удаления объекта и его дочерних объектов
    private void DestroyObject()
    {
        Destroy(gameObject); // Удаляет этот объект и все его дочерние объекты
    }
}