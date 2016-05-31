using UnityEngine;
using System.Collections;

public class ButtonHolder : MonoBehaviour {

    ButtonHolderState state;
    public float lowestY = -20f;
    public float highestY = 0f;
    [Range(0f, 1000f)]
    public float speed = 5f;

    enum ButtonHolderState
    {
        Up,
        Down,
        Lowering,
        Rising
    }

    void Awake()
    {
        state = ButtonHolderState.Up;
        highestY = transform.position.y;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnButtonPress();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnRaiseUpEvent();
        }


        if (state == ButtonHolderState.Lowering)
        {
            Vector3 translation = new Vector3();
            translation.y = -speed * Time.deltaTime;
            transform.Translate(translation);
            if (transform.position.y < lowestY)
            {
                Vector3 newPos = transform.position;
                newPos.y = lowestY;
                transform.position = newPos;
                state = ButtonHolderState.Down;
            }
        } else if (state == ButtonHolderState.Rising)
        {
            Vector3 translation = new Vector3();
            translation.y = speed * Time.deltaTime;
            transform.Translate(translation);
            if (transform.position.y > highestY)
            {
                Vector3 newPos = transform.position;
                newPos.y = highestY;
                transform.position = newPos;
                state = ButtonHolderState.Up;
            }
        }
    }

    void OnButtonPress()
    {
        if (state == ButtonHolderState.Up || state == ButtonHolderState.Rising)
        {
            state = ButtonHolderState.Lowering;
        }
    }

    void OnRaiseUpEvent()
    {
        if (state == ButtonHolderState.Down || state == ButtonHolderState.Lowering)
        {
            state = ButtonHolderState.Rising;
        }
    }
}
