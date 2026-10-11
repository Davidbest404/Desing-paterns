using System;
public class PlayerStateInitializer
{
    public Type[] Initialize(StateMachine sm, PlayerContext context, InputReader input)
    {
        sm.AddState(new PlayerShootState(context, input));
        sm.AddState(new PlayerAoEState(context, input));
        sm.AddState(new PlayerGhostState(context, input));
        return new Type[]
        {
            typeof(PlayerShootState),
            typeof(PlayerAoEState),
            typeof(PlayerGhostState)
        };
    }
}
