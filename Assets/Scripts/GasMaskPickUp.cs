using UnityEngine;

public class GasMaskPickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tuk");
            // Устанавливаем переменную gasMask в true
            SlowZone.gasMask = true;

            // Делаем объект невидимым
            GetComponent<Renderer>().enabled = false;  // Отключаем рендерер

            // Опционально: вы можете также отключить коллайдер, чтобы избежать повторных столкновений
            GetComponent<Collider>().enabled = false;

            // Опционально: если хотите уничтожить объект после подбора
            Destroy(gameObject);
        }
    }
}