using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float limitHorizontal= 2.2f;
    // Roketleri kontrol etmek için kullandýk.
    public bool isup;
    [SerializeField] private bool isPlayer;

    [SerializeField] private float alSpeed;
     private void Update()
    {
        Vector3 newPosition= transform.position;

        if (isPlayer)
        {
            var input = Input.GetAxis("Horizontal");
           newPosition = transform.position + (Vector3.right * (input * speed * Time.deltaTime));
            newPosition.x = Mathf.Clamp(newPosition.x, -limitHorizontal, limitHorizontal);
           
        }
        else
        {
            var al = Mathf.Lerp(newPosition.x, BallController.Instance.transform.position.x, alSpeed*Time.deltaTime);  
            newPosition.x = al;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -limitHorizontal, limitHorizontal);
        transform.position = newPosition;
    }
}
