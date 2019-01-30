using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class AnimationEditing : MonoBehaviour
{
    private Animation legacyAnimation;
    public Slider sliderController;
    public Transform dancing, random;

    private bool playOnStart = true;

    void Start()
    {
        //First look for the object that we will be controlling
        LookForObject();

      
    }

    private void Update()
    {
        sliderController.value = legacyAnimation[legacyAnimation.clip.name].normalizedTime;
    }

    public void OnChangeSlider()
    {
        legacyAnimation[legacyAnimation.clip.name].normalizedTime = sliderController.value;
    }

    public void LookForObject()
    {
        if (string.IsNullOrEmpty(SubmenuManager.idAnimation))
            return;
        if(SubmenuManager.isDancing)
        {
            random.gameObject.SetActive(false);
            Transform child = dancing.Find(SubmenuManager.idAnimation);
            child.gameObject.SetActive(true);
            legacyAnimation = child.GetComponent<Animation>();
            dancing.gameObject.SetActive(true);
            SetAnimationEditing();

        }
        else
        {
            dancing.gameObject.SetActive(false);
            Transform child = random.Find(SubmenuManager.idAnimation);
            legacyAnimation = child.GetComponent<Animation>();
            child.gameObject.SetActive(true);
            SetAnimationEditing();
            random.gameObject.SetActive(true);
        }
    }

    public void SetAnimationEditing()
    {
        legacyAnimation.Play();
        if(!playOnStart)
            legacyAnimation[legacyAnimation.clip.name].speed = 0;
        sliderController.onValueChanged.RemoveAllListeners();

        sliderController.onValueChanged.AddListener(delegate { OnChangeSlider(); });
    }
}
