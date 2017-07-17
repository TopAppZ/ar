using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class GPS : MonoBehaviour {
    public float latitude;
    public float longitude;
    public Text latitudeText;
    public Text longitudeText;
    public Text distanceText;
    public GameObject boar;
    public GameObject owl;    
    private List<Double> distances;
    private double[,] locations; 
    // Use this for initialization
    private void Start()
    {        
        StartCoroutine(StartLocation());
        InvokeRepeating("UpdateGPSData", 2.0f, 3f);
        boar.SetActive(false);
        owl.SetActive(false);
        distances = new List<Double>();
        locations = new Double[,]
        {
            {21.312206, -157.807450},
            {21.318168, -157.802997},
            {21.325556, -157.857954},
            {22.841229, 88.094324}
        };
    }
    public IEnumerator StartLocation()
    {

        print("starting GPS LocationService");
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start(1,1);

        print("starting GPS LocationService2 " + Input.location.status);

        // Wait until service initializes
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            
        }
    }
    
	// Update is called once per frame
	void Update () {        

    }
    void UpdateGPSData()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        if(longitude != 0.0 && latitude != 0.0)
        {
            for (int i = 0; i < (this.locations.Length) / 2; i++)
            {
                distances.Add(calculate(this.locations[i, 0], latitude, this.locations[i, 1], longitude));
                //distanceText.text = i.ToString();
            }
            double minDist = distances.Min();
            distanceText.text = distances.Min().ToString();
            latitudeText.text = latitude.ToString();
            longitudeText.text = longitude.ToString();

            if(minDist < 30.0)
            {
                owl.SetActive(true);
                boar.SetActive(true);
            }
        }
        
        

    }    
    public double calculate(double lat1, double lat2, double lon1, double lon2)
    {
        var R = 6372.8; // In kilometers
        var dLat = toRadians(lat2 - lat1);
        var dLon = toRadians(lon2 - lon1);
        lat1 = toRadians(lat1);
        lat2 = toRadians(lat2);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Asin(Math.Sqrt(a));
        return R * 2 * Math.Asin(Math.Sqrt(a)) * 1000; //in meters
    }

    public double toRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }
}
