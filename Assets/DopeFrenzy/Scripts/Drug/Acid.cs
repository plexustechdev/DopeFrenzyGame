using UnityEngine;


namespace DopeFrenzy
{
    public class Acid : Drug
    {

        [SerializeField] private string _drugName;
        [SerializeField] private float _duration;
        [SerializeField] private float value;


        private Character m_Character;
        private bool _isPickedUp = false;
        private float tempValue;


        public override string drugName { get => _drugName; set => _drugName = value; }
        public override float duration { get => _duration; set => _duration = value; }
        public override bool isPickedUp { get => _isPickedUp; set => _isPickedUp = value; }


        /// <summary>
        /// Activate the Power Up
        /// </summary>
        protected override void Activate()
        {
            tempValue = m_Character.Accuracy;
            m_Character.Accuracy = value;
            PickedUp();
            StartCoroutine(LevelManager.instance.TimerFor(_duration, Stop));


        }


        /// <summary>
        /// Picked The Drug
        /// </summary>
        protected override void PickedUp()
        {
            isPickedUp = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }

        /// <summary>
        /// Stop The Effect
        /// </summary>
        protected override void Stop()
        {
            m_Character.Accuracy = tempValue;
            Destroy(this.gameObject);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (!isPickedUp)
            {
                m_Character = other.GetComponent<Character>();
                Activate();
            }

        }

    }

}

