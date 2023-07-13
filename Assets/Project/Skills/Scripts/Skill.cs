using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    /*public float skillDamage;
    [SerializeField] private Reaction.Element skillAppliedElement;
    [SerializeField] private float skillTravelTime;
    [SerializeField] private float skillTravelDistance;
    [SerializeField] private float skillElementDuration;
    public float skillNectarCost;
    [SerializeField] private SkillAttackHitbox thisSkillAttack;
    [HideInInspector] public string whoToDamage;
    private Transform originParent;
    private Vector3 directionToLaunch;
    private Vector3 startPosition;
    private float skillTravelTimer;
    private float skillSpeed;

    private Rigidbody skillRb;
    private PCController pcController;

    private void Awake()
    {
        skillRb = this.gameObject.GetComponent<Rigidbody>();
        pcController = this.gameObject.GetComponentInParent<PCController>();
    }
    private void Update()
    {
        SkillAction();
    }

    public void SkillSetup(string _whoToDamage)
    {
        whoToDamage = _whoToDamage;
        thisSkillAttack.InitializeAttack(whoToDamage, skillElementDuration, this, skillAppliedElement);
        startPosition = this.transform.localPosition;
        originParent = this.gameObject.transform.parent;
        skillSpeed = (skillTravelDistance / skillTravelTime);
        this.gameObject.SetActive(false);
    }

    public void SkillLaunch()
    {
        pcController.skillActive = true;
        directionToLaunch = new Vector3(-originParent.right.z, 0, originParent.right.x);
        skillTravelTimer = skillTravelTime;
        this.transform.parent = null;
    }

    private void SkillAction()
    {
        if (pcController.skillActive)
        {
            if (skillTravelTimer > 0)
            {
                skillTravelTimer -= Time.deltaTime;
                skillRb.velocity = directionToLaunch * skillSpeed;
            }
            else SkillEnd();
        }
    }
    public void SkillEnd()
    {
        pcController.skillActive = false;
        this.gameObject.transform.parent = originParent;
        this.gameObject.transform.localPosition = startPosition;
        this.gameObject.SetActive(false);
    }*/
}
