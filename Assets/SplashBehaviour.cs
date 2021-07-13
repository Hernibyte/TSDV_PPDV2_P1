using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SplashBehaviour : MonoBehaviour {
    [SerializeField] Image sprite;
    [SerializeField] TextMeshProUGUI tittle1;

    void Start(){
        StartCoroutine(Transition());
    }

    IEnumerator Transition(){
        float timer = 0;
        Color color = new Color(1f, 1f, 1f, 0f);
        while(timer <= 1f){
            timer += Time.fixedDeltaTime;
            color.a = timer;
            sprite.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);

        while(timer >= 0f){
            timer -= Time.fixedDeltaTime;
            color.a = timer;
            sprite.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);

        while(timer <= 1f){
            timer += Time.fixedDeltaTime;
            color.a = timer;
            tittle1.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);

        while(timer >= 0f){
            timer -= Time.fixedDeltaTime;
            color.a = timer;
            tittle1.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);

        SceneBehaviour.StaticLoadScene("Menu");

        yield return null;
    }
}
