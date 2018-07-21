using UnityEngine;

public class Gyro : MonoBehaviour{

    private bool gyroEnabled;  // Stores if is gyro enabled for a given device
    private Gyroscope gyro;  // Gyroscope object

    private GameObject cameraContainer; // GameObject that becomes child of camera
    private Quaternion rot; // Quaternion that stores rotation of camera

    private void Start(){
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro(){

        // if device supports a gyroscope, set it as default camera input
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;

            // set default rotation when first creating scene
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void update(){
        // updates position of camera with phone gyroscope of game is running on phone
        if(gyroEnabled){
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
