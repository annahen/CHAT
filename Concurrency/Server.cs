using System;
using System.Collections.Generic;
using System.Linq;

namespace Concurrency
{
  public class Server
  {
    Dictionary<string, List<Channel>> serverDictionary;
    Dictionary<Channel, Tuple<string, string>> messages = new Dictionary<Channel, Tuple<string, string>>();
    private List<User> users;
    private List<Channel> channels { get; set;  }

    public void Start()
    {
      serverDictionary = new Dictionary<string, List<Channel>>();
      channels = new List<Channel>();
      users = new List<User>();

    }

    public void CreateChannel(string name)
    {
      Channel newChannel = new Channel();
      newChannel.Name = name;
      channels.Add(newChannel);
    }

    public void Dispose()
    {
      //TODO
    }

    public void Join(string channel, User user)
    {
      if (!channels.Exists(i => i.Name == channel))
      {
        CreateChannel(channel);
      }
    }

    /*public List<Channel> GetAllChannels()
    {
      return channels;
    }*/

    public void CreateUser(string userName)
    {
      User newUser = new User(this) {UserName = userName};
      users.Add(newUser);
    }

/*    public List<User> GetAllUsers()
    {
      return users;
    }*/

    public void UpdateNick(User userName, string newNick)
    {
      var obj = users.FirstOrDefault(x => x == userName);
      if (obj != null) obj.UserName = newNick;
    }
  }
}