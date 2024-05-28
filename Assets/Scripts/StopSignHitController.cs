using UnityEngine;

public class StopSignHitController : MonoBehaviour
{
    private bool wasHitted;
    private float timer;
   
    void Update()
    {
        if (wasHitted)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                wasHitted = false;
                timer = 0;
                gameObject.transform.localPosition += new Vector3(0, 100, 0);
            }
        }
    }

    public void Hit()
    {
        wasHitted = true;
        gameObject.transform.localPosition += new Vector3(0, -100, 0);
    }
}
