﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TODOLIST2222 : MonoBehaviour {

    //public GameObject pausemenu;
    public GameObject lecture_object;
    public GameObject map;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject arrow;
    static public int villagelecture = 0;
    //public GameObject welcometext;
    private double start_time = 0;
    private double timer = 0;
    private int flag = 0;
    private bool check_1 = false;
    private bool check_2 = false;
    private bool check_todo = false;
    private bool check_grab = false;
    static public int lectureVillage = 0;
    public static bool Lecture1done = false;
    public static bool Lecture2done = false;

    public GameObject Done_1;
    public GameObject Done_2;
    public GameObject Done_3;

    public AudioClip MapClip;
    public AudioClip JarClip;
    public AudioSource MusicSource;

    public GameObject todoreminder;
    public GameObject grabreminder;
    // Use this for initialization

    void Start()
    {
        //MapClip = Resources.Load<AudioClip>("audio/audioMap");
        //JarClip = Resources.Load<AudioClip>("audio/audioJar");
        //MusicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(false);
            Debug.Log("Menu false");
        }
        else if (pausemenu.activeInHierarchy == false && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(true);
            Debug.Log("Menu true");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //SceneManager.LoadScene("StartMenu");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            if (map.activeInHierarchy == true)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }

        }*/
        // learning objectives
        if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= (48 + 17))
        {
            grabreminder.SetActive(false);
        }
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= (48 + 13))
        {
            if (! check_grab)
            {
                grabreminder.SetActive(true);
                check_grab = true;
            }
            OVRPlayerController.MoveScaleMultiplier = 0.6f;
            villagelecture = 0;
        }
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= (48 + 12))
        {
            lecture_object.SetActive(false);
        } 
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= (30 + 12))
        {
            lecture_object.SetActive(true);
        }
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= 11)
        {
            if (! check_1)
            {
                villagelecture = 1;
                MusicSource.Play();
                check_1 = true;
            }
            OVRPlayerController.MoveScaleMultiplier = 0;
        }
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= 10)
        {
            todoreminder.SetActive(false);
        }
        else if (Time.realtimeSinceStartup - ButtonScriptStart.xuehao >= 1)
        {
            if (! check_todo)
            {
                todoreminder.SetActive(true);
                check_todo = true;
            }
        }

        if (ScrollUnfold.grab == 1)
        {
            Debug.Log(ScrollUnfold.grab);
            lectureVillage = 1;
            //Done_1.SetActive(true);
            //voideo

            if (flag == 0)
            {
                start_time = Time.realtimeSinceStartup;
                flag = 1;
            }
            if (Time.realtimeSinceStartup - start_time >= 5 && start_time != 0 && flag == 1)
            {
                MusicSource.clip = MapClip;
                MusicSource.Play();
                OVRPlayerController.MoveScaleMultiplier = 0;
                map.SetActive(true);
                flag = 2;
            }
            if (Time.realtimeSinceStartup - start_time >= 14 && start_time != 0 && flag == 2)
            {
                map.SetActive(false);
                map2.SetActive(true);
                flag = 3;
            }
            if (Time.realtimeSinceStartup - start_time >= 20 && start_time != 0 && flag == 3)
            {
                map2.SetActive(false);
                map3.SetActive(true);
                flag = 4;
            }
            if (Time.realtimeSinceStartup - start_time >= 27 && start_time != 0 && flag == 4)
            {

                map3.SetActive(false);
                map4.SetActive(true);
                flag = 5;
            }
            if (Time.realtimeSinceStartup - start_time >= 50 && start_time != 0 && flag == 5)
            {
                map4.SetActive(false);
                flag = 6;
                Done_1.SetActive(true);
                OVRPlayerController.MoveScaleMultiplier = 0.6f;
                lectureVillage = 0;
                Lecture1done = true;
                ScrollUnfold.grab = 0;
            }
        }
        else if (fixPositionTrigger.shouldFixPos)
        {
            MusicSource.clip = JarClip;
            if (!check_2)
            {
                MusicSource.Play();
                check_2 = true;
                lectureVillage = 1;
                //fix position
                OVRPlayerController.MoveScaleMultiplier = 0f;
            }
            if (!MusicSource.isPlaying)
            {
                Lecture2done = true;
                Done_2.SetActive(true);
                arrow.SetActive(true);
                //recover
                OVRPlayerController.MoveScaleMultiplier = 0.6f;
                lectureVillage = 0;
            }
        }
        else if (StateManager.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }

}
