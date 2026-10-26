/*Script sacado de comentario dentro de Youtube*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlugerScript : MonoBehaviour
{
    float power = 0f;
    public float maxPower = 100f;
    public float launchForce = 1f;
    public Slider powerSlider;

    List<Rigidbody> ballList = new List<Rigidbody>();

    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        powerSlider.value = 0f;
    }

    void Update()
    {
        powerSlider.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.S))
        {
            if (ballList.Count > 0)
            {
                power += 50f * Time.deltaTime;
                power = Mathf.Clamp(power, 0f, maxPower);
            }
        }
        powerSlider.value = power;
        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("SOLTASTE LA TECLA S");

            foreach (Rigidbody r in ballList)
            {
                if (r != null)
                {
                    r.AddForce(
                        Vector3.forward * power * launchForce,
                        ForceMode.Impulse
                    );

                    Debug.Log("PELOTA IMPULSADA");
                }
            }
            power = 0f;
            powerSlider.value = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null && !ballList.Contains(rb))
            {
                ballList.Add(rb);
                Debug.Log("BOLA DETECTADA");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            ballList.Remove(rb);
            power = 0f;
            powerSlider.value = 0f;
        }
    }
}
