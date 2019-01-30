using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class AnimationEditing : MonoBehaviour
{
    public Slider sliderController;
    public Transform dancing, random;
    public GameObject btnPause;
    public GameObject btnPlay;
    public Slider sliderRotation;
    public Text txtTitle;

    private Animation legacyAnimation;
    private bool playOnStart = true;
    private bool isPaused = false;
    private float speed = 1;
    private float deltaRotation;
    private float prevRotValue;
    private Transform objToRotate;

    

    void Start()
    {
        //First look for the object that we will be controlling
        LookForObject();
    }

    private void Update()
    {
        //If it's paused, its speed will be set to zero
        if (isPaused)
            legacyAnimation[legacyAnimation.clip.name].speed = 0;
        else
            legacyAnimation[legacyAnimation.clip.name].speed = speed;

        sliderController.value = legacyAnimation[legacyAnimation.clip.name].normalizedTime - Mathf.Floor(legacyAnimation[legacyAnimation.clip.name].normalizedTime);
    }

    public void OnChangeSlider()
    {
        legacyAnimation[legacyAnimation.clip.name].normalizedTime = sliderController.value;
    }

    public void LookForObject()
    {
        if (string.IsNullOrEmpty(SubmenuManager.idAnimation))
            return;

        string[] temp = SubmenuManager.idAnimation.Split(' ');
        if (temp[0] == "Hip")
            txtTitle.text = temp[0] + " " + temp[1];
        else if(temp[0] == "Low" || temp[0] == "Mma")
            txtTitle.text = temp[1];
        else
            txtTitle.text = temp[0];

        if (SubmenuManager.isDancing)
        {
            random.gameObject.SetActive(false);
            Transform child = dancing.Find(SubmenuManager.idAnimation);
            child.gameObject.SetActive(true);
            legacyAnimation = child.GetComponent<Animation>();
            dancing.gameObject.SetActive(true);
            SetAnimationEditing();
            objToRotate = child;
        }
        else
        {
            dancing.gameObject.SetActive(false);
            Transform child = random.Find(SubmenuManager.idAnimation);
            legacyAnimation = child.GetComponent<Animation>();
            child.gameObject.SetActive(true);
            SetAnimationEditing();
            random.gameObject.SetActive(true);
            objToRotate = child;
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

    #region PAUSE
    public void Pausar(bool _isPaused)
    {
        isPaused = _isPaused;
        btnPause.SetActive(!_isPaused);
        btnPlay.SetActive(_isPaused);
    }

    public void OnApplicationPause(bool pause)
    {
        Pausar(pause);
    }
    #endregion

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void RotateObject()
    {
        deltaRotation = sliderRotation.value - prevRotValue;
        objToRotate.Rotate(Vector3.up * deltaRotation * 360);
        prevRotValue = sliderRotation.value;
    }

}
