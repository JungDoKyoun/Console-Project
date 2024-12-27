using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    abstract class NPC : IInteract
    {
        public string NPCName { get; protected set; }

        public abstract void Interact(Player player);
    }
}
