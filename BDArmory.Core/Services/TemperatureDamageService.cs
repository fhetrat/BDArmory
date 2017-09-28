﻿using BDArmory.Core.Behaviour;
using BDArmory.Core.Enum;
using BDArmory.Core.Events;

namespace BDArmory.Core.Services
{
    internal class TemperatureDamageService : DamageService
    {
        public override void SetDamageToPart(Part p, double damage)
        {
            TemperatureDamageSystem.SetDamageToPart(p, damage);
            PublishEvent(new DamageEventArgs()
            {
                VesselId = p.vessel.GetInstanceID(),
                PartId = p.GetInstanceID(),
                Damage = damage,
                Operation = DamageOperation.Set
            });
        }

        public override void AddDamageToPart(Part p, double damage)
        {
            TemperatureDamageSystem.AddDamageToPart(p, damage);
            PublishEvent(new DamageEventArgs()
            {
                VesselId = p.vessel.GetInstanceID(),
                PartId = p.GetInstanceID(),
                Damage = damage,
                Operation = DamageOperation.Add
            });
        }
    }
}
