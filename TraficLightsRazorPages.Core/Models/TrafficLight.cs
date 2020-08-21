using DataAccess.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TraficLightsRazorPages.Core.Hubs;
using TraficLightsRazorPages.Core.Models.Interfaces;
using TraficLightsRazorPages.Data;
using static TraficLightsRazorPages.Core.Models.Interfaces.IColorChangadable;

namespace TraficLightsRazorPages.Core.Models
{
    public class TrafficLight : IColorChangadable
    {

        public delegate void ChangeColorHandler();

/*
        private const int _timeForSwitching = 2;*/
        private bool _switchingDown = true;
        public bool IsSwitchingDown
        {
            get => this._switchingDown;
            set => this._switchingDown = value;
        }
        public Timer ColorSwitchTimer { get; set; }
        private static TrafficLight _traficLight;
        private readonly TraficLightsContext _lightsContext;
        private TrafficLight() { }
        private DateTime LastColorChangeTime { get; set; }


        IServiceProvider Services { get; }


        private readonly IHubContext<TraficLightsHub> _hubContext;
        private readonly IMediator _mediator;

        private readonly TrafficLightRepository _repository;

        public TrafficLight(IHubContext<TraficLightsHub> hubContext, IServiceProvider serviceProvider, IMediator mediator)
        {
            Services = serviceProvider.CreateScope().ServiceProvider;
            _lightsContext = Services.GetRequiredService<TraficLightsContext>();
            _repository = Services.GetRequiredService<TrafficLightRepository>();

            SetCurrentColorFromDBAsync(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            LastColorChangeTime = new DateTime();
            Changes += () => SaveToDBAsync(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            ColorSwitchTimer = new Timer(SwitchNextColor, null, 0, Timeout.Infinite);

            _hubContext = hubContext;
            _mediator = mediator;
        }
        public static TrafficLight GetTrafficLight()
        {
            if (_traficLight is null)
            {
                _traficLight = new TrafficLight
                {
                    LastColorChangeTime = new DateTime()
                };
            }
            return _traficLight;
        }

        public Colors CurrentColor { get; set; } = Colors.red;
        public event ChangeColorHandler Changes;
        
        public void SwitchNextColor(object? o)
        {
            if (this.CurrentColor == Colors.red)
            {
                this.CurrentColor = Colors.yellow;
                ColorSwitchTimer.Change(500, Timeout.Infinite);
                _switchingDown = true;
            }
            else if (CurrentColor == Colors.yellow && _switchingDown)
            {

                ColorSwitchTimer.Change(3000, Timeout.Infinite);
                this.CurrentColor = Colors.green;
                _switchingDown = false;
            }

            else if (CurrentColor == Colors.yellow && !_switchingDown)
            {

                ColorSwitchTimer.Change(3000, Timeout.Infinite);
                this.CurrentColor = Colors.red;
            }
            else if (CurrentColor == Colors.green)
            {

                ColorSwitchTimer.Change(500, Timeout.Infinite);
                this.CurrentColor = Colors.yellow;
            }
            try
            {
                _hubContext.Clients.All.SendAsync("ReceiveColor", CurrentColor.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Changes?.Invoke();
        }
        private async Task SaveToDBAsync(CancellationToken cancellationToken)
        {
            try
            {
                var firstTraficLight = await _repository.FindByIdAsync(1, cancellationToken);
                firstTraficLight.Color = this.CurrentColor.ToString();
                firstTraficLight.Time = DateTime.Now;
                await _lightsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SetCurrentColorFromDBAsync(CancellationToken cancellationToken)
        {
            var traficLights = await _repository.FindByIdAsync(1, cancellationToken);
            if (traficLights.Color.Equals("red"))
            {
                this.CurrentColor = Colors.red;
            }
            else if (traficLights.Color.Equals("yellow"))
            {
                this.CurrentColor = Colors.yellow;
            }
            else
            {
                this.CurrentColor = Colors.green;
            }
            return;
        }
        /*public void NextColor()
        {
            ColorSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);


            if (this.CurrentColor == Colors.red)
            {
                this.CurrentColor = Colors.yellow;
                _switchingDown = true;
            }
            else if (CurrentColor == Colors.yellow && _switchingDown)
            {
                this.CurrentColor = Colors.green;
                _switchingDown = false;
            }

            else if (CurrentColor == Colors.yellow && !_switchingDown)
            {
                this.CurrentColor = Colors.red;
            }
            else if (CurrentColor == Colors.green)
            {
                this.CurrentColor = Colors.yellow;
            }

            Changes?.Invoke();
            ColorSwitchTimer.Change(500, Timeout.Infinite);
        }*/
    }
}
