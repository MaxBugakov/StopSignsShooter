using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Player player;
    void Update()
    {
        if (!MenuController.isMenuOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject.CompareTag("StopTag"))
                    {
                        // Убмраем стоп знак вниз;
                        hit.collider.gameObject.GetComponent<StopSignHitController>().Hit();
                        // Добавляем очки игроку.
                        player.AddScore();
                    }
                }
            }
        }
    }
}