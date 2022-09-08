using System;

namespace DesignPatterns.Structural.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteOperator remoteOperator = new RemoteOperator();

            IDevice tv = new TV();
            IDevice radio = new Radio();

            Console.WriteLine("Operating tv with basic remote");
            remoteOperator.OperateRemote(new RemoteControl(tv));
            Console.WriteLine("\nOperating tv with advanced remote");
            remoteOperator.OperateAdvancedRemote(new AdvancedRemoteControl(tv));
            Console.WriteLine("\nOperating radio with basic remote");
            remoteOperator.OperateRemote(new RemoteControl(radio));
            Console.WriteLine("\nOperating radio with advanced remote");
            remoteOperator.OperateAdvancedRemote(new AdvancedRemoteControl(radio));
        }
    }

    class RemoteOperator
    {
        public void OperateRemote(RemoteControl remote)
        {
            remote.IncreaseVolume();
            remote.DecreaseVolume();
        }

        public void OperateAdvancedRemote(AdvancedRemoteControl remote)
        {
            remote.IncreaseVolume();
            remote.DecreaseVolume();
            remote.IncreaseVolume();
            remote.IncreaseVolume();
            remote.Mute();
        }
    }

    class RemoteControl
    {
        protected IDevice _device;
        
        public RemoteControl(IDevice device)
        {
            this._device = device;
        }
        
        public void DecreaseVolume()
        {
            this._device.SetVolume(this._device.GetVolume() - 10);
        }

        public void IncreaseVolume()
        {
            this._device.SetVolume(this._device.GetVolume() + 10);
        }
    }

    class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            this._device.SetVolume(0);
        }
    }

    public interface IDevice
    {
        void SetVolume(int percent);
        int GetVolume();
    }

    class TV : IDevice
    {
        private int _volume;

        public void SetVolume(int percent)
        {
            _volume = percent;
            Console.WriteLine("TV volume set to: " + percent);
        }
        
        public int GetVolume()
        {
            return _volume;
        }
    }

    class Radio : IDevice
    {
        private int _volume;

        public void SetVolume(int percent)
        {
            _volume = percent;
            Console.WriteLine("Radio volume set to: " + percent);
        }
        
        public int GetVolume()
        {
            return _volume;
        }
    }
}