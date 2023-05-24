using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QR : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;

    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    [SerializeField]
    private TextMeshProUGUI _textOut;

    [SerializeField]
    private RectTransform _scanZone;

    public static QR qr;
    public static Result result;

    private bool _isCamAvailable;
    private WebCamTexture _cameraTexture;
    //public string qr_name;

    
    // Start is called before the first frame update
    
    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraRender();
    }

    private void SetUpCamera()
    {
        // access to all camera on our phone
        WebCamDevice[] devices = WebCamTexture.devices;

        // if we don't have any camera on the device no need to go further
        if(devices.Length == 0)
        {
            _isCamAvailable = false;
            return;
        }
        for(int i = 0; i < devices.Length; i++)
        {
            if(devices[i].isFrontFacing == false)
            {
                _cameraTexture = new WebCamTexture(devices[i].name, (int)_scanZone.rect.width, (int)_scanZone.rect.height);
            }
        }

        // display the render
        _cameraTexture.Play();
        _rawImageBackground.texture = _cameraTexture;
        _isCamAvailable = true;
    }

    private void UpdateCameraRender()
    {
        if(_isCamAvailable == false)
        {
            return;
        }
        float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;

        // make sure camera take everything on the screen into
        _aspectRatioFitter.aspectRatio = ratio;

        int orientation = -_cameraTexture.videoRotationAngle; // do rotation in raw image
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    // when we click the button, scan the qr code
    public void onClickScan()
    {
        _textOut.text = "Click!";
        Scan();
    }

    // Scan of the QR Code
    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            result = barcodeReader.Decode(_cameraTexture.GetPixels32(), _cameraTexture.width, _cameraTexture.height);
            if(result != null)
            {
                // show what qr code is scanning
                _textOut.text = result.Text;
                //SetqrName(result);
            }
            else
            {
                _textOut.text = "FAILED TO READ QR CODE";
            }
        }
        catch
        {
            _textOut.text = "FAILED IN TRY";
        }
    }
    
    private void Awake()
    {
        if (qr == null)
        {
            qr = this;
            DontDestroyOnLoad(gameObject);
        }
        /*else
        {
            Destroy(gameObject);
            Start();
            Update();
        }*/
    }
    
    /*
    public void SetqrName(Result results)
    {
        qr_name = results.Text;
    }*/

    // ----------------------
    /*
    static QR qr_scene;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        qr_scene = gameObject.AddComponent<QR>();
        SetUpCamera();
    }*/
}