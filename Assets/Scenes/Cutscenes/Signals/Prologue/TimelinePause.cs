using UnityEngine;
using UnityEngine.Playables;

public class TimelinePause : MonoBehaviour
{
    public PlayableDirector director;

    public void ActuallyPauseTimeline()
    {
        // Pause Timeline without exiting it
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public void ResumeTimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
