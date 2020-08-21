using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using MediatR;
using TraficLightsRazorPages.Core.Models;
using TraficLightsRazorPages.Core.Models.Interfaces;

namespace TraficLightsRazorPages.Core.TrafficLights.Queries
{
    
    public class ChangeColorCommand : IRequest<TrafficLight>
    {
    }

    public class ChangeColorCommandHandler : IRequestHandler<ChangeColorCommand, TrafficLight>
    {
        private readonly TrafficLight _traffic;

        public ChangeColorCommandHandler(TrafficLight traffic)
        {
            _traffic = traffic;
        }



        Task<TrafficLight> IRequestHandler<ChangeColorCommand, TrafficLight>.Handle(ChangeColorCommand request, CancellationToken cancellationToken)
        {

            _traffic.ColorSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);


            if (_traffic.CurrentColor == IColorChangadable.Colors.red)
            {
                _traffic.CurrentColor = IColorChangadable.Colors.yellow;
                _traffic.IsSwitchingDown = true;
            }
            else if (_traffic.CurrentColor == IColorChangadable.Colors.yellow && _traffic.IsSwitchingDown)
            {
                _traffic.CurrentColor = IColorChangadable.Colors.green;
                _traffic.IsSwitchingDown = false;
            }

            else if (_traffic.CurrentColor == IColorChangadable.Colors.yellow && !_traffic.IsSwitchingDown)
            {
                this._traffic.CurrentColor = IColorChangadable.Colors.red;
            }
            else if (_traffic.CurrentColor == IColorChangadable.Colors.green)
            {
                this._traffic.CurrentColor = IColorChangadable.Colors.yellow;
            }

            _traffic.Changes.Invoke();
            _traffic.ColorSwitchTimer.Change(500, Timeout.Infinite);
            return;
        }
    }

}
