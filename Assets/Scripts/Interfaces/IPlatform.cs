using UnityEngine;

public interface IPlatform
{
    bool isMobile();
    void DoSomethingPlatformSpecific();
}
