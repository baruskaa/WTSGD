using UnityEngine;
using UnityEngine.Playables;

public class SequentialTimelinePlayer : MonoBehaviour
{
    public PlayableDirector firstTimeline;
    public PlayableDirector secondTimeline;

    void Start()
    {
        if (firstTimeline != null)
        {
            firstTimeline.stopped += OnFirstTimelineStopped;
            firstTimeline.Play();
        }
    }

    void OnFirstTimelineStopped(PlayableDirector director)
    {
        firstTimeline.stopped -= OnFirstTimelineStopped; // Unsubscribe

        if (secondTimeline != null)
        {
            secondTimeline.Play();
        }
    }

    public void Play2nd()
    {
            secondTimeline.Play();
    }
}
