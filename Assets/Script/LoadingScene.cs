using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    [SerializeField]
    private GameObject CutScene;
    [SerializeField]
    public Animator animator;

    [SerializeField]
    public GameObject LoadingCanvas;
    /*
        public static void CallLoading(string sceneName)
        {
            PlayerPrefs.SetString("Scene", sceneName);
            //SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
        }

        private void Start()
        {
            StartCoroutine(LoadScene());
            DontDestroyOnLoad(gameObject);
        }

        IEnumerator LoadScene()
        {
            string sceneName = PlayerPrefs.GetString("Scene", "MainScene");

            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
            async.allowSceneActivation = false;

            while (!async.isDone)
            {
                Debug.Log("�ε� �����: " + async.progress);
                if (async.progress >= 0.9f && !animationDone)
                {
                    CutScene.SetActive(true);

                    Debug.Log("�ε� �Ϸ�, �ִϸ��̼� ��� ��...");
                    // �ִϸ��̼� �Ϸ� ���
                    yield return new WaitUntil(() => animationDone);
                    // �ִϸ��̼� �Ϸ� �� �� Ȱ��ȭ
                    async.allowSceneActivation = true;
                }
                yield return null;
            }

        }

        public  bool animationDone = false;

        [System.Obsolete]
        public void Show()
        {
            animationDone = true;
            LoadingCanvas.SetActive(false);
            StartCoroutine(LoadScene());
            Debug.Log(SceneManager.GetActiveScene().name);
            StartCoroutine(UnloadCurrentScene());
        }

        private IEnumerator UnloadCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(currentScene);
            while (!asyncUnload.isDone)
            {
                Debug.Log("���� �� ��ε� ��...");
                yield return null;
            }
            Debug.Log("���� �� ��ε� �Ϸ�");
        }*/

}