using System;
using UnityEngine;

public class PlayerMissile : MonoBehaviour 
{
        [Header("REFERENCES")] 
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerTarget target;
        [SerializeField] private GameObject explosionPrefab;

        [Header("MOVEMENT")] 
        [SerializeField] private float speed = 15;
        [SerializeField] private float rotateSpeed = 95;

        [Header("PREDICTION")] 
        [SerializeField] private float maxDistancePredict = 100;
        [SerializeField] private float minDistancePredict = 5;
        [SerializeField] private float maxTimePrediction = 5;
        private Vector3 standardPrediction, deviatedPrediction;

        [Header("DEVIATION")] 
        [SerializeField] private float deviationAmount = 50;
        [SerializeField] private float deviationSpeed = 2;

        
        private void FixedUpdate() {
            rb.velocity = transform.forward * speed;

            var leadTimePercentage = Mathf.InverseLerp(minDistancePredict, maxDistancePredict, Vector3.Distance(transform.position, target.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateRocket();
        }

        private void PredictMovement(float leadTimePercentage) {
            var predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePercentage);

            standardPrediction = target.rb.position + target.rb.velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage) {
            var deviation = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, Mathf.Cos(Time.time * deviationSpeed));
            
            var predictionOffset = transform.TransformDirection(deviation) * (deviationAmount * leadTimePercentage);

            deviatedPrediction = standardPrediction + predictionOffset;
        }

        private void RotateRocket() {
            var heading = deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision collision) {
            if(explosionPrefab) 
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            if (collision.gameObject.name == "Ship")
            {
                Debug.Log("Ship hit.");
            }
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, standardPrediction);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(standardPrediction, deviatedPrediction);
        }
    
}