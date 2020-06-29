using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;

namespace Concurrency
{
  public class Channel
  {

    private string name;
    public List<(DateTime, User, string)> messages { get; set; }

    public string Name
    {
      get => name;

      set => name = value;
    }

    public override string ToString()
    {
      return Name;
    }

    public bool Equals(Channel obj)
    {
      return obj != null && Name.Equals(obj.Name);
    }


    public override int GetHashCode()
    {
      return Name.GetHashCode();
    }


  }
}