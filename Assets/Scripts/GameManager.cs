using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3 TargetPoint;
    [SerializeField] float MaxRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        List<NPC> allNPCs = FindObjectsOfType<NPC>().ToList();

        // retrieve all high health NPCs
        var highHealthNPCs = allNPCs.Where(npc => npc.CurrentHealth >= 80f).ToList();
        Debug.Log("High Health NPCs");
        foreach(var npc in highHealthNPCs)
        {
            Debug.Log(npc.gameObject.name + ": " + npc.CurrentHealth);
        }

        // retrieve all low health NPCs (ordered by health)
        var lowHealthNPCs = allNPCs.Where(npc => npc.CurrentHealth <= 50f).OrderBy(npc => npc.CurrentHealth).ToList();
        Debug.Log("Low Health NPCs");
        foreach (var npc in lowHealthNPCs)
        {
            Debug.Log(npc.gameObject.name + ": " + npc.CurrentHealth);
        }

        // retrieve all NPC names ordered by their health
        var allNPCNames = allNPCs.OrderBy(npc => npc.CurrentHealth).Select(npc => npc.gameObject.name).ToList();
        foreach(var NPCName in allNPCNames)
        {
            Debug.Log(NPCName);
        }

        // find all NPCs near target point within range and sorted by range
        var NPCsSortedByDistance = allNPCs.Where(npc => Vector3.Distance(TargetPoint, npc.transform.position) <= MaxRange)
                                          .OrderBy(npc => Vector3.Distance(TargetPoint, npc.transform.position)).ToList();
        foreach(var npc in NPCsSortedByDistance)
        {
            Debug.Log(npc.gameObject.name + " " + Vector3.Distance(TargetPoint, npc.transform.position).ToString());
        }

        // find all NPCs where their name starts with 'NPC'
        var NPCsOfInterest = allNPCs.Where(npc => npc.gameObject.name.StartsWith("NPC")).ToList();
        foreach(var npc in NPCsOfInterest)
        {
            Debug.Log(npc.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
