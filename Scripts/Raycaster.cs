using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private void Update()
    {
        ThrowRay();
    }

    private void ThrowRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.TryGetComponent<Coin>(out var coin) == true)
                {
                    coin.ChangeColor();
                }
            }
        }
    }
}

