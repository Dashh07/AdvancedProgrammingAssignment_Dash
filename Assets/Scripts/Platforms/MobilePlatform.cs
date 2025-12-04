using UnityEngine;

public class MobilePlatform : IPlatform
{
    public bool isMobile()
    {
        return true;
    }

    public void DoSomethingPlatformSpecific()
    {
        Debug.Log("Mobile Specific Behavior");
    }
}
