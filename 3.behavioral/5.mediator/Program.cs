using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Mediator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chatroom chatroom = new Chatroom();
            
            Participant john = new Participant("John Lennon");
            Participant paul = new Participant("Paul McCartney");
            Participant george = new Participant("George Harrison");
            Participant ringo = new Participant("Ringo Starr");
            Participant eric = new Participant("Eric Clapton");

            chatroom.Register(john);
            chatroom.Register(paul);
            chatroom.Register(george);
            chatroom.Register(ringo);

            paul.Send(george, "Hey Jude, don't make it bad.");
            george.Send(paul, "Take a sad song and make it better.");
            paul.Send(ringo, "Hey Jude, don't be afraid.");
            ringo.Send(paul, "Don't carry the world upon your shoulders.");
            john.Send(eric, "Na na na nananana, nannana, hey Jude..");
            john.Broadcast("Na na na nananana, nannana, hey Jude..");
        }
    }
    
    interface IChatroom
    {
        void Register(Participant participant);
        void Send(Participant from, Participant to, string message);
        void Broadcast(Participant from, string message);
    }
    
    public class Chatroom : IChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public void Send(Participant from, Participant to, string message)
        {
            if (to == from) return;

            if (!participants.ContainsKey(to.Name))
            {
                Console.WriteLine("Can't send to  '" + to.Name + "', who is not in this chatroom.");
                return;
            }

            to.Receive(from, message);
        }

        public void Broadcast(Participant from, string message)
        {
            foreach(var to in participants.Values)
            {
                if (to == from) continue;

                to.Receive(from, message);
            }
        }
    }

    public class Participant
    {
        Chatroom chatroom;
        string name;
        
        public Participant(string name)
        {
            this.name = name;
        }
        
        public string Name
        {
            get { return name; }
        }
        
        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }
        
        public void Send(Participant to, string message)
        {
            chatroom.Send(this, to, message);
        }

        public void Broadcast(string message)
        {
            chatroom.Broadcast(this, message);
        }
        
        public void Receive(Participant from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from.Name, Name, message);
        }
    }
}