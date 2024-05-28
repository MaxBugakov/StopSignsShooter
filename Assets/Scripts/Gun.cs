using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    public Vector3 defaulfGunPosition;
    public Vector3 aimingGunPosition;
    public GameObject aim;
    public float shootAnimationAngle;
    public float shootAnimationTime;
    public float aimingAnimationSpeed;
    
    private bool isRightMousePressed;
    private bool isShootAnimationGoing;
    private float shootAnimationGoingTime = 0;

    void Update()
    {
        if (!MenuController.isMenuOpen)
        {
            AimingAnimation();
            ShootAnimation();
        }
    }
    
    // Анимация прицеливания.
    private void AimingAnimation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRightMousePressed = true;
            aim.SetActive(false);
        }
        if (isRightMousePressed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimingGunPosition, aimingAnimationSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightMousePressed = false;
            aim.SetActive(true);
        }
        if (isRightMousePressed == false && transform.localPosition != defaulfGunPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaulfGunPosition, aimingAnimationSpeed * Time.deltaTime);
        }
    }

    // Анимация выстрела.
    private void ShootAnimation()
    {
        if (Input.GetMouseButtonDown(0) && !isShootAnimationGoing)
        {
            transform.DOPunchRotation(new Vector3(shootAnimationAngle, 0, 0), shootAnimationTime);
            isShootAnimationGoing = true;
            shootAnimationGoingTime += Time.deltaTime;
        }

        if (isShootAnimationGoing)
        {
            shootAnimationGoingTime += Time.deltaTime;
            if (shootAnimationGoingTime > shootAnimationTime)
            {
                isShootAnimationGoing = false;
                shootAnimationGoingTime = 0;
            }
        }
    }
}
