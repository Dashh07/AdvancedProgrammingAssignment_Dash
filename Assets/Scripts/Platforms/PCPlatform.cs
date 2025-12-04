using UnityEngine;

public class PCPlatform : IPlatform
{
    public bool isMobile()
    {
        return false;
    }

    public void DoSomethingPlatformSpecific()
    {
        Debug.Log("PC Platform Specific Behavior");
    }
}
