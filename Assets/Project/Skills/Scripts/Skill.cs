using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private float skillDamage;
    [SerializeField] private Element skillAppliedElement;
    [SerializeField] private float skillTravelTime;
    [SerializeField] private float skillTravelDistance;
    [SerializeField] private float skillNectarCost;
    [SerializeField] private SkillAttack thisSkillAttack;
    [HideInInspector] public string whoToDamage;
    private Transform originParent;
    private float skillTravelTimer;
    private Vector3 startPosition;
    private Vector3 startForward;
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
        thisSkillAttack.whoToDamage = whoToDamage;
        thisSkillAttack.originSkill = this;
        startPosition = this.gameObject.transform.position;
        originParent = this.gameObject.transform.parent;
        skillSpeed = (skillTravelDistance / skillTravelTime);
    }

    public void SkillLaunch()
    {
        pcController.skillActive = true;
        skillTravelTimer = skillTravelTime;
        startForward = this.transform.forward;
        this.transform.parent = null;
    }

    private void SkillAction()
    {
        if (pcController.skillActive)
        {
            if (skillTravelTime > 0)
            {
                skillTravelTime -= Time.deltaTime;
                this.transform.forward = startForward;
                Vector3 velocity = this.transform.forward * skillSpeed * Time.deltaTime;
                print(velocity);
                skillRb.velocity = velocity;
            }
            else SkillEnd();
        }
    }
    public void SkillEnd()
    {
        pcController.skillActive = false;
        this.gameObject.transform.parent = originParent;
        this.gameObject.SetActive(false);
    }
}
