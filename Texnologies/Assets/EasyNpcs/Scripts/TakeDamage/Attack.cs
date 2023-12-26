﻿namespace AIPackage
{
    public class Attack
    {
        private readonly int _damage;
        private readonly bool _critical;

        public Attack(int dam)
        {
            _damage = dam;
        }

        public int damage
        {
            get { return _damage; }
        }

        public bool isCritical
        {
            get { return _critical; }
        }
    }
}
