using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    //[SerializeField]
    private GameObject _camera;
    [SerializeField]
    private GameObject cameraAnchor;

    private Rigidbody body;
    private float forceFactor = 400f;
    private Vector3 anchorOffset;

    private AudioSource collectSound;
    private AudioSource backgroundMusic;

    private SphereScript instance = null;

    void Start()
    {
        if (instance != null)
        {
            /* Цей код викликається якщо
             * спавниться новий ГО, у новій сцені, але є збережений
             * об'єкт (instance) перенесений з попередньої сцени
             * Треба перенести з нього потрібні характеристики та 
             * видалити його , перейшовши на работу з
             */
            this.transform.position += new Vector3(0, instance.transform.position.y, 0);
            GameObject.Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        _camera = Camera.main.gameObject;

        Debug.Log("SphereScript::Start");

        body = GetComponent<Rigidbody>();
        anchorOffset = this.transform.position -
            cameraAnchor.transform.position;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        collectSound = audioSources[0];
        backgroundMusic = audioSources[1];
        backgroundMusic.ignoreListenerVolume = false;
        if (!MazeState.isSoundsMuted)
        {
            //backgroundMusic.volume = MazeState.musicVolume;
            backgroundMusic.Play();
        }
        MazeState.AddNotifyListener(OnMazeStateChanged);
    }

    void Update()
    {
        float kh = Input.GetAxis("Horizontal");
        float kv = Input.GetAxis("Vertical");

        Vector3 right = _camera.transform.right;
        Vector3 forward = _camera.transform.forward;
        forward.y = 0;
        forward = forward.normalized; 


        Vector3 forceDirection = //new Vector3(kh, 0, kv); - World space
            kh * right + kv * forward;

        forceDirection = forceDirection.normalized;

        body.AddForce(forceFactor * Time.deltaTime * forceDirection);
        cameraAnchor.transform.position = this.transform.position - anchorOffset;
        /*if (MazeState.isSoundsMuted != isMuted)
        {
            isMuted = MazeState.isSoundsMuted;
            backgroundMusic.mute = isMuted;
            collectSound.mute = isMuted;
        }*/
        /*if (backgroundMusic.volume != MazeState.musicVolume&&!MazeState.isSoundsMuted)
        {
            backgroundMusic.Pause();
            backgroundMusic.volume = MazeState.musicVolume;
            backgroundMusic.Play();
        }*/       /*if (collectSound.volume != MazeState.effectsVolume && !MazeState.isSoundsMuted)
        {
            collectSound.volume = MazeState.musicVolume;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SphereScript: " + other.name);
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (!MazeState.isSoundsMuted)
            {
                collectSound.volume = MazeState.effectsVolume;
                collectSound.Play();
            }
        }
    }

    private void OnDestroy()
    {
        MazeState.RemoveNotifyListener(OnMazeStateChanged);
    }

    private void OnMazeStateChanged(string propertyName)
    {
        if (propertyName == nameof(MazeState.musicVolume))
        {
            Debug.Log("OnMazeStateChanged: " + propertyName);
            //if (backgroundMusic.volume != MazeState.musicVolume && !MazeState.isSoundsMuted)
            //{
            //    backgroundMusic.volume = MazeState.musicVolume;
            //}
        }
    }
}
/*
 * - Статичний контекст (наприклад, MazeState) існує між сценами
 *      Дані, записані скриптами однієї сцени, залишаються доступними для
 *      іншої.
 *      Динамічні об'єкти руйнуються при переході між сценами.
 * - DontDestroyOnLoad запобігає руйнуванню об'єкту (GameObject) у т.ч.
 *      його внутрішнього складу. Зберігаються усі характеристики об'єкту - 
 *      позиція, повороти, фізичні показники (швидкість руху, обертання, участь у гравітації) тощо.
 *      Але усі зв'язки, утворені зі руйнованою
 *      сценою, при переході на іншу спричиняють
 *      MissingReferenceException: The object has been destroyed
 *      Оскільки Start при переході збереженого об'єкту не повторюється,
 *      відновити зв'язки ускладнено.
 * - Як варіат, на кожній сцені створити свій "клон" персонажа,
 *      а при старті сцени, коли виникає два об'єкти (новий та збережений),
 *      приймається рішення про залишок одного з них.
 */
