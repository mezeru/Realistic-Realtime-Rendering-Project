using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Implosion : MonoBehaviour
{
    private Image whiteImage;
    private ParticleSystem particle1;
    private ParticleSystem particle2;
    private ParticleSystem cloud;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject with the "WhiteImage" tag
        whiteImage = GameObject.FindGameObjectWithTag("WhiteImage").GetComponent<Image>();
        particle1 = GameObject.FindGameObjectWithTag("SunIn").GetComponent<ParticleSystem>();
        particle2 = GameObject.FindGameObjectWithTag("SunOut").GetComponent<ParticleSystem>();
        cloud = GameObject.FindGameObjectWithTag("Cloud").GetComponent<ParticleSystem>();

    }

    private IEnumerator WhiteFade()
    {
        whiteImage.color = new Color(1, 1, 1, 1); // Set initial color

        // Uncomment the following lines if you want to implement fading

        yield return new WaitForSeconds(2f);

        var colorModule = particle1.colorOverLifetime;
        colorModule.enabled = true;
        colorModule.color = new ParticleSystem.MinMaxGradient(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0.25f));

        colorModule = particle2.colorOverLifetime;
        colorModule.enabled = true;
        colorModule.color = new ParticleSystem.MinMaxGradient(new Color(1, 1, 1, 1), new Color(200, 200, 255, 0.25f));

        colorModule = cloud.colorOverLifetime;
        colorModule.enabled = true;
        colorModule.color = new ParticleSystem.MinMaxGradient(new Color(1, 1, 1, 0.75f), new Color(1, 1, 1, 0.8f));



        float fadeSpeed = 0.001f;
        Color targetColor = new Color(1, 1, 1, 0);


        while (whiteImage.color.a > 0)
        {
            whiteImage.color = Color.Lerp(whiteImage.color, targetColor, fadeSpeed);
            yield return null; // This line is necessary in a Coroutine to allow for yielding
        }
        

        yield return null;
    }

   
}
