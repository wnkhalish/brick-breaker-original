using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float minRelativePosX = 1f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float maxRelativePosX = 15f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float fixedRelativePosY = .64f;  // paddle does not move on the Y directiob
    
    // Unity units of the WIDTH of the screen (e.g. 16)
    [SerializeField]
    public float screenWidthUnits = 16;

    [Header("For Keyboard Controls")]
    [SerializeField] bool useKeyboard = true;
    [SerializeField] float movementSpeed = 10;

    Rigidbody2D rb;
    float xPos;
    float minTravelDistance;
    float maxTravelDistance;

    //For Auto Play
    [Header("Auto Play")]
    [Space(10)]
    [SerializeField] float AutoPlayDelay = 1;
    [SerializeField][Range(0,1)] float lerpSpeed = .3f;
    float waitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(useKeyboard)
        {
            minTravelDistance = Camera.main.ScreenToWorldPoint(Vector2.zero).x + GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
            maxTravelDistance = Camera.main.ScreenToWorldPoint(Vector2.right * Screen.width).x - GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
            xPos = (minTravelDistance + maxTravelDistance) * .5f;
            transform.position = new Vector3(xPos, transform.position.y);
        }
        else
        {
            float startPosX = ConvertPixelToRelativePosition(screenWidthUnits / 2, Screen.width);
            transform.position = GetUpdatedPaddlePosition(startPosX);
        }

        waitCounter = 0;
    } 

    // Update is called once per frame
    void Update()
    {
        waitCounter += Time.deltaTime;
        if(waitCounter >= AutoPlayDelay)
        {
            autoPlay();
        }

        if(useKeyboard)
        {
            getKeyboardInput();
        }
        else
        {
            var relativePosX = ConvertPixelToRelativePosition(pixelPosition: Input.mousePosition.x, Screen.width);
            transform.position = GetUpdatedPaddlePosition(relativePosX);
        }
    }

    void getKeyboardInput()
    {
        if(Input.GetKey(KeyCode.D))
        {
            xPos += movementSpeed * Time.deltaTime;
            waitCounter = 0;
            xPos = Mathf.Clamp(xPos, minTravelDistance, maxTravelDistance);
            rb.MovePosition(new Vector2(xPos, transform.position.y));
        }
        if(Input.GetKey(KeyCode.A))
        {
            xPos -= movementSpeed * Time.deltaTime;
            waitCounter = 0;
            xPos = Mathf.Clamp(xPos, minTravelDistance, maxTravelDistance);
            rb.MovePosition(new Vector2(xPos, transform.position.y));
        }
    }

    void autoPlay()
    {
        if(Ball.instance == null)
        {
            return;
        }

        xPos = Ball.instance.position.x;
        //xPos = Mathf.Clamp(xPos, minTravelDistance, maxTravelDistance);
        rb.MovePosition(Vector2.Lerp(transform.position, new Vector2(xPos, transform.position.y), lerpSpeed));
    }

    public Vector2 GetUpdatedPaddlePosition(float relativePosX)
    {
        // clamps the X position
        float clampedRelativePosX = Mathf.Clamp(relativePosX, minRelativePosX, maxRelativePosX);
        
        Vector2 newPaddlePosition = new Vector2(clampedRelativePosX, fixedRelativePosY);
        return newPaddlePosition;
    }
    
    public float ConvertPixelToRelativePosition(float pixelPosition, int screenWidth)
    { 
        var relativePosition = pixelPosition/screenWidth * screenWidthUnits;
        return relativePosition;
    }

}