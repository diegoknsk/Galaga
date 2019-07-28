using UnityEngine;

public class MouseInputShipBehaviour : MonoBehaviour
{

    protected Vector2 nextPosition;
    protected SpriteRenderer spriteRender;
    protected Vector3 worldDimension;



    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        //converte o tamanho absoluto do dispositivo de saida para tamanho relativo no unity
        worldDimension = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Start is called before the first frame update   

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(" mouse Position " + Input.mousePosition);
        //Debug.Log(" transform position " +transform.position);

        nextPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        if(VerifyScreenLimits(nextPosition))
        {
            transform.position = nextPosition;
        }


    }

    private bool VerifyScreenLimits(Vector2 nextPosition)
    {
        var allowPosition = false;
        Debug.Log(nextPosition);
        if (nextPosition.x < worldDimension.x - (spriteRender.size.x / 2) &&
            (nextPosition.x > - worldDimension.x + (spriteRender.size.x / 2)))
        {
            allowPosition = true;
        }

        return allowPosition;
    }



}
