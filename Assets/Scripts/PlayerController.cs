using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public Rigidbody leftRigidbody;
    public Rigidbody rightRigidbody;

    public Slider leftSliderControl;
    public Slider rightSliderControl;

    public ParticleSystem rightParticles;
    public ParticleSystem leftParticles;

    private float leftEngineThrust = 0;
    private float rightEngineThrust = 0;
    private float thrustValue = 5;
    private GameplayUITemp ui;

    private void Start()
    {
        ui = FindObjectOfType<GameplayUITemp>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            leftEngineThrust += thrustValue * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            leftEngineThrust -= thrustValue * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rightEngineThrust += thrustValue * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rightEngineThrust -= thrustValue * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R))
        {
            leftEngineThrust = 0;
            rightEngineThrust = 0;
        }

        //leftEngineThrust = leftSliderControl.value;
        //rightEngineThrust = rightSliderControl.value;

        leftEngineThrust = Mathf.Clamp(leftEngineThrust, -10, 10);
        rightEngineThrust = Mathf.Clamp(rightEngineThrust, -10, 10);

        leftRigidbody.velocity = leftRigidbody.transform.up * leftEngineThrust;
        rightRigidbody.velocity = rightRigidbody.transform.up * rightEngineThrust;
        
        rightParticles.startSpeed = rightEngineThrust * 2;
        leftParticles.startSpeed = leftEngineThrust * 2;

        leftSliderControl.value = leftEngineThrust;
        rightSliderControl.value = rightEngineThrust;

        ui.leftEngineValue.text = leftEngineThrust.ToString();
        ui.rightEngineValue.text = rightEngineThrust.ToString();
    }
}
