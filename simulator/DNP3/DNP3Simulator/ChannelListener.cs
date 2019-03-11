using Automatak.DNP3.Interface;
using Automatak.Simulator.API;
using System;

namespace Automatak.Simulator.DNP3
{
    public class ChannelListener : IChannelListener
    {
        private readonly ISimulatorNodeCallbacks _callbacks;

        public ChannelListener(ISimulatorNodeCallbacks callbacks)
        {
            _callbacks = callbacks ?? throw new ArgumentNullException(nameof(callbacks));
        }

        public void OnStateChange(ChannelState state)
        {
            _callbacks.ChangeState(GetNodeState(state));
        }

        private NodeState GetNodeState(ChannelState state)
        {
            switch (state)
            {
                case (ChannelState.OPENING):
                    return NodeState.Inactive;
                case (ChannelState.OPEN):
                    return NodeState.Active;
                default:
                    return NodeState.Inactive;
            }
        }
    }
}
