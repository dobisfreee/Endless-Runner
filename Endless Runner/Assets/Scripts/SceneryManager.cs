using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : SingleTon<SceneryManager> 
{
    [SerializeField] Image screenImage;

   

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                StartCoroutine(AsyncLoad(1));
            }
        }

    }

    public IEnumerator FadeIn()
    {
        screenImage.gameObject.SetActive(true);

        Color color = screenImage.color;
        color.a = 1f;

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        screenImage.gameObject.SetActive(false);
    }
    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        UnityEngine.AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        // { allowSceneActivation }
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� �����Դϴ�. 
        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0;

        // { isDone }
        // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� �����Դϴ�. (�б� ����) 
        while(asyncOperation.isDone == false) 
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // { progress } 
            // �۾��� ���� ���¸� ��Ÿ���� �����Դϴ�. (�б� ����) 
            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;

                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }


            yield return null;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
