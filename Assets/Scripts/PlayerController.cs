using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private ParticleSystem water;
    private float lookAroundSpeed = 20;
    private float rotateSpeed = 2;
    private float rotateMouseX;

    private void Update()
    {
        if (GameManager.IsPlay)
        {
            RotatePlayer();
            WaterShot();
        }
        else
            water.Stop();
    }

    private void RotatePlayer()
    {
        transform.RotateAround(target.transform.position, Vector3.up, lookAroundSpeed * Time.deltaTime);
    }

    private void WaterShot()
    {
        if(Input.GetMouseButtonDown(0))
            water.Play();

        if (Input.GetMouseButton(0))
        {
            float rotateYRange = 50f;
            rotateMouseX += Input.GetAxis("Mouse X") * rotateSpeed;
            rotateMouseX = Mathf.Clamp(rotateMouseX, -rotateYRange, rotateYRange);

            Quaternion rotate = Quaternion.Euler(0, rotateMouseX, 0);
            water.gameObject.transform.localRotation = rotate;
        }
        else
            water.Stop();
    }
}
