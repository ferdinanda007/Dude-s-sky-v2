/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menampilkan nilai variabel (gambar)
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TechnomediaLabs;

namespace Zetcil {

    public class UIImage : MonoBehaviour
    {
        public enum CImageLoad { None, ByDelay, ByInputKey, ByEvent }
        public enum CImageStrecth { Original, Stretch }

        [Space(10)]
        public bool isEnabled;

        [Header("UI Variables")]
        public RawImage TargetImage;

        [Header("Image Load Settings")]
        public CImageLoad ImageLoad;
        public CImageStrecth ImageStretch;
        public float ImageDelay;
        [SearchableEnum] public KeyCode ImageTriggerKey;

        [Header("URL Settings")]
        public VarString BasePath;
        public VarString ImageFileName;

        [Header("Streaming URL")]
        public bool usingStreamingAssets;

        // Start is called before the first frame update
        void Start()
        {
            if (usingStreamingAssets)
            {
                BasePath.CurrentValue = Application.persistentDataPath;
            }
            if (ImageLoad == CImageLoad.ByDelay)
            {
                Invoke("ExecuteLoadImage", ImageDelay);
            }
        }

        public void ExecuteLoadImage()
        {
            string MediaURl = BasePath.CurrentValue + "/" + ImageFileName.CurrentValue;
            StartCoroutine(DownloadImage(MediaURl));
        }

        IEnumerator DownloadImage(string MediaUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (ImageStretch == CImageStrecth.Original)
                {
                    float imgWidth = ((DownloadHandlerTexture) request.downloadHandler).texture.width;
                    float imgHeight = ((DownloadHandlerTexture) request.downloadHandler).texture.height;
                    TargetImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                    TargetImage.GetComponent<RectTransform>().sizeDelta = new Vector2(imgWidth, imgHeight);
                } else if (ImageStretch == CImageStrecth.Stretch)
                {
                    TargetImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (ImageLoad == CImageLoad.ByInputKey)
            {
                if (Input.GetKeyDown(ImageTriggerKey))
                {
                    ExecuteLoadImage();
                }
            }
        }
    }
}
