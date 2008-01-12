using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WebCamera
{
   public class Device
   {
      public string Name;
      public string Version;

      public Device(string name, string version)
      {
         this.Name = name; this.Version = version;
      }

      public override string ToString()
      {
         return Name + "  " + Version;
      }
      
   }

   public class WebCameraDeviceManager
   {
      [DllImport("avicap32.dll")]
      static extern bool capGetDriverDescription(int wDriverIndex,
          [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName,
          int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);
      
      List<Device> devices = new List<Device>(10);

      public WebCameraDeviceManager()
      {
         Refresh();
      }

      public void Refresh()
      {
         string name = "".PadRight(100), version = "".PadRight(100);

         for (int i = 0; i < 10; i++)
         {
            if (capGetDriverDescription(i, ref name, 100, ref version, 100))
            {
               Device d = new Device(name,version);
               d.Name = name.Trim();
               d.Version = version.Trim();
               devices.Add(d);
            }
         }
      }

      public Device Device(int index)
      {
         return devices[index];
      }

      public Device[] Devices
      {
         get { return devices.ToArray(); }
      }
   }
}
