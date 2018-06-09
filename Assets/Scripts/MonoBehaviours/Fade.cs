using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : Singleton<Fade> {

    public RawImage fillImage;

    void Start() {
        FadeFromBlack();
    }

	public void FadeToBlack(float fadeTime=1f) {
        fillImage.gameObject.SetActive(true);
        fillImage.CrossFadeAlpha(1f, fadeTime, false);
    }

    public void FadeFromBlack(float fadeTime=1f) {
        fillImage.gameObject.SetActive(true);
        fillImage.color = Color.black;
        fillImage.CrossFadeAlpha(0f, fadeTime, false);
    }
}
